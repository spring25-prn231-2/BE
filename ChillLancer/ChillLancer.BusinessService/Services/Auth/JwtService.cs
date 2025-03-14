﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.Services.Auth
{
    public static class JwtConst
    {
        public const int ACCESS_TOKEN_EXP = 15 * 60; // 15m
    }
    public interface IJwtService
    {
        string GenerateToken(Guid userId, string role);
        Payload? ValidateToken(string token);

    }
    public class JwtService : IJwtService
    {
        private readonly byte[] _key;
        private readonly JwtSecurityTokenHandler _handler;
        public JwtService()
        {
            var SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "8a21f416ac3c7de71de084e5190bb322456f5739eff177aeb5be84af1a70bc59";
            _key = System.Text.Encoding.ASCII.GetBytes(SecretKey);
            _handler = new JwtSecurityTokenHandler();
        }
        // role: Admin, Employer, Freelancer
        public string GenerateToken(Guid userId, string role)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new("role", role)
                ]),
                Issuer = userId.ToString(),
                Expires = DateTime.UtcNow.AddSeconds(JwtConst.ACCESS_TOKEN_EXP),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _handler.CreateToken(tokenDescriptor);

            return _handler.WriteToken(token);
        }

        public Payload? ValidateToken(string token)
        {
            _handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var result = (JwtSecurityToken)validatedToken;

            var payload = new Payload()
            {
                UserId = Guid.Parse(result.Issuer),
                Role = result.Claims.First(x => x.Type == "role").Value
            };

            return payload;
        }
    }
}
