using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinTin.Commons.Models
{
    public class Database
    {
        public int Version { get; set; }
        public List<Entry> Entries { get; set; }
        public Database()
        {
            Version = 1;
            Entries = new List<Entry>();
        }
    }
}
