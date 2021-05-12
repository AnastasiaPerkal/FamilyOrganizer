using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer.DB
{
    public class Diary
    {
        public int PostNum { get; set; }
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public string Post { get; set; }
    }
}
