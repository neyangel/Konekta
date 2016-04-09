using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Bing;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class BingListPage : PageBase
    {
        public ListViewModel<BingDataConfig, BingSchema> ViewModel { get; set; }

        public BingListPage()
        {
            this.ViewModel = new ListViewModel<BingDataConfig, BingSchema>(new BingConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
