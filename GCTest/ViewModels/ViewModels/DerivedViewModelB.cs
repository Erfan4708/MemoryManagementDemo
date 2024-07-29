namespace GCTest.ViewModels.ViewModels
{
    public class DerivedViewModelB : BaseViewModel
    {
        #region Variables
        private bool _disposed = false;
        private string _additionalResourcesB;
        #endregion

        #region Constructors
        public DerivedViewModelB()
        {
            _additionalResourcesB = new string('B', 1000000); // Allocate some additional resources
        }
        #endregion

        #region Methods
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
        #endregion
    }
}
