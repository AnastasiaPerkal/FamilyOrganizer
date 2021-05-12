using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer.DB
{
    public class ShoppingPlan
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public bool Accepted { get; set; } = false;
    }
}
