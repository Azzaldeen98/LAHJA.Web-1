//using AutoMapper;
//using Domain.ShareData.Base;
// using Shared.Wrapper;
//using LAHJA.Data.UI.Templates.Base;
//using LAHJA.Helpers.Services;
//using Microsoft.AspNetCore.Components;
//using MudBlazor;


//namespace LAHJA.Data.UI.Templates.StudioAi
//{

//    public class DataBuildStudioAiBase
//    {
//        public string Id { get; set; }
//    }




//    public interface IBuilderStudioAiComponent<T> : IBuilderComponents<T>
//    {




//        public Func<T, Task> SubmitText2Text { get; set; }
//        public Func<T, Task> SubmitText2Speech { get; set; }
//        public Func<T, Task> SubmitVoiceBot { get; set; }


//    }

//    public interface IBuilderStudioAiApi<T> : IBuilderApi<T>
//    {





//        Task<Result<DeleteResponse>> DeleteAsync(T data);



//    }

//    public abstract class BuilderStudioAiApi<T, E> : BuilderApi<T, E>, IBuilderStudioAiApi<E>
//    {

//        public BuilderStudioAiApi(IMapper mapper, T service) : base(mapper, service)
//        {

//        }

//        public abstract Task<Result<StudioAiResponse>> Text2TextAsync(E data);



//    }
//    public class BuilderStudioAiComponent<T> : IBuilderStudioAiComponent<T>
//    {


//        public Func<T, Task> SubmitText2Text { get; set; }
//        public Func<T, Task> SubmitText2Speech { get; set; }
//        public Func<T, Task> SubmitVoiceBot { get; set; }



//    }


//    public class TemplateStudioAiShare<T, E> : TemplateBase<T, E>
//    {
//        protected readonly NavigationManager navigation;
//        protected readonly IDialogService dialogService;
//        protected readonly ISnackbar Snackbar;
//        protected IBuilderStudioAiApi<E> builderApi;
//        private readonly IBuilderStudioAiComponent<E> builderComponents;
//        public IBuilderStudioAiComponent<E> BuilderComponents { get => builderComponents; }
//        public TemplateStudioAiShare(

//               IMapper mapper,
//               AuthService AuthService,
//                T client,
//                IBuilderStudioAiComponent<E> builderComponents,
//                NavigationManager navigation,
//                IDialogService dialogService,
//                ISnackbar snackbar


//            ) : base(mapper, AuthService, client)
//        {



//            builderComponents = new BuilderStudioAiComponent<E>();
//            this.navigation = navigation;
//            this.dialogService = dialogService;
//            this.Snackbar = snackbar;
//            //this.builderApi = builderApi;
//            this.builderComponents = builderComponents;


//        }

//    }


//    public class BuilderStudioAiApiClient : BuilderStudioAiApi<StudioAiClient, DataBuildStudioAiBase>, IBuilderStudioAiApi<DataBuildStudioAiBase>
//    {
//        public BuilderStudioAiApiClient(IMapper mapper, StudioAiClientService service) : base(mapper, service)
//        {

//        }

//        public override async Task<Result<StudioAiResponse>> CreateAsync(DataBuildStudioAiBase data)
//        {
//            var model = Mapper.Map<StudioAiCreate>(data);
//            var res = await Service.CreateAsync(model);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<StudioAiResponse>(res.Data);
//                    return Result<StudioAiResponse>.Success(map);

//                }
//                catch (Exception e)
//                {
//                    return Result<StudioAiResponse>.Fail();
//                }
//            }
//            else
//            {
//                return Result<StudioAiResponse>.Fail(res.Messages);
//            }
//        }

//        public override async Task<Result<DeleteResponse>> DeleteAsync(DataBuildStudioAiBase data)
//        {

//            var res = await Service.DeleteAsync(data.Id);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<DeleteResponse>(res.Data);
//                    return Result<DeleteResponse>.Success(map);

//                }
//                catch (Exception e)
//                {
//                    return Result<DeleteResponse>.Fail();
//                }
//            }
//            else
//            {
//                return Result<DeleteResponse>.Fail(res.Messages);
//            }
//        }



