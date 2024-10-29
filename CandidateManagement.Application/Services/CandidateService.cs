using CandidateManagement.Application.DTOs;
using CandidateManagement.Application.IServices;
using CandidateManagement.Domain.Entities;
using CandidateManagement.Domain.IRepositories;

namespace CandidateManagement.Application.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;


        public CandidateService(ICandidateRepository repository)
        {
            _candidateRepository = repository;
        }

        public async Task<string> AddOrUpdateCandidateAsync(CandidateDto candidateDto)
        {
            var existingCandidate = await _candidateRepository.GetCandidateByEmailAsync(candidateDto.Email);

            if (existingCandidate == null)
            {
                var newCandidate = new Candidate
                {
                    FirstName = candidateDto.FirstName,
                    LastName = candidateDto.LastName,
                    Email = candidateDto.Email,
                    PhoneNumber = candidateDto.PhoneNumber,
                    PreferredCallTime = candidateDto.PreferredCallTime,
                    LinkedInProfileUrl = candidateDto.LinkedInProfileUrl,
                    GitHubProfileUrl = candidateDto.GitHubProfileUrl,
                    Comment = candidateDto.Comment
                };

                await _candidateRepository.AddCandidateAsync(newCandidate);
                return "Candidate added successfully.";
            }
            else
            {
                existingCandidate.FirstName = candidateDto.FirstName;
                existingCandidate.LastName = candidateDto.LastName;
                existingCandidate.PhoneNumber = candidateDto.PhoneNumber;
                existingCandidate.PreferredCallTime = candidateDto.PreferredCallTime;
                existingCandidate.LinkedInProfileUrl = candidateDto.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = candidateDto.GitHubProfileUrl;
                existingCandidate.Comment = candidateDto.Comment;

                await _candidateRepository.UpdateCandidateAsync(existingCandidate);
                return "Candidate updated successfully.";
            }
        }
    }
}
