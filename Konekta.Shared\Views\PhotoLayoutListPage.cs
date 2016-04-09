using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class PhotoLayoutListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, PhotoLayout1Schema> ViewModel { get; set; }

        public PhotoLayoutListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, PhotoLayout1Schema>(new PhotoLayoutConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
