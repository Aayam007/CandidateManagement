using CandidateManagement.Application.DTOs;

namespace CandidateManagement.Application.IServices
{
    public interface ICandidateService
    {
        Task<string> AddOrUpdateCandidateAsync(CandidateDto candidateDto);
    }
}
