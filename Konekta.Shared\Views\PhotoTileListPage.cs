using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class PhotoTileListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, PhotoTile1Schema> ViewModel { get; set; }

        public PhotoTileListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, PhotoTile1Schema>(new PhotoTileConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
