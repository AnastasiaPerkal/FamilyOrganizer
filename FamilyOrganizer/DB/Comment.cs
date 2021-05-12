using FamilyOrganizer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer.DB
{
    public class Comment
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public DateTime PublishedOn { get; set; } = DateTime.Now;
        public string Content { get; set; }
    }
}
