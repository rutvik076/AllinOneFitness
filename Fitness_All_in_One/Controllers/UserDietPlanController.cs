using Fitness_All_in_One.Data;
using Fitness_All_in_One.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fitness_All_in_One.Controllers
{
    public class UserDietPlanController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public UserDietPlanController(UserManager<ApplicationUser> userManager , ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            double weight = double.Parse(user.Weight);
            double height = double.Parse(user.Height) / 100.0; // convert height to meters

            double bmi = weight / (height * height);

            var userDetails = new UserDetails
            {
                Name = user.Name,
                Gender = user.Gender,
                Age = user.Age,
                Weight = user.Weight,
                Height = user.Height,
                TargetWeight = user.TargetWeight,
                BMI = bmi.ToString("F") // format the BMI value as a string
            };

            return View(userDetails);
        }
        public async Task<IActionResult> GeneratePlan()
        {
            // Get the current user's gender
            var user = await _userManager.GetUserAsync(User);
            var gender = user.Gender;
            

            // Retrieve all diet plans from the database that match the user's gender
            var dietPlans = await _context.DietPlans
                .Where(dp => dp.Gender == gender)
                .Select(dp => new DietPlanModel
                {
                    Description = dp.Description,
                    DietName = dp.DietName,
                    Food = dp.Food
                })
                .ToListAsync();

            if (dietPlans.Count == 0)
            {
                return NotFound();
            }

            // Pass the list of diet plans to the view
            return View(dietPlans);
        }



        [HttpGet]
        public IActionResult Description(int id)
        {
            // Retrieve the diet plan with the specified ID
            var dietPlan = _context.DietPlans.FirstOrDefault(dp => dp.Id == id);

            // If the diet plan is not found, return a 404 Not Found response
            if (dietPlan == null)
            {
                return NotFound();
            }

            // Pass the diet plan to the view
            return View(dietPlan);
        }










    }
}
