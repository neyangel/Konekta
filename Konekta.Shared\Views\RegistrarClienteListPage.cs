using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using Konekta;
using Konekta.Sections;
using Konekta.ViewModels;

namespace Konekta.Views
{
    public sealed partial class RegistrarClienteListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, RegistrarCliente1Schema> ViewModel { get; set; }

        public RegistrarClienteListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, RegistrarCliente1Schema>(new RegistrarClienteConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
