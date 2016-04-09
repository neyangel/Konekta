using System;
using System.Collections.Generic;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using Windows.Storage;
using Konekta.Config;
using Konekta.ViewModels;

namespace Konekta.Sections
{
    public class RegistrarClienteConfig : SectionConfigBase<DynamicStorageDataConfig, RegistrarCliente1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, RegistrarCliente1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<RegistrarCliente1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=6db1e7d0-5216-4519-8978-d51f1452f9f2&appId=b0730124-f888-45f1-86d6-45253b6f7f44"),
                    AppId = "b0730124-f888-45f1-86d6-45253b6f7f44",
                    StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                    DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("RegistrarClienteListPage");
            }
        }

        public override ListPageConfig<RegistrarCliente1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<RegistrarCliente1Schema>
                {
                    Title = "Registrar Cliente",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Name.ToSafeString();
                        viewModel.SubTitle = item.Surname.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.Thumbnail.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("RegistrarClienteDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<RegistrarCliente1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, RegistrarCliente1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Name.ToSafeString();
                    viewModel.Title = item.Surname.ToSafeString();
                    viewModel.Description = item.PersonalSummary.ToSafeString();
                    viewModel.Image = item.Image.ToSafeString();
                    viewModel.Content = null;
                });

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Other data";
                    viewModel.Title = "";
                    viewModel.Description = item.Other.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Detail";
                    viewModel.Title = item.Phone.ToSafeString();
                    viewModel.Description = item.Mail.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<RegistrarCliente1Schema>>
				{
                    ActionConfig<RegistrarCliente1Schema>.Mail("Mail", (item) => item.Mail.ToSafeString()),
                    ActionConfig<RegistrarCliente1Schema>.Phone("Phone", (item) => item.Phone.ToSafeString()),
				};

                return new DetailPageConfig<RegistrarCliente1Schema>
                {
                    Title = "Registrar Cliente",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Registrar Cliente"; }
        }

    }
}
