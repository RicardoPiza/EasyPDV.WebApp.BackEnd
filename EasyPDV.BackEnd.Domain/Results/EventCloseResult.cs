using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Results
{
    public class EventCloseResult
    {
        public string Total{ get; set; }
        public string EventName { get; set; }
        public string Responsible { get; set; }
        public DateTime Date { get; set; }
    }
}
