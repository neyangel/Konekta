using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class PhotoListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, Photo1Schema> ViewModel { get; set; }

        public PhotoListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, Photo1Schema>(new PhotoConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
