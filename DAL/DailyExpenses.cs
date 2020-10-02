using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
  public  class DailyExpenses
    {
        public int ID { get; set; }
        public double Coast { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
