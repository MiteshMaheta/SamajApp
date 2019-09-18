using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace SamajApp.Views
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        public INavigationService NavigationService { get; set; }
        public IPageDialogService DialogService { get; set; }

        private string TempTitle;
        public string Title
        {
            get { return TempTitle; }
            set { SetProperty(ref TempTitle, value); }
        }
        

        public ViewModelBase(INavigationService navigationService, IPageDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        public virtual void Destroy()
        {
            
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
