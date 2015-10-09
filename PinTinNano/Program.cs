using PinTin.Commons.Models;
using PinTin.Core;
using PinTin.Core.Helper;
using PinTin.Core.Storage;
using PinTin.Core.Storage.Interfaces;
using PinTin.Edison;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PinTinNano
{
    class Program
    {
        static bool noNewPassword = true;
        static SecureString password;
        static List<Entry> entries;

        static void Main(string[] args)
        {
            IStorage xmlStorage = new XmlStorage();
            PinTinEdison pinTinEdison = new PinTinEdison();

            pinTinEdison.CallBegin();

            Console.WriteLine("Welcome to the PinTin");
            Console.WriteLine("Enter your password.");

            //Check, if there is a safe already available
            if (!xmlStorage.IsSafeAvailable())
            {
                while (noNewPassword)
                {
                    //Ask the user for a new Password
                    pinTinEdison.CallDisplayOkMessage("Please enter a new password.");

                    //Get the new Passwort
                    password = SecureStringHelper.MakeStringSecure(pinTinEdison.CallGetUserTextInput("Enter:"));

                    //TODO: Add compare call and some logic
                    noNewPassword = false;
                }

                //xmlStorage.Save()
            }

            //Ask for the Master Password
            pinTinEdison.CallGetUserTextInput("Password?");

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //string encryptedData = AESThenHMAC.SimpleEncryptWithPassword("Test1234", "Test4321", new byte[] { 255, 255 });
            //string decryptedData = AESThenHMAC.SimpleDecryptWithPassword(encryptedData, "Test4321", 2);
            //sw.Stop();

            //Console.WriteLine(encryptedData);
            //Console.WriteLine(decryptedData);
            //Console.WriteLine("Elapsed time: {0}", sw.Elapsed.TotalMilliseconds);
            //Console.WriteLine("--------------------------------");
            //sw.Reset();
            //sw.Start();
            //encryptedData = AESThenHMAC.SimpleEncryptWithPassword("Test1234", "Test4321", new byte[] { 255, 255 });
            //decryptedData = AESThenHMAC.SimpleDecryptWithPassword(encryptedData, "Test4321", 2);
            //sw.Stop();

            //Console.WriteLine(encryptedData);
            //Console.WriteLine(decryptedData);
            //Console.WriteLine("Elapsed time: {0}", sw.Elapsed.TotalMilliseconds);
            //Console.WriteLine("--------------------------------");
            //sw.Reset();
            //sw.Start();
            //encryptedData = AESGCM.SimpleEncryptWithPassword("Test1234", "Test4321", new byte[] { 255, 255 });
            //decryptedData = AESGCM.SimpleDecryptWithPassword(encryptedData, "Test4321", 2);

            //Console.WriteLine(encryptedData);
            //Console.WriteLine(decryptedData);
            //sw.Stop();

            //Console.WriteLine("Elapsed time: {0}", sw.Elapsed.TotalMilliseconds);
            //Console.WriteLine("--------------------------------");
            Console.Read();
            pinTinEdison.Dispose();

        }
    }
}
