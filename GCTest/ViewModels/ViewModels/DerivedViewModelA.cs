namespace GCTest.ViewModels.ViewModels
{
    public class DerivedViewModelA : BaseViewModel
    {
        #region Variables
        private bool _disposed = false;
        private int[] _additionalResourcesA;
        #endregion

        #region Constructors
        public DerivedViewModelA()
        {
            _additionalResourcesA = new int[1000000]; // Allocate some additional resources
        }
        #endregion

        #region Methods
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
        #endregion
    }

}
