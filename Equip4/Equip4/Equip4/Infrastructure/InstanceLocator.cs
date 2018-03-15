namespace Equip4.Infrastructure
{
    using ViewModels;
     class InstanceLocator
    {
        #region Properties
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel() ;
        }
        #endregion
    }
}
