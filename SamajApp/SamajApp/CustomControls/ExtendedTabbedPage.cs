using System;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Forms;

namespace SamajApp.CustomControls
{
    public class ExtendedTabbedPage : TabbedPage
    {
        public INavigationService NavigationService
        {
            get { return (INavigationService)GetValue(NavigationServiceProperty); }
            set { SetValue(NavigationServiceProperty, value); }
        }

        public static readonly BindableProperty NavigationServiceProperty =
                   BindableProperty.CreateAttached(
                       nameof(NavigationService),
                       typeof(INavigationService),
                       typeof(ExtendedTabbedPage),
                       default(INavigationService),
                       propertyChanged: null);

        public NavigationParameters Parameters
        {
            get { return (NavigationParameters)GetValue(ParametersProperty); }
            set { SetValue(ParametersProperty, value); }
        }

        public static readonly BindableProperty ParametersProperty =
            BindableProperty.CreateAttached(
                        nameof(Parameters),
                typeof(NavigationParameters),
                typeof(ExtendedTabbedPage),
                default(NavigationParameters),
                propertyChanged: onParametersChanged);

        private static void onParametersChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ExtendedTabbedPage view = bindable as ExtendedTabbedPage;
        }

        public IList<ContentPage> Pages
        {
            get { return (IList<ContentPage>)GetValue(PagesProperty); }
            set { SetValue(PagesProperty, value); }
        }

        public static readonly BindableProperty PagesProperty =
                   BindableProperty.CreateAttached(
                       nameof(Pages),
                typeof(IList<ContentPage>),
                       typeof(ExtendedTabbedPage),
                       default(IList<ContentPage>),
                       propertyChanged: onPagesChanged);

        private static void onPagesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ExtendedTabbedPage view = bindable as ExtendedTabbedPage;
            view.Children.Clear();
            IList<ContentPage> items = newValue as IList<ContentPage>;
            if (items != null)
            {
                view.SetupTabs();
            }
        }

        private void SetupTabs()
        {
            if (Pages.Count > 5)
            {
                for (int i = 0; i < 4; i++)
                {

                    this.Children.Add(Pages[i]);
                }
                List<ContentPage> morePages = new List<ContentPage>();
                for (int i = 4; i < Pages.Count; i++)
                {
                    morePages.Add(Pages[i]);
                }
                //MoreTabPage morePage = new MoreTabPage();
                //TabViewModel vm = morePage.BindingContext as TabViewModel;
                //vm.ParentVM = BindingContext as TabContainerViewModel;
                //morePage.NavigationService = NavigationService;
                //morePage.NavigationService = vm.ParentVM.NavigationService;
                //morePage.Parameters = Parameters;
                //morePage.ItemsSource = morePages;
                //this.Children.Add(morePage);
            }
            else
            {
                foreach (var page in Pages)
                {
                    this.Children.Add(page);
                }
            }
        }
        public ExtendedTabbedPage()
        {
        }
    }
}
