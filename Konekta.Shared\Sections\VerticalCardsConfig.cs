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
    public class VerticalCardsConfig : SectionConfigBase<DynamicStorageDataConfig, VerticalCards1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, VerticalCards1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<VerticalCards1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=ed5c38fa-594b-4560-8aa7-71ac1669908a&appId=b0730124-f888-45f1-86d6-45253b6f7f44"),
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
                return NavigationInfo.FromPage("VerticalCardsListPage");
            }
        }

        public override ListPageConfig<VerticalCards1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<VerticalCards1Schema>
                {
                    Title = "Vertical Cards",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Name.ToSafeString();
                        viewModel.SubTitle = item.Surname.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.Thumbnail.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return null;
                    }
                };
            }
        }

        public override DetailPageConfig<VerticalCards1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, VerticalCards1Schema>>();

				var actions = new List<ActionConfig<VerticalCards1Schema>>
				{
				};

                return new DetailPageConfig<VerticalCards1Schema>
                {
                    Title = "Vertical Cards",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Vertical Cards"; }
        }

    }
}
