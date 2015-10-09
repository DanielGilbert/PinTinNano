using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PinTin.Commons.Models
{
    public class Entry
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Uri { get; set; }
        public string Note { get; set; }

        public Entry()
        {
            Id = Guid.NewGuid();
        }
    }
}
