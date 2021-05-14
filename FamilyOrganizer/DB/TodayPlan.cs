using FamilyOrganizer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer.DB
{
    public class TodayPlan
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsRoutine { get; set; }
        public bool IsAdded { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
    }
}
