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

        public string CallGetUserTextInput(string v)
        {
            return "";
        }

        public void CallDisplayOkMessage(string v)
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
        #endregion Wrapper methods
    }
}
