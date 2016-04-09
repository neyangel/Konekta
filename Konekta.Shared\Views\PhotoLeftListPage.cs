using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class PhotoLeftListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, PhotoLeft1Schema> ViewModel { get; set; }

        public PhotoLeftListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, PhotoLeft1Schema>(new PhotoLeftConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
