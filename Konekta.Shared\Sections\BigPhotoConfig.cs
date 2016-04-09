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
    public class BigPhotoConfig : SectionConfigBase<DynamicStorageDataConfig, BigPhoto1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, BigPhoto1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<BigPhoto1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=62cb60e6-e142-4d8a-ad11-3f252cead06e&appId=b0730124-f888-45f1-86d6-45253b6f7f44"),
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
                return NavigationInfo.FromPage("BigPhotoListPage");
            }
        }

        public override ListPageConfig<BigPhoto1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<BigPhoto1Schema>
                {
                    Title = "Big Photo",

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

        public override DetailPageConfig<BigPhoto1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, BigPhoto1Schema>>();

				var actions = new List<ActionConfig<BigPhoto1Schema>>
				{
				};

                return new DetailPageConfig<BigPhoto1Schema>
                {
                    Title = "Big Photo",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Big Photo"; }
        }

    }
}
