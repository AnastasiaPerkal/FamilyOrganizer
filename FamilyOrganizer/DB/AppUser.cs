using FamilyOrganizer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer.User
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public string Role { get; set; } = "Child";
        public Photo Photo { get; set; }
        public int PhotoId { get; set; } = 1;
        public ICollection<Transaction> IncomingTransactions { get; set; }
        public ICollection<Comment> UserComments { get; set; }
    }
}
