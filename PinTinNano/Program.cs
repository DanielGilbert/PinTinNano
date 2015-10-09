using PinTin.Core;
using PinTin.Edison;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinTinNano
{
    class Program
    {
        static void Main(string[] args)
        {
            PinTinEdison wrapper = new PinTinEdison();
            wrapper.CallBegin();
            wrapper.Dispose();
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


        }
    }
}
