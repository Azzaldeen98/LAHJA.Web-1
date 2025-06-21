using AutoMapper;
using Client.Shared.UI.Services.Navigation;
using LAHJA.Helpers.Services;
using LAHJA.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Interfaces;

namespace LAHJA.Providers
{

    public interface ITemplateProvider 
    {
   
    }
    public interface IBaseTemplateProvider : ITemplateProvider
    {
       
    }

    public interface IShareTemplateProvider : IBaseTemplateProvider, ITScope
    {
        IMapper Mapper { get; }
        IDialogNotificationService DialogNotification { get; }
        INavigationService NavigationService { get; }
    }



   
    public class ShareTemplateProvider : IShareTemplateProvider
    {
        public IMapper Mapper { get=> _mapper; }
        public IDialogNotificationService DialogNotification { get=> _dialogNotification; }
        public INavigationService NavigationService { get=> _navigation; }


        private readonly IDialogNotificationService _dialogNotification;
        private readonly IMapper _mapper;
        private readonly INavigationService _navigation;


        public ShareTemplateProvider(IDialogNotificationService dialogNotification, IMapper mapper, INavigationService navigation)
        {
            _dialogNotification = dialogNotification;
            _mapper = mapper;
            _navigation = navigation;
        }
    }
}
