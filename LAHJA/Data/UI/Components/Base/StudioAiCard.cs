using Domain.ShareData;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Data.UI.Templates.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace LAHJA.Data.UI.Components.StudioLahjaAiVM
{
    public enum TypeStudioAiService
    {
        T2T,
        T2Speech,
        VoiceBot,
        Chat,

  
    }
    public interface IStyleCardStudioAi : IStyleBaseComponentCard
    {
        public string? ClassCategory { set; get; }

    }
    public class StudioAiCard<T> : ComponentBaseCard<T>, IStyleCardStudioAi
    {

     
        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public IManageLanguageService manageLanguageService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }

        public override TypeComponentCard Type => TypeComponentCard.Base;

        public string? ClassCategory { get; set; }



        public string CurrentLanguage { get; set; } = "ar";


       
        public TypeStudioAiService TypeStudioAiService {  get; set; }

        

        public override void Build(T db)
        {
            DataBuild = db;
        }

     
    }
}
