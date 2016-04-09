using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Flickr;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views

{
    public sealed partial class FlickrDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;
        public DetailViewModel<FlickrDataConfig, FlickrSchema> ViewModel { get; set; }

        public FlickrDetailPage()
        {
            this.ViewModel = new DetailViewModel<FlickrDataConfig, FlickrSchema>(new FlickrConfig());
            this.InitializeComponent();            
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            bool supportsHtml = true;
#if WINDOWS_PHONE_APP
            supportsHtml = false;
#endif
            ViewModel.ShareContent(args.Request, supportsHtml);
        }
    }
}
