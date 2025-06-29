using AutoMapper;
using Domain.Entities.Product.Request;
using Domain.Entities.Product.Response;
using Domain.ShareData.Base;
using Shared.Wrapper;
using LAHJA.ApplicationLayer.Product;
using LAHJA.ApplicationLayer.Product;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Data.UI.Templates.Product;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using Client.Shared.Execution;
using AutoGenerator.Attributes;

namespace LAHJA.Data.UI.Templates.Product
{
    public class DataBuildProductBase
    {
        public string Id { get; set; }
    }

    public interface IBuilderProductComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task> SubmitSearch { get; set; }
        public Func<T, Task> SubmitGetAll { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
    }

    public interface IBuilderProductApi<T> : IBuilderApi<T>
    {
        Task<Result<List<ProductResponse>>> SearchAsync(T data);
        Task<Result<List<ProductResponse>>> GetAllAsync(T filter);
        Task<Result<ProductResponse>> CreateAsync(T data);
        Task<Result<DeleteResponse>> DeleteAsync(T data);
        Task<Result<ProductResponse>> UpdateAsync(T data);
    }

    public abstract class BuilderProductApi<T, E> : BuilderApi<T, E>, IBuilderProductApi<E>
    {
        public BuilderProductApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        public abstract Task<Result<ProductResponse>> CreateAsync(E data);
        public abstract Task<Result<DeleteResponse>> DeleteAsync(E dataId);
        public abstract Task<Result<List<ProductResponse>>> GetAllAsync(E filter);
        public abstract Task<Result<List<ProductResponse>>> SearchAsync(E data);
        public abstract Task<Result<ProductResponse>> UpdateAsync(E data);
    }

    public class BuilderProductComponent<T> : IBuilderProductComponent<T>
    {
        public Func<T, Task> SubmitSearch { get; set; }
        public Func<T, Task> SubmitGetAll { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
    }

    public class TemplateProductShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderProductApi<E> builderApi;
        private readonly IBuilderProductComponent<E> builderComponents;
        public TemplateProductShare(IMapper mapper, AuthService AuthService, T client, IBuilderProductComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar) : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderProductComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
        }

        public IBuilderProductComponent<E> BuilderComponents { get => builderComponents; }
    }

    public class BuilderProductApiClient : BuilderProductApi<ProductClientService, DataBuildProductBase>, IBuilderProductApi<DataBuildProductBase>
    {
        public BuilderProductApiClient(IMapper mapper, ProductClientService service) : base(mapper, service)
        {
        }

        public override async Task<Result<ProductResponse>> CreateAsync(DataBuildProductBase data)
        {
            var model = Mapper.Map<ProductCreate>(data);
            var res = await Service.CreateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<ProductResponse>(res.Data);
                    return Result<ProductResponse>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<ProductResponse>.Fail();
                }
            }
            else
            {
                return Result<ProductResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<DeleteResponse>> DeleteAsync(DataBuildProductBase data)
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

        public override async Task<Result<List<ProductResponse>>> GetAllAsync(DataBuildProductBase filter)
        {
            var model = Mapper.Map<FilterResponseData>(filter);
            var res = await Service.GetAllAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<ProductResponse>>(res.Data);
                    return Result<List<ProductResponse>>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<List<ProductResponse>>.Fail();
                }
            }
            else
            {
                return Result<List<ProductResponse>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<ProductResponse>>> SearchAsync(DataBuildProductBase data)
        {
            var model = Mapper.Map<ProductSearchRequest>(data);
            var res = await Service.SearchAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<ProductResponse>>(res.Data);
                    return Result<List<ProductResponse>>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<List<ProductResponse>>.Fail();
                }
            }
            else
            {
                return Result<List<ProductResponse>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<ProductResponse>> UpdateAsync(DataBuildProductBase data)
        {
            var model = Mapper.Map<ProductUpdate>(data);
            var res = await Service.UpdateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<ProductResponse>(res.Data);
                    return Result<ProductResponse>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<ProductResponse>.Fail();
                }
            }
            else
            {
                return Result<ProductResponse>.Fail(res.Messages);
            }
        }
    }

    [AutoSafeInvoke]
    public class TemplateProduct : TemplateProductShare<ProductClientService, DataBuildProductBase>
    {
        private readonly ISafeInvoker safeInvoker;
        private List<ProductResponse> _products = new List<ProductResponse>();
        public TemplateProduct(IMapper mapper, AuthService AuthService, ProductClientService client, IBuilderProductComponent<DataBuildProductBase> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safeInvoker) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitCreate = OnSubmitCreateProduct;
            this.BuilderComponents.SubmitUpdate = OnSubmitUpdateProduct;
            this.BuilderComponents.SubmitGetAll = OnSubmitGetAllProducts;
            this.BuilderComponents.SubmitDelete = OnSubmitDeleteProduct;
            this.BuilderComponents.SubmitSearch = OnSubmitSearch;
            this.builderApi = new BuilderProductApiClient(mapper, client);
            this.safeInvoker = safeInvoker;
        }

        public List<ProductResponse> Products { get => _products; }
        public List<string> Errors { get => _errors; }

        private async Task OnSubmitDeleteProduct(DataBuildProductBase dataBuildProductBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildProductBase != null)
                {
                    var response = await builderApi.DeleteAsync(dataBuildProductBase);
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

        private async Task OnSubmitCreateProduct(DataBuildProductBase dataBuildProductBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildProductBase != null)
                {
                    var response = await builderApi.CreateAsync(dataBuildProductBase);
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

        private async Task OnSubmitUpdateProduct(DataBuildProductBase dataBuildProductBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildProductBase != null)
                {
                    var response = await builderApi.UpdateAsync(dataBuildProductBase);
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

        private async Task OnSubmitGetAllProducts(DataBuildProductBase dataBuildProductBase)
        {
            await safeInvoker.InvokeAsync(async () =>
            {
                if (dataBuildProductBase != null)
                {
                    var response = await builderApi.GetAllAsync(dataBuildProductBase);
                    if (response.Succeeded)
                    {
                        _products = response.Data;
                    }
                    else
                    {
                        _errors = response.Messages;
                    }
                }
            });
        }

        private async Task<Result<List<ProductResponse>>> OnSubmitSearch(DataBuildProductBase dataBuildProductBase)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                var response = await builderApi.SearchAsync(dataBuildProductBase);
                return response;
            });
        }
    }
}