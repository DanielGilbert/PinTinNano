using PinTin.Core.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinTin.Commons.Models;

namespace PinTin.Core.Storage
{
    public class XmlStorage : IStorage
    {
        public bool IsSafeAvailable()
        {
            throw new NotImplementedException();
        }

        public bool IsSafeAvailable(string file)
        {
            throw new NotImplementedException();
        }

        public List<Entry> Load()
        {
            throw new NotImplementedException();
        }

        public List<Entry> Load(string file)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Entry> entries)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Entry> entries, string file)
        {
            throw new NotImplementedException();
        }
    }
}
