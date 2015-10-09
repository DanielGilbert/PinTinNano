using PinTin.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinTin.Core.Storage.Interfaces
{
    public interface IStorage
    {
        List<Entry> Load();
        List<Entry> Load(string file);
        void Save(List<Entry> entries);
        void Save(List<Entry> entries, string file);
        bool IsSafeAvailable();
        bool IsSafeAvailable(string file);
    }
}