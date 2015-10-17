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
        Database Load(SecureString password);
        Database Load(string file, SecureString password);
        void Save(Database database, SecureString password);
        void Save(Database database, string file, SecureString password);
        bool IsSafeAvailable();
        bool IsSafeAvailable(string file);
    }
}