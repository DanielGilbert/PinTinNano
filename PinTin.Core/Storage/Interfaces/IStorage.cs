using PinTin.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PinTin.Core.Storage.Interfaces
{
    public interface IStorage
    {
        List<Entry> Load(SecureString password);
        List<Entry> Load(string file, SecureString password);
        void Save(List<Entry> entries, SecureString password);
        void Save(List<Entry> entries, string file, SecureString password);
        bool IsSafeAvailable();
        bool IsSafeAvailable(string file);
    }
}