using Fitness_All_in_One.Models;
using Fitness_All_in_One.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Fitness_All_in_One.Data;

namespace Fitness_All_in_One.Controllers
{
    [Authorize (Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        // private readonly RoleManager<IdentityRole> _roleManager;
        

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            _userManager = userManager;
            // _roleManager = roleManager;
           
        }

        public async Task<IActionResult> Index()
        {
                  var users = await _userManager.Users.Select(user => new UserViewModel {
                            Id = user.Id,
                            Name = user.Name,
                            Gender = user.Gender,
                            Age = user.Age,
                            Weight = user.Weight,
                            Height = user.Height,
                            TargetWeight = user.TargetWeight,
                            Email = user.Email,
                      //    Roles = _userManager.GetRolesAsync(user).Result

                        }).ToListAsync();

                        return View(users);
    
        }
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Gender = user.Gender,
                Age = user.Age,
                Weight = user.Weight,
                Height = user.Height,
                TargetWeight = user.TargetWeight,
                Email = user.Email,
               /* Roles = await _userManager.GetRolesAsync(user)*/
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UserViewModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return NotFound();
                }

                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                user.Name = model.Name;
                user.Gender = model.Gender;
                user.Age = model.Age;
                user.Weight = model.Weight;
                user.Height = model.Height;
                user.TargetWeight = model.TargetWeight;
                /*user.Email = model.Email;*/

                var result = await _userManager.UpdateAsync(user);



                if (result.Succeeded)
                {
                    TempData["Message"] = $"User profile for {user.Name} has been updated successfully.";
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                // log the error or handle it in some way
                return View("Error");
            }
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Gender = user.Gender,
                Age = user.Age,
                Weight = user.Weight,
                Height = user.Height,
                TargetWeight = user.TargetWeight,
                Email = user.Email
            };
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["Message"] = $"User profile of {user.Name} has been deleted successfully.";
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Gender = user.Gender,
                Age = user.Age,
                Weight = user.Weight,
                Height = user.Height,
                TargetWeight = user.TargetWeight,
                Email = user.Email
                
                
            };
            return View("Delete", viewModel);
        }




    }


}



