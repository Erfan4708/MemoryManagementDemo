using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class BaseViewModel : IDisposable
    {
        #region Variables
        private bool _disposed = false;

        // Example of a managed resource
        private byte[] _largeArray;
        #endregion

        #region Methods
        public void AllocateLargeArray(int sizeInMB)
        {
            _largeArray = new byte[sizeInMB * 1024 * 1024];
            new Random().NextBytes(_largeArray);
        } 
        #endregion

        #region IDisposable Implementation
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Release managed resources
                if (_largeArray != null)
                {
                    _largeArray = null;
                }
            }

            // Release unmanaged resources here, if any

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseViewModel()
        {
            Dispose(false);
        }
        #endregion
    }
}
