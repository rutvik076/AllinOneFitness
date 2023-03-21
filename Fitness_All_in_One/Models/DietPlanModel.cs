using System.ComponentModel.DataAnnotations;

namespace Fitness_All_in_One.Models
{
    public class DietPlanModel
    {
        [Required] 
        public int Id { get; set; }

        [Required]

        public string DietName { get; set; }

        [Required]
        public string Gender { get; set; }
 

        [Required]
        public string StartAge { get; set; }

        [Required]
        public string EndAge { get;  set; }


        [Required]
        public string StartWeight { get; set; }

        [Required]
        public string EndWeight { get; set; }


        [Required]

        public string StartHeight { get; set; }

        [Required]
        public string EndHeight { get; set; }

        [Required]

        public string Description { get; set; }

        [Required]

        public string BMI { get; set; }

        [Required]

        public string Food { get; set; }

    }
}

