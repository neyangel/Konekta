using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class BigPicturesListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, BigPictures1Schema> ViewModel { get; set; }

        public BigPicturesListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, BigPictures1Schema>(new BigPicturesConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
