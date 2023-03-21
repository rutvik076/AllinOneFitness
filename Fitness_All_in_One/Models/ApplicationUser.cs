using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fitness_All_in_One.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]

        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public string Weight { get; set; }

        [Required]

        public string Height { get; set; }

        [Required]
        public string TargetWeight { get; set; }

    

    }
}
