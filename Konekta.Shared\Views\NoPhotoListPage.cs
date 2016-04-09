using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class NoPhotoListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, NoPhoto1Schema> ViewModel { get; set; }

        public NoPhotoListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, NoPhoto1Schema>(new NoPhotoConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
