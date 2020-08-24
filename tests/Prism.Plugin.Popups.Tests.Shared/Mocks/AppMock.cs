﻿using Prism.Ioc;
using Prism.Plugin.Popups.Tests.Mocks.Views;
using Prism.Navigation;
using Xamarin.Forms;
using Prism.Logging;
using Prism.Common;
#if AUTOFAC
using Prism.Autofac;
#elif DRYIOC
using Prism.DryIoc;
#elif UNITY
using Prism.Unity;
#endif

namespace Prism.Plugin.Popups.Tests.Mocks
{
    public class AppMock : PrismApplication
    {
        public AppMock(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {

        }

        protected override async void OnInitialized()
        {
            //var result = await NavigationService.NavigateAsync("MainPage");
            //if(!result.Success)
            //{
            //    Container.Resolve<ILoggerFacade>().Log(result.Exception.ToString(), Category.Exception, Priority.High);
            //}
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<PopupPageMock>();
        }

        public INavigationService GetNavigationService(Page page = null)
        {
            if(NavigationService is IPageAware pa)
            {
                pa.Page = page ?? MainPage;
            }

            return NavigationService;
        }
    }
}
