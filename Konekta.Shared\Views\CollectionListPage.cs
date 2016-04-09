using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class CollectionListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, Collection1Schema> ViewModel { get; set; }

        public CollectionListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, Collection1Schema>(new CollectionConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
