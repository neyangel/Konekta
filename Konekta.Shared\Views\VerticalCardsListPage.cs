using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class VerticalCardsListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, VerticalCards1Schema> ViewModel { get; set; }

        public VerticalCardsListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, VerticalCards1Schema>(new VerticalCardsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
