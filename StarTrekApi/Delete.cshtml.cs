using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PointRobertsSoftware.StarTrek.Api.Data;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace StarTrekApi
{
    public class DeleteModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public DeleteModel(IUserRepository repo)
        {
            _userRepository = repo;
        }

        [BindProperty]
        public User CurrentUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? idNull)
        {

            if (idNull == null)
            {
                return NotFound();
            }

            int id = (int)idNull;

            CurrentUser = await _userRepository.GetAsync(id);

            if (CurrentUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? idNull)
        {
            if (idNull == null)
            {
                return NotFound();
            }

            int id = (int)idNull;

            CurrentUser = await _userRepository.GetAsync(id);

            if (CurrentUser != null)
            {
                _userRepository.Delete(CurrentUser);
                //await _userRepository.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
