using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIBA_COMPANY.classes
{
    public class DataIncentive
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Emplo { get; set; }
        public decimal? Sold { get; set; }
       
        public decimal? Emony { get; set; }
        public decimal? Mmony { get; set; }
        public decimal? Units { get; set; }
    }
}
