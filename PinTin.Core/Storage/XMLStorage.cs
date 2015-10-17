using PinTin.Core.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinTin.Commons.Models;
using System.Security;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using PinTin.Core.Encryption;
using PinTin.Core.Helper;

namespace PinTin.Core.Storage
{
    public class XmlStorage : IStorage
    {
        public bool IsSafeAvailable()
        {
            return File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "entries.dat"));
        }

        public bool IsSafeAvailable(string file)
        {
            return File.Exists(file);
        }

        public Database Load(SecureString password)
        {
            return Load(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "entries.dat"), password);
        }

        public Database Load(string file, SecureString password)
        {
            Database database;
            string decryptedContent = GetUnencryptedFileContent(file, password);
            var serializer = new XmlSerializer(typeof(Database));
            using (var reader = XmlReader.Create(new StringReader(decryptedContent)))
            {
                database = (Database)serializer.Deserialize(reader);
            }
            return database;
        }

        public void Save(Database database, SecureString password)
        {
            Save(database, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "entries.dat"), password);
        }

        public void Save(Database database, string file, SecureString password)
        {
            var serializer = new XmlSerializer(typeof(Database));
            StringBuilder data = new StringBuilder();
            using (var writer = XmlWriter.Create(new StringWriter(data)))
            {
                serializer.Serialize(writer, database);
            }

            string encryptedContent = EncryptFileContent(data.ToString(), password);
            File.WriteAllText(file, encryptedContent);
        }

        private string EncryptFileContent(string content, SecureString password)
        {
            return AESGCM.SimpleEncryptWithPassword(content, SecureStringHelper.MakeInsecure(password));
        }

        private string GetUnencryptedFileContent(string file, SecureString password)
        {
            return AESGCM.SimpleDecryptWithPassword(File.ReadAllText(file), SecureStringHelper.MakeInsecure(password));
        }
    }
}
