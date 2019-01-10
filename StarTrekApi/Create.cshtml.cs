using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PointRobertsSoftware.StarTrek.Api.Data;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace StarTrekApi
{
    public class CreateModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public CreateModel(IUserRepository repo)
        {
            _userRepository = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User CurrentUser { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_userRepository.Add(User);    TODO
            //await _context.SaveChangesAsync();    TODO

            return RedirectToPage("./Index");
        }
    }
}