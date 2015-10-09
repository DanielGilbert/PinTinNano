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
        public string EncryptedData { get; set; }
        [XmlIgnore]
        public string Title { get; }
        [XmlIgnore]
        public string Username { get; }
        [XmlIgnore]
        public string Password { get; }
        [XmlIgnore]
        public string Uri { get; }
        [XmlIgnore]
        public string Note { get; }

        public Entry()
        {
            Id = Guid.NewGuid();
        }

        public void Open(SecureString password)
        {

        }
    }
}
