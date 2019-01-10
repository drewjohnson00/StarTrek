using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PointRobertsSoftware.StarTrek.Api.Data;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace StarTrekApi
{
    public class EditModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public EditModel(IUserRepository context)
        {
            _userRepository = context;
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_userRepository.Attach(User).State = EntityState.Modified; TODO

            try
            {
                //await _userRepository.SaveChangesAsync();  TODO
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_userRepository.UserExists(CurrentUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

    }
}
