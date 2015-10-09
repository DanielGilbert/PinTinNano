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
        Save(List<Entry> entries);
    }
}
