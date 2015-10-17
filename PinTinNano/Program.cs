using PinTin.Commons.Models;
using PinTin.Core;
using PinTin.Core.Helper;
using PinTin.Core.Storage;
using PinTin.Core.Storage.Interfaces;
using PinTin.Edison;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        static Database database = new Database();
        static int menuSelection;

        static void Main(string[] args)
        {
            IStorage xmlStorage = new XmlStorage();
            PinTinEdison pinTinEdison = new PinTinEdison();
            
            pinTinEdison.CallBegin();
            
            Console.WriteLine("Welcome to the PinTin");
            Console.WriteLine("Enter your password.");

            //pinTinEdison.CallDisplayTimeoutMessage("Hi :)", 2000);

            //Check, if there is a safe already available
            if (!xmlStorage.IsSafeAvailable())
            {
                while (noNewPassword)
                {
                    //Ask the user for a new Password
                    //pinTinEdison.CallDisplayOkMessage("Please enter a new password.");

                    //Get the new Passwort
                    password = SecureStringHelper.MakeStringSecure(pinTinEdison.CallGetUserTextInput("Enter:"));

                    //TODO: Add compare call and some logic
                    noNewPassword = false;
                }
                pinTinEdison.CallDisplayMessage("Creating...");
                xmlStorage.Save(database, password);
                pinTinEdison.CallDisplayOkMessage("Created.");
            }
            else
            {
                //Get the Passwort
                password = SecureStringHelper.MakeStringSecure(pinTinEdison.CallGetUserTextInput("Password:"));
                try
                {
                    pinTinEdison.CallDisplayMessage("Loading...");
                    database = xmlStorage.Load(password);
                    pinTinEdison.CallDisplayOkMessage("Loaded.");
                }
                catch(Exception ex)
                {
                    Console.Write(ex.Message);
                    pinTinEdison.CallDisplayOkMessage("Wrong Password. Exiting...");
                    pinTinEdison.CallClearDisplay();
                    Environment.Exit(0);
                }
            }
            Console.WriteLine(SecureStringHelper.MakeInsecure(password));

            //We're done with init. Let's get the party started.
            do
            {
                menuSelection = pinTinEdison.CallMenu();

                switch (menuSelection)
                {
                    //List the entries
                    case 0:
                        Console.WriteLine("List");
                        if (database.Entries.Count != 0)
                        {
                            pinTinEdison.CallDisplayOkMessage(database.Entries[0].Title);
                        }
                        else
                        {
                            pinTinEdison.CallDisplayOkMessage("Empty...");
                        }

                        break;

                    //Find an entry
                    case 1:
                        Console.WriteLine("Find");
                        break;

                    //Create new entry
                    case 2:
                        Console.WriteLine("New");
                        Entry entry = new Entry();
                        entry.Title = pinTinEdison.CallGetUserTextInput("Title");
                        entry.Uri = pinTinEdison.CallGetUserTextInput("Uri");
                        entry.Username = pinTinEdison.CallGetUserTextInput("Username");
                        entry.Password = pinTinEdison.CallGetUserTextInput("Password");
                        entry.Note = pinTinEdison.CallGetUserTextInput("Note");
                        database.Entries.Add(entry);
                        pinTinEdison.CallDisplayMessage("Storing...");
                        xmlStorage.Save(database, password);
                        pinTinEdison.CallDisplayOkMessage("Stored!");
                        break;

                    //Edit entry
                    case 3:
                        Console.WriteLine("Edit");
                        break;

                    //Edit entry
                    case 4:
                        Console.WriteLine("Delete");
                        break;
                }

            } while (menuSelection < 5);

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
