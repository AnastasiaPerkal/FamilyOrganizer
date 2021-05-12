using FamilyOrganizer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer.DB
{
    public class Photo
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public ICollection<AppUser> UsersWithPhoto { get; set; }
    }
}
