using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface ICertificationService
    {
        Task<bool> CreateCertification(CertificationBM inputData);
        Task<CertificationBM> ViewCertification(Guid id);
        Task<List<CertificationBM>> GetAllCertifications();
        Task<List<CertificationBM>> GetUserCertifications(Guid userId);
        Task<bool> UpdateCertification(CertificationBM newData);
        Task<bool> DeleteCertification(Guid id);
    }
}
