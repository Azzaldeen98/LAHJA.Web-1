using AutoMapper;
using Domain.Entities.Price.Request;
using Domain.Entities.Price.Response;
using Domain.ShareData.Base;
using Shared.Wrapper;
using LAHJA.ApplicationLayer.Price;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Client.Shared.Execution;
using AutoGenerator.Attributes;

namespace LAHJA.Data.UI.Templates.Price
{
    public class DataBuildPriceBase
    {
        public string Id { get; set; }
    }

    public interface IBuilderPriceComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task> SubmitSearch { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
    }

    public interface IBuilderPriceApi<T> : IBuilderApi<T>
    {
        Task<Result<List<PriceResponse>>> SearchAsync(T data);
        Task<Result<PriceResponse>> CreateAsync(T data);
        Task<Result<DeleteResponse>> DeleteAsync(T data);
        Task<Result<PriceResponse>> UpdateAsync(T data);
    }

    public abstract class BuilderPriceApi<T, E> : BuilderApi<T, E>, IBuilderPriceApi<E>
    {
        public BuilderPriceApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        public abstract Task<Result<PriceResponse>> CreateAsync(E data);
        public abstract Task<Result<DeleteResponse>> DeleteAsync(E dataId);
        public abstract Task<Result<List<PriceResponse>>> SearchAsync(E data);
        public abstract Task<Result<PriceResponse>> UpdateAsync(E data);
    }

    public class BuilderPriceComponent<T> : IBuilderPriceComponent<T>
    {
        public Func<T, Task> SubmitSearch { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
    }

    public class TemplatePriceShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderPriceApi<E> builderApi;
        private readonly IBuilderPriceComponent<E> builderComponents;
        public IBuilderPriceComponent<E> BuilderComponents { get => builderComponents; }

        public TemplatePriceShare(IMapper mapper, AuthService AuthService, T client, IBuilderPriceComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar) : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderPriceComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
        }
    }

    public class BuilderPriceApiClient : BuilderPriceApi<PriceClientService, DataBuildPriceBase>, IBuilderPriceApi<DataBuildPriceBase>
    {
        public BuilderPriceApiClient(IMapper mapper, PriceClientService service) : base(mapper, service)
        {
        }

        public override async Task<Result<PriceResponse>> CreateAsync(DataBuildPriceBase data)
        {
            var model = Mapper.Map<PriceCreate>(data);
            var res = await Service.CreateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<PriceResponse>(res.Data);
                    return Result<PriceResponse>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<PriceResponse>.Fail();
                }
            }
            else
            {
                return Result<PriceResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<DeleteResponse>> DeleteAsync(DataBuildPriceBase data)
        {
            var res = await Service.DeleteAsync(data.Id);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<DeleteResponse>(res.Data);
                    return Result<DeleteResponse>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<DeleteResponse>.Fail();
                }
            }
            else
            {
                return Result<DeleteResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<PriceResponse>>> SearchAsync(DataBuildPriceBase data)
        {
            var model = Mapper.Map<PriceSearchOptionsRequest>(data);
            var res = await Service.SearchAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<PriceResponse>>(res.Data);
                    return Result<List<PriceResponse>>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<List<PriceResponse>>.Fail();
                }
            }
            else
            {
                return Result<List<PriceResponse>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<PriceResponse>> UpdateAsync(DataBuildPriceBase data)
        {
            var model = Mapper.Map<PriceUpdate>(data);
            var res = await Service.UpdateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<PriceResponse>(res.Data);
                    return Result<PriceResponse>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<PriceResponse>.Fail();
                }
            }
            else
            {
                return Result<PriceResponse>.Fail(res.Messages);
            }
        }
    }

    [AutoSafeInvoke]
    public class TemplatePrice : TemplatePriceShare<PriceClientService, DataBuildPriceBase>
    {
        private readonly ISafeInvoker safeInvoker;
        private List<PriceResponse> _prices = new List<PriceResponse>();
        public TemplatePrice(IMapper mapper, AuthService AuthService, PriceClientService client, IBuilderPriceComponent<DataBuildPriceBase> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safeInvoker) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitCreate = OnSubmitCreatePrice;
            this.BuilderComponents.SubmitUpdate = OnSubmitUpdatePrice;
            this.BuilderComponents.SubmitDelete = OnSubmitDeletePrice;
            this.BuilderComponents.SubmitSearch = OnSubmitSearch;
            this.builderApi = new BuilderPriceApiClient(mapper, client);
            this.safeInvoker = safeInvoker;
        }

        public List<PriceResponse> Prices { get => _prices; }
        public List<string> Errors { get => _errors; }

        private async Task OnSubmitDeletePrice(DataBuildPriceBase dataBuildPriceBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildPriceBase != null)
                {
                    var response = await builderApi.DeleteAsync(dataBuildPriceBase);
                    if (response.Succeeded)
                    {
                    }
                    else
                    {
                        _errors = response.Messages;
                    }
                }
            });
        }

        private async Task OnSubmitCreatePrice(DataBuildPriceBase dataBuildPriceBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildPriceBase != null)
                {
                    var response = await builderApi.CreateAsync(dataBuildPriceBase);
                    if (response.Succeeded)
                    {
                    }
                    else
                    {
                        _errors = response.Messages;
                    }
                }
            });
        }

        private async Task OnSubmitUpdatePrice(DataBuildPriceBase dataBuildPriceBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildPriceBase != null)
                {
                    var response = await builderApi.UpdateAsync(dataBuildPriceBase);
                    if (response.Succeeded)
                    {
                    }
                    else
                    {
                        _errors = response.Messages;
                    }
                }
            });
        }

        private async Task OnSubmitSearch(DataBuildPriceBase dataBuildPriceBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildPriceBase != null)
                {
                    var response = await builderApi.SearchAsync(dataBuildPriceBase);
                    if (response.Succeeded)
                    {
                        _prices = response.Data;
                    }
                    else
                    {
                        _errors = response.Messages;
                    }
                }
            });
        }
    }
}