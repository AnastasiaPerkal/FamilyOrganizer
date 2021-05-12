using FamilyOrganizer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer.DB
{
    public class Transaction
    {
        public int TransactionNum { get; set; }
        public AppUser ToUser { get; set; }
        public int ToUserId { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Type { get; set; } = "Money transfer";
    }
}
