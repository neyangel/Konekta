using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class BigPhotoListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, BigPhoto1Schema> ViewModel { get; set; }

        public BigPhotoListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, BigPhoto1Schema>(new BigPhotoConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
