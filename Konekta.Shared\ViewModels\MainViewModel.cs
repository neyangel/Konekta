using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.Menu;
using AppStudio.DataProviders.LocalStorage;
using Konekta.Sections;


namespace Konekta.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            PageTitle = "Konekta";
            Inicio = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new InicioConfig(), visibleItems);
            Opciones = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new OpcionesConfig());
            ListLayouts = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new ListLayoutsConfig());
            Datasources = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new DatasourcesConfig());
            Opciones1 = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new Opciones1Config());
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Inicio { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> Opciones { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> ListLayouts { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> Datasources { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> Opciones1 { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return Inicio;
            yield return Opciones;
            yield return ListLayouts;
            yield return Datasources;
            yield return Opciones1;
        }
    }
}