//        public override async Task<Result<List<StudioAiResponse>>> SearchAsync(DataBuildStudioAiBase data)
//        {
//            var model = Mapper.Map<StudioAiSearchOptionsRequest>(data);
//            var res = await Service.SearchAsync(model);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<List<StudioAiResponse>>(res.Data);
//                    return Result<List<StudioAiResponse>>.Success(map);

//                }
//                catch (Exception e)
//                {
//                    return Result<List<StudioAiResponse>>.Fail();
//                }
//            }
//            else
//            {
//                return Result<List<StudioAiResponse>>.Fail(res.Messages);
//            }
//        }

//        public override async Task<Result<StudioAiResponse>> UpdateAsync(DataBuildStudioAiBase data)
//        {
//            var model = Mapper.Map<StudioAiUpdate>(data);
//            var res = await Service.UpdateAsync(model);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<StudioAiResponse>(res.Data);
//                    return Result<StudioAiResponse>.Success(map);

//                }
//                catch (Exception e)
//                {
//                    return Result<StudioAiResponse>.Fail();
//                }
//            }
//            else
//            {
//                return Result<StudioAiResponse>.Fail(res.Messages);
//            }
//        }
//    }


//    public class TemplateStudioAi : TemplateStudioAiShare<StudioAiClientService, DataBuildStudioAiBase>
//    {

//        public List<StudioAiResponse> StudioAis { get => _StudioAis; }

//        public List<string> Errors { get => _errors; }



//        private List<StudioAiResponse> _StudioAis = new List<StudioAiResponse>();

//        public TemplateStudioAi(
//            IMapper mapper,
//            AuthService AuthService,
//            StudioAiClientService client,
//            IBuilderStudioAiComponent<DataBuildStudioAiBase> builderComponents,
//            NavigationManager navigation,
//            IDialogService dialogService,
//            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
//        {
//            this.BuilderComponents.SubmitCreate = OnSubmitCreateStudioAi;
//            this.BuilderComponents.SubmitUpdate = OnSubmitUpdateStudioAi;
//            this.BuilderComponents.SubmitDelete = OnSubmitDeleteStudioAi;
//            this.BuilderComponents.SubmitSearch = OnSubmitSearch;


//            this.builderApi = new BuilderStudioAiApiClient(mapper, client);



//        }





//        private async Task OnSubmitDeleteStudioAi(DataBuildStudioAiBase dataBuildStudioAiBase)
//        {

//            if (dataBuildStudioAiBase != null)
//            {
//                var response = await builderApi.DeleteAsync(dataBuildStudioAiBase);
//                if (response.Succeeded)
//                {

//                }
//                else
//                {
//                    _errors = response.Messages;
//                }
//            }

//        }
//        private async Task OnSubmitCreateStudioAi(DataBuildStudioAiBase dataBuildStudioAiBase)
//        {

//            if (dataBuildStudioAiBase != null)
//            {
//                var response = await builderApi.CreateAsync(dataBuildStudioAiBase);
//                if (response.Succeeded)
//                {

//                }
//                else
//                {
//                    _errors = response.Messages;
//                }
//            }

//        }

//        private async Task OnSubmitUpdateStudioAi(DataBuildStudioAiBase dataBuildStudioAiBase)
//        {

//            if (dataBuildStudioAiBase != null)
//            {
//                var response = await builderApi.UpdateAsync(dataBuildStudioAiBase);
//                if (response.Succeeded)
//                {

//                }
//                else
//                {
//                    _errors = response.Messages;
//                }
//            }

//        }


//        private async Task OnSubmitSearch(DataBuildStudioAiBase dataBuildStudioAiBase)
//        {
//            if (dataBuildStudioAiBase != null)
//            {
//                var response = await builderApi.SearchAsync(dataBuildStudioAiBase);
//                if (response.Succeeded)
//                {
//                    _StudioAis = response.Data;
//                }
//                else
//                {
//                    _errors = response.Messages;
//                }
//            }
//        }


//    }



//}


