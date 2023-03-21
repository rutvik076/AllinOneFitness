using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Fitness_All_in_One.Data;
using Fitness_All_in_One.Models;
using Fitness_All_in_One.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fitness_All_in_One.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DietPlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietPlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dietPlans = await _context.DietPlans.ToListAsync();
            return View(dietPlans);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DietPlanModel model)
        {
            if (ModelState.IsValid)
            {
                var dietPlan = new DietPlanModel
                {
                    DietName = model.DietName,
                    Description = model.Description,
                    Gender = model.Gender,
                    StartAge = model.StartAge, 
                    EndAge = model.EndAge,
                    StartWeight = model.StartWeight,
                    EndWeight = model.EndWeight,
                    StartHeight = model.StartHeight,
                    EndHeight = model.EndHeight,
                    BMI = model.BMI,
                    Food = model.Food,
                };

                _context.Add(dietPlan);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"Diet plan '{dietPlan.DietName}' has been created successfully.";
                return RedirectToAction("Index");
            }

            return View(model);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);

            if (dietPlan == null)
            {
                return NotFound();
            }

            var viewModel = new DietPlanModel
            {
                Id = dietPlan.Id,
                DietName = dietPlan.DietName,
                Gender = dietPlan.Gender,
                StartAge = dietPlan.StartAge,
                EndAge = dietPlan.EndAge,
                StartWeight = dietPlan.StartWeight,
                EndWeight = dietPlan.EndWeight,
                StartHeight = dietPlan.StartHeight,
                EndHeight = dietPlan.EndHeight,
                Description = dietPlan.Description,
                BMI = dietPlan.BMI,
                Food = dietPlan.Food,

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DietPlanModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dietPlan = await _context.DietPlans.FindAsync(id);

                if (dietPlan == null)
                {
                    return NotFound();
                }

                dietPlan.DietName = model.DietName;
                dietPlan.Description = model.Description;
                dietPlan.Gender = model.Gender;
                dietPlan.StartAge = model.StartAge;
                dietPlan.EndAge = model.EndAge;
                dietPlan.StartWeight = model.StartWeight;
                dietPlan.EndWeight = model.EndWeight;
                dietPlan.StartHeight = model.StartHeight;
                dietPlan.EndHeight = model.EndHeight;
                dietPlan.BMI = model.BMI;
                dietPlan.Food = model.Food;

                _context.Update(dietPlan);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"Diet plan '{dietPlan.DietName}' has been updated successfully.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);
            if (dietPlan == null)
            {
                return NotFound();
            }

            return View(dietPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);

            if (dietPlan == null)
            {
                return NotFound();
            }

            _context.DietPlans.Remove(dietPlan);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Diet plan '{dietPlan.DietName}' has been deleted successfully.";
            return RedirectToAction("Index");
        }
        public IActionResult Description(int id)
        {
            // Retrieve the diet plan with the specified ID
            var dietPlan = _context.DietPlans.FirstOrDefault(dp => dp.Id == id);

            // Pass the diet plan to the view
            return View(dietPlan);
        }

    }
}