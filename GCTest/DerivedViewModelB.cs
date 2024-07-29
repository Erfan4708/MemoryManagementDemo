using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class DerivedViewModelB : BaseViewModel
    {
        private bool _disposed = false;
        private string _additionalResourcesB;

        public DerivedViewModelB()
        {
            _additionalResourcesB = new string('B', 1000000); // Allocate some additional resources
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Release managed resources specific to DerivedViewModelB
                if (_additionalResourcesB != null)
                {
                    _additionalResourcesB = null;
                }
            }

            // Release unmanaged resources specific to DerivedViewModelB, if any

            _disposed = true;

            // Call the base class implementation
            base.Dispose(disposing);
        }
    }

}
