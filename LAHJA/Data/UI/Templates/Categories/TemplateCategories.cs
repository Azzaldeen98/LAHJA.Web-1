using AutoMapper;
using Domain.ShareData.Base;
using Shared.Wrapper;
using LAHJA.Data.UI.Components;
using LAHJA.Data.UI.Components.Category;
using LAHJA.Data.UI.Components.Plan;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Client.Shared.Execution;
using AutoGenerator.Attributes;
using LAHJA.ApplicationLayer.Plans;

namespace LAHJA.Data.UI.Templates.Categories
{
    public interface IBuilderCategoriesComponent<T> : IBuilderComponents<T>
    {

        public Func<Task<Result<List<CategoryComponent>>>> GetAllCategories { get; set; }

    }

    public class BuilderCategoriesComponent<T> : IBuilderCategoriesComponent<T>
    {

        public Func<Task<Result<List<CategoryComponent>>>> GetAllCategories { get; set; }

    }



    public interface IBuilderCategoriesApi<T> : IBuilderApi<T>
    {
        public Task<Result<List<CategoryComponent>>> GetAllCategories();

    }



    public abstract class BuilderCategoriesApi<T, E> : BuilderApi<T, E>, IBuilderCategoriesApi<E>
    {
        public BuilderCategoriesApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        public abstract Task<Result<List<CategoryComponent>>> GetAllCategories();
  
    }



    public class TemplateCategoriesShare<T, E> : TemplateBase<T, E>
    {

        protected IBuilderCategoriesApi<E> builderApi;
        private readonly IBuilderCategoriesComponent<E> builderComponents;
        public IBuilderCategoriesComponent<E> BuilderComponents { get => builderComponents; }

        public TemplateCategoriesShare(IMapper mapper, AuthService AuthService, T client, IBuilderCategoriesComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safelyHandler) 
            : base(mapper, AuthService, client, safelyHandler)
        {
            //builderComponents = new BuilderCategoriesComponent<E>();

            this.builderComponents = builderComponents;
        }
    }

    public class BuilderCategoriesApiClient : BuilderCategoriesApi<PlansClientService, object>, IBuilderCategoriesApi<object>
    {
        public BuilderCategoriesApiClient(IMapper mapper, PlansClientService service) : base(mapper, service)
        {
        }


        public override async Task<Result<List<CategoryComponent>>> GetAllCategories()
        {
            var res = await Service.GetCategories(new FilterResponseData());
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<CategoryComponent>>(res.Data);
                    return Result<List<CategoryComponent>>.Success(map);
                }
                catch (Exception e)
                {
                    return Result<List<CategoryComponent>>.Fail();
                }
            }
            else
            {
                return Result<List<CategoryComponent>>.Fail(res.Messages);
            }
        }
    }

    [AutoSafeInvoke]
    public class TemplateCategories : TemplateCategoriesShare<PlansClientService, object>
    {
        private readonly ISafeInvoker safeInvoker;
        private readonly TemplateCategories _self;
        private List<CategoryComponent> _categories = new List<CategoryComponent>();
        private List<PlanViewModel> _Categories = new List<PlanViewModel>();
        private List<PlanViewModel> _allCategories = new List<PlanViewModel>();
        private PlanViewModel _plan = new PlanViewModel();
        public TemplateCategories(IMapper mapper, AuthService AuthService, PlansClientService client, IBuilderCategoriesComponent<object> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar, ISafeInvoker safeInvoker, IServiceProvider provider) 
            : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar, safeInvoker)
        {
            this.safeInvoker = safeInvoker;
            builderComponents.GetAllCategories= GetAllCategoriesAsync;

            this.builderApi = new BuilderCategoriesApiClient(mapper, client);
         
        }


        private async Task<Result<List<CategoryComponent>>> GetAllCategoriesAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await builderApi.GetAllCategories();
            });
        }

       
    }
}