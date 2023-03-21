using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fitness_All_in_One.ViewModels
{
    public class UserViewModel
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }

        public string Weight { get; set; }

        public string Height { get; set; }

        public string TargetWeight { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}

