using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;

namespace ChillLancer.BusinessService.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        //=============================================================================

        public async Task<bool> CreateEducation(EducationBM inputData)
        {
            var existCertificate = await _educationRepository.GetOneAsync(edu =>
            edu.Country.ToLower().Equals(inputData.Country.ToLower()) &&
            edu.SchoolName.ToLower().Equals(inputData.SchoolName.ToLower()) &&
            edu.Major.ToLower().Equals(inputData.Major.ToLower()));

            if (existCertificate is not null) throw new ConflictException("Cannot create the same major in same school and country education!");

            await _educationRepository.AddAsync(inputData.Adapt<Education>());
            return await _educationRepository.SaveChangeAsync();
        }

        public async Task<EducationBM> ViewEducation(Guid id)
        {
            var existCertificate = await _educationRepository.GetOneAsync(edu => edu.Id == id);

            return existCertificate is null
                ? throw new NotFoundException("This Certificate is not existed!")
                : existCertificate.Adapt<EducationBM>();
        }
        public async Task<List<EducationBM>> GetAllEducations()
        {
            var listResult = await _educationRepository.GetListAsync(edu => edu.Status.ToLower().Equals("created"));
            return listResult.Adapt<List<EducationBM>>();
        }

        public async Task<List<EducationBM>> GetUserEducations(Guid userId)
        {
            var listResult = await _educationRepository.GetListAsync(edu => edu.Freelancer.Id == userId);

            return listResult is null
                ? throw new NotFoundException("There are no Education of this User!")
            : listResult.Adapt<List<EducationBM>>();
        }

        public async Task<bool> UpdateEducation(EducationBM newData)
        {
            var existCertificate = await _educationRepository.GetOneAsync(edu => edu.Id == newData.Id)
                ?? throw new NotFoundException("This Certificate is not existed!");

            newData.Adapt(existCertificate);
            return await _educationRepository.SaveChangeAsync();
        }

        public async Task<bool> DeleteEducation(Guid id)
        {
            var existCertificate = await _educationRepository.GetOneAsync(edu => edu.Id == id)
                ?? throw new NotFoundException("This Certificate is not existed!");

            await _educationRepository.DeleteAsync(existCertificate);
            return await _educationRepository.SaveChangeAsync();
        }
    }
}
