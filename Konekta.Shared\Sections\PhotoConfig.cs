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
    public class PhotoConfig : SectionConfigBase<DynamicStorageDataConfig, Photo1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, Photo1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<Photo1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=bb2a95d1-25f1-43b8-ae6d-2d495716c6be&appId=b0730124-f888-45f1-86d6-45253b6f7f44"),
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
                return NavigationInfo.FromPage("PhotoListPage");
            }
        }

        public override ListPageConfig<Photo1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Photo1Schema>
                {
                    Title = "Photo",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = "";
                        viewModel.SubTitle = "";
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

        public override DetailPageConfig<Photo1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Photo1Schema>>();

				var actions = new List<ActionConfig<Photo1Schema>>
				{
				};

                return new DetailPageConfig<Photo1Schema>
                {
                    Title = "Photo",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Photo"; }
        }

    }
}
