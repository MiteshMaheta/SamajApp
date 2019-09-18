using System;
using Prism.Navigation;
using Prism.Services;

namespace SamajApp.Views
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base (navigationService, dialogService)
        {
            Title = "Main Page";
        }
    }
}
