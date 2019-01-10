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
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository repo)
        {
            _userRepository = repo;
        }

        [BindProperty]
        public IList<User> Users { get; set; }

        public IList<User> OnGet()
        {
            Users = _userRepository.FindAll().ToList();
            return Users;
        }
    }
}
