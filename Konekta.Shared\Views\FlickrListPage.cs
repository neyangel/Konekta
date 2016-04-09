using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Flickr;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class FlickrListPage : PageBase
    {
        public ListViewModel<FlickrDataConfig, FlickrSchema> ViewModel { get; set; }

        public FlickrListPage()
        {
            this.ViewModel = new ListViewModel<FlickrDataConfig, FlickrSchema>(new FlickrConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
