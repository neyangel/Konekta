using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class PhotoLeftDescriptionListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, PhotoLeftDescription1Schema> ViewModel { get; set; }

        public PhotoLeftDescriptionListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, PhotoLeftDescription1Schema>(new PhotoLeftDescriptionConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
