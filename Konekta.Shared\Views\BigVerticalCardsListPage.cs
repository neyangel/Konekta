using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class BigVerticalCardsListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, BigVerticalCards1Schema> ViewModel { get; set; }

        public BigVerticalCardsListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, BigVerticalCards1Schema>(new BigVerticalCardsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
