using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class HorizontalCardsListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, HorizontalCards1Schema> ViewModel { get; set; }

        public HorizontalCardsListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, HorizontalCards1Schema>(new HorizontalCardsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
