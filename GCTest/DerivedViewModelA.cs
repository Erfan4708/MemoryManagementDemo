using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class DerivedViewModelA : BaseViewModel
    {
        private bool _disposed = false;
        private int[] _additionalResourcesA;

        public DerivedViewModelA()
        {
            _additionalResourcesA = new int[1000000]; // Allocate some additional resources
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Release managed resources specific to DerivedViewModelA
                if (_additionalResourcesA != null)
                {
                    _additionalResourcesA = null;
                }
            }

            // Release unmanaged resources specific to DerivedViewModelA, if any

            _disposed = true;

            // Call the base class implementation
            base.Dispose(disposing);
        }
    }

}
