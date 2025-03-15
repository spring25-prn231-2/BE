using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;

namespace ChillLancer.BusinessService.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;
        public CertificationService(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }
        //=============================================================================

        public async Task<bool> CreateCertification(CertificationBM inputData)
        {
            var existCertificate = await _certificationRepository.GetOneAsync(cate =>
            cate.Name.ToLower().Equals(inputData.Name.ToLower()));

            if (existCertificate is not null) throw new ConflictException("This Certificate is existed!");

            //*Remember to assign AccountId into inputData
            await _certificationRepository.AddAsync(inputData.Adapt<Certification>());
            return await _certificationRepository.SaveChangeAsync();
        }

        public async Task<CertificationBM> ViewCertification(Guid id)
        {
            var existCertificate = await _certificationRepository.GetOneAsync(cert => cert.Id == id);

            return existCertificate is null
                ? throw new NotFoundException("This Certificate is not existed!")
                : existCertificate.Adapt<CertificationBM>();
        }
        public async Task<List<CertificationBM>> GetAllCertifications()
        {
            var listResult = await _certificationRepository.GetListAsync(lang => lang.Status.ToLower().Equals("created"));
            return listResult.Adapt<List<CertificationBM>>();
        }

        public async Task<List<CertificationBM>> GetUserCertifications(Guid userId)
        {
            var listResult = await _certificationRepository.GetListAsync(cer => cer.Freelancer.Id == userId);

            return listResult is null
                ? throw new NotFoundException("There are no Certification of this User!")
                : listResult.Adapt<List<CertificationBM>>();
        }

        public async Task<bool> UpdateCertification(CertificationBM newData)
        {
            var existCertificate = await _certificationRepository.GetOneAsync(cert => cert.Id == newData.Id)
                ?? throw new NotFoundException("This Certificate is not existed!");

            newData.Adapt(existCertificate);
            return await _certificationRepository.SaveChangeAsync();
        }

        public async Task<bool> DeleteCertification(Guid id)
        {
            var existCertificate = await _certificationRepository.GetOneAsync(cert => cert.Id == id)
                ?? throw new NotFoundException("This Certificate is not existed!");

            existCertificate.Status = "Deleted";
            return await _certificationRepository.SaveChangeAsync();
        }
    }
}
