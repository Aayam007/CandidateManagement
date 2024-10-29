﻿using System.ComponentModel.DataAnnotations;

namespace CandidateManagement.Application.DTOs
{
    public class CandidateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PreferredCallTime { get; set; }

        public string LinkedInProfileUrl { get; set; }

        public string GitHubProfileUrl { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
