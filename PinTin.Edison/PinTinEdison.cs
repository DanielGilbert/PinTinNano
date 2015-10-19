using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PinTin.Edison
{
    public class PinTinEdison : IDisposable
    {
        #region PInvokes
        [DllImport("pintin_display")]
        static private extern IntPtr CreatePinTinDisplay();

        [DllImport("pintin_display")]
        static private extern void DisposePinTinDisplay(IntPtr pPinTinDisplay);

        [DllImport("pintin_display")]
        static private extern void CallBegin(IntPtr pTestClassObject);

        [DllImport("pintin_display", CharSet = CharSet.Ansi)]
        static private extern string CallGetUserTextInput(IntPtr pPinTinDisplay, string title);

        [DllImport("pintin_display")]
        static private extern int CallMenu(IntPtr pTestClassObject);

        [DllImport("pintin_display", CharSet = CharSet.Ansi)]
        static private extern void CallDisplayOkMessage(IntPtr m_pNativeObject, string message);

        [DllImport("pintin_display", CharSet = CharSet.Ansi)]
        static private extern void CallDisplayMessage(IntPtr m_pNativeObject, string message);

        [DllImport("pintin_display")]
        static private extern void CallClearDisplay(IntPtr m_pNativeObject);

        [DllImport("pintin_display")]
        static private extern int CallDisplayEntries(IntPtr m_pNativeObject, string[] entries, int count);

        [DllImport("pintin_display", CharSet = CharSet.Ansi)]
        static private extern int CallDisplayEntry(IntPtr m_pNativeObject, string uri, string username, string password, string note);

        public void CallDisplayTimeoutMessage(string v1, int v2)
        {
            throw new NotImplementedException();
        }

        //[DllImport("ExampleUnmanagedDLL.dll", CharSet = CharSet.Ansi)]
        //static private extern void CallPassString(IntPtr pTestClassObject, string strValue);

        //[DllImport("ExampleUnmanagedDLL.dll", CharSet = CharSet.Ansi)]
        //static private extern string CallReturnString(IntPtr pTestClassObject);
        #endregion PInvokes

        #region Members
        private IntPtr m_pNativeObject;     // Variable to hold the C++ class's this pointer
        #endregion Members

        public PinTinEdison()
        {
            // We have to Create an instance of this class through an exported function
            this.m_pNativeObject = CreatePinTinDisplay();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            if (this.m_pNativeObject != IntPtr.Zero)
            {
                // Call the DLL Export to dispose this class
                DisposePinTinDisplay(this.m_pNativeObject);
                this.m_pNativeObject = IntPtr.Zero;
            }

            if (bDisposing)
            {
                // No need to call the finalizer since we've now cleaned
                // up the unmanaged memory
                GC.SuppressFinalize(this);
            }
        }

        // This finalizer is called when Garbage collection occurs, but only if
        // the IDisposable.Dispose method wasn't already called.
        ~PinTinEdison()
        {
            Dispose(false);
        }

        #region Wrapper methods
        public void CallBegin()
        {
            CallBegin(this.m_pNativeObject);
        }

        public string CallGetUserTextInput(string title)
        {
            return CallGetUserTextInput(this.m_pNativeObject, title);
        }

        public int CallDisplayEntry(string uri, string username, string password, string note)
        {
            return CallDisplayEntry(this.m_pNativeObject, uri, username, password, note);
        }

        public int CallMenu()
        {
            return CallMenu(this.m_pNativeObject);
        }

        public void CallDisplayOkMessage(string message)
        {
            CallDisplayOkMessage(this.m_pNativeObject, message);
        }

        public void CallDisplayMessage(string message)
        {
            CallDisplayMessage(this.m_pNativeObject, message);
        }

        public void CallClearDisplay()
        {
            CallClearDisplay(this.m_pNativeObject);
        }

        public int CallDisplayEntries(string[] entries, int count)
        {
            return CallDisplayEntries(this.m_pNativeObject, entries, count);
        }
        #endregion Wrapper methods
    }
}
