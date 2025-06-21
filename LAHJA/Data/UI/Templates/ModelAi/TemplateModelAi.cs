using AutoMapper;
using Domain.Entities.ModelAi;
using Shared.Wrapper;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using LAHJA.ApplicationLayer.ModelAi;
using LAHJA.Data.UI.Models.ModelAi;
using LAHJA.Data.UI.Components.ServiceCard;
using Client.Shared.Execution;
using AutoGenerator.Config.Attributes;

namespace LAHJA.Data.UI.Templates.ModelAi
{
    public interface IBuilderModelAiComponent<T>
    {
        Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByCategory { get; set; }

        Func<T, Task<Result<ModelAiResponse>>> GetModelAi { get; set; }

        Func<T, Task<Result<ItemEntity>>> GetStartStudio { get; set; }

        Func<T, Task<Result<ICollection<ValueFilterModelEntity>>>> GetValueFilterService { get; set; }

        Func<T, Task<Result<ModelPropertyValues>>> GetSettingModelAi { get; set; }

        Func<T, Task<Result<IDictionary<string, object>>>> GetModelChatStudio { get; set; }

        Func<Task<Result<ICollection<ModelAiResponse>>>> GetModelsAi { get; set; }

        Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByDialect { get; set; }

        Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByGender { get; set; }

        Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByLanguage { get; set; }

        Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByIsStandard { get; set; }

        Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByLanguageAndDialect { get; set; }

        Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByTypeAndGender { get; set; }

        Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByLanguageDialectType { get; set; }

        Func<T, Task<Result<IDictionary<string, object>>>> GetModelSpeechStudio { get; set; }

        Func<T, Task<Result<IDictionary<string, object>>>> GetModelTextStudio { get; set; }
    }

    public interface IBuilderModelAiApi<T>
    {
        Task<Result<ICollection<ModelAiResponse>>> GetModelsByCategoryAsync(T dataBuild);
        Task<Result<ModelAiResponse>> GetModelAiAsync(T dataBuild);
        Task<Result<ItemEntity>> GetStartStudioAsync(T dataBuild);
        Task<Result<ICollection<ValueFilterModelEntity>>> GetValueFilterServiceAsync(T dataBuild);
        Task<Result<ModelPropertyValues>> GetSettingModelAiAsync(T dataBuild);
        Task<Result<IDictionary<string, object>>> GetModelChatStudioAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponse>>> GetModelsAiAsync();
        Task<Result<ICollection<ModelAiResponse>>> GetModelsByDialectAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponse>>> GetModelsByGenderAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponse>>> GetModelsByIsStandardAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageAndDialectAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponse>>> GetModelsByTypeAndGenderAsync(T dataBuild);
        Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageDialectTypeAsync(T dataBuild);
        Task<Result<IDictionary<string, object>>> GetModelSpeechStudioAsync(T dataBuild);
        Task<Result<IDictionary<string, object>>> GetModelTextStudioAsync(T dataBuild);
    }

    public abstract class BuilderModelAiApi<T, E> : BuilderApi<T, E>, IBuilderModelAiApi<E>
    {
        public BuilderModelAiApi(IMapper mapper, T service) : base(mapper, service)
        {
        }

        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsByCategoryAsync(E dataBuild);
        public abstract Task<Result<ModelAiResponse>> GetModelAiAsync(E dataBuild);
        public abstract Task<Result<ItemEntity>> GetStartStudioAsync(E dataBuild);
        public abstract Task<Result<ICollection<ValueFilterModelEntity>>> GetValueFilterServiceAsync(E dataBuild);
        public abstract Task<Result<ModelPropertyValues>> GetSettingModelAiAsync(E dataBuild);
        public abstract Task<Result<IDictionary<string, object>>> GetModelChatStudioAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsAiAsync();
        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsByDialectAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsByGenderAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsByIsStandardAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageAndDialectAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsByTypeAndGenderAsync(E dataBuild);
        public abstract Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageDialectTypeAsync(E dataBuild);
        public abstract Task<Result<IDictionary<string, object>>> GetModelSpeechStudioAsync(E dataBuild);
        public abstract Task<Result<IDictionary<string, object>>> GetModelTextStudioAsync(E dataBuild);
    }

    public class BuilderModelAiComponent<T> : IBuilderModelAiComponent<T>
    {
        public Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByCategory { get; set; }
        public Func<T, Task<Result<ModelAiResponse>>> GetModelAi { get; set; }
        public Func<T, Task<Result<ItemEntity>>> GetStartStudio { get; set; }
        public Func<T, Task<Result<ICollection<ValueFilterModelEntity>>>> GetValueFilterService { get; set; }
        public Func<T, Task<Result<ModelPropertyValues>>> GetSettingModelAi { get; set; }
        public Func<T, Task<Result<IDictionary<string, object>>>> GetModelChatStudio { get; set; }
        public Func<Task<Result<ICollection<ModelAiResponse>>>> GetModelsAi { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByDialect { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByGender { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByLanguage { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByIsStandard { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByLanguageAndDialect { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByTypeAndGender { get; set; }
        public Func<T, Task<Result<ICollection<ModelAiResponse>>>> GetModelsByLanguageDialectType { get; set; }
        public Func<T, Task<Result<IDictionary<string, object>>>> GetModelSpeechStudio { get; set; }
        public Func<T, Task<Result<IDictionary<string, object>>>> GetModelTextStudio { get; set; }
    }

    public class TemplateModelAiShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderModelAiApi<E> builderApi;
        private readonly IBuilderModelAiComponent<E> builderComponents;
        public IBuilderModelAiComponent<E> BuilderComponents { get => builderComponents; }

        public TemplateModelAiShare(IMapper mapper, AuthService AuthService, T client, IBuilderModelAiComponent<E> builderComponents, NavigationManager navigation, IDialogService dialogService, ISnackbar snackbar) : base(mapper, AuthService, client)
        {
            builderComponents = new BuilderModelAiComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            this.builderComponents = builderComponents;
        }
    }

    public class BuilderModelAiApiClient : BuilderModelAiApi<ModelAiClientService, DataBuildModelAi>, IBuilderModelAiApi<DataBuildModelAi>
    {
        public BuilderModelAiApiClient(IMapper mapper, ModelAiClientService service) : base(mapper, service)
        {
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsByCategoryAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelsByCategoryAsync(dataBuild.Category);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ModelAiResponse>> GetModelAiAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelAiAsync(dataBuild.Id);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ModelAiResponse>(response.Data);
                return Result<ModelAiResponse>.Success(mData);
            }
            else
            {
                return Result<ModelAiResponse>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ItemEntity>> GetStartStudioAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetStartStudioAsync(dataBuild.Language);
        }

        public override async Task<Result<ICollection<ValueFilterModelEntity>>> GetValueFilterServiceAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetValueFilterServiceAsync(dataBuild.Language);
        }

        public override async Task<Result<ModelPropertyValues>> GetSettingModelAiAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetSettingModelAiAsync(dataBuild.Language);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ModelPropertyValues>(response.Data);
                return Result<ModelPropertyValues>.Success(mData);
            }
            else
            {
                return Result<ModelPropertyValues>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<IDictionary<string, object>>> GetModelChatStudioAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelChatStudioAsync(dataBuild.Language);
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsAiAsync()
        {
            var response = await Service.GetModelsAiAsync();
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsByDialectAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelsByDialectAsync(dataBuild.Dialect);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsByGenderAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelsByGenderAsync(dataBuild.Gender);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelsByLanguageAsync(dataBuild.Language);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsByIsStandardAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelsByIsStandardAsync(dataBuild.IsStandard);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageAndDialectAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelsByLanguageAndDialectAsync(dataBuild.Language, dataBuild.Dialect);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsByTypeAndGenderAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelsByTypeAndGenderAsync(dataBuild.Type, dataBuild.Gender);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<ICollection<ModelAiResponse>>> GetModelsByLanguageDialectTypeAsync(DataBuildModelAi dataBuild)
        {
            var response = await Service.GetModelsByLanguageDialectTypeAsync(dataBuild.Language, dataBuild.Dialect, dataBuild.Type);
            if (response.Succeeded)
            {
                var mData = Mapper.Map<ICollection<ModelAiResponse>>(response.Data);
                return Result<ICollection<ModelAiResponse>>.Success(mData);
            }
            else
            {
                return Result<ICollection<ModelAiResponse>>.Fail(response.Messages, response.HttpCode);
            }
        }

        public override async Task<Result<IDictionary<string, object>>> GetModelSpeechStudioAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelSpeechStudioAsync(dataBuild.Language);
        }

        public override async Task<Result<IDictionary<string, object>>> GetModelTextStudioAsync(DataBuildModelAi dataBuild)
        {
            return await Service.GetModelTextStudioAsync(dataBuild.Language);
        }
    }

    [AutoSafeInvoke]
    public class TemplateModelAi : TemplateBase<ModelAiClientService, DataBuildModelAi>
    {
        private readonly ISafeInvoker safeInvoker;
        private readonly IBuilderModelAiApi<DataBuildModelAi> _builderApi;
        private readonly IBuilderModelAiComponent<DataBuildModelAi> _builderComponents;
        public TemplateModelAi(IMapper mapper, ModelAiClientService client, AuthService authService, IBuilderModelAiComponent<DataBuildModelAi> builderComponents, IBuilderModelAiApi<DataBuildModelAi> builderApi, ISafeInvoker safeInvoker) : base(mapper, authService, client)
        {
            _builderApi = builderApi;
            _builderComponents = builderComponents;
            // ربط الوظائف من ModelAiApiClient مع الوظائف في BuilderComponents
            _builderComponents.GetModelsByCategory = OnGetModelsByCategoryAsync;
            _builderComponents.GetModelAi = OnGetModelAiAsync;
            _builderComponents.GetStartStudio = OnGetStartStudioAsync;
            _builderComponents.GetValueFilterService = OnGetValueFilterServiceAsync;
            _builderComponents.GetSettingModelAi = OnGetSettingModelAiAsync;
            _builderComponents.GetModelChatStudio = OnGetModelChatStudioAsync;
            _builderComponents.GetModelsAi = OnGetModelsAiAsync;
            _builderComponents.GetModelsByDialect = OnGetModelsByDialectAsync;
            _builderComponents.GetModelsByGender = OnGetModelsByGenderAsync;
            _builderComponents.GetModelsByLanguage = OnGetModelsByLanguageAsync;
            _builderComponents.GetModelsByIsStandard = OnGetModelsByIsStandardAsync;
            _builderComponents.GetModelsByLanguageAndDialect = OnGetModelsByLanguageAndDialectAsync;
            _builderComponents.GetModelsByTypeAndGender = OnGetModelsByTypeAndGenderAsync;
            _builderComponents.GetModelsByLanguageDialectType = OnGetModelsByLanguageDialectTypeAsync;
            _builderComponents.GetModelSpeechStudio = OnGetModelSpeechStudioAsync;
            _builderComponents.GetModelTextStudio = OnGetModelTextStudioAsync;
            this.safeInvoker = safeInvoker;
        }

        public IBuilderModelAiComponent<DataBuildModelAi> BuilderComponents => _builderComponents;

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsByCategoryAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsByCategoryAsync(dataBuild);
            });
        }

        private async Task<Result<ModelAiResponse>> OnGetModelAiAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelAiAsync(dataBuild);
            });
        }

        private async Task<Result<ItemEntity>> OnGetStartStudioAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetStartStudioAsync(dataBuild);
            });
        }

        private async Task<Result<ICollection<ValueFilterModelEntity>>> OnGetValueFilterServiceAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetValueFilterServiceAsync(dataBuild);
            });
        }

        private async Task<Result<ModelPropertyValues>> OnGetSettingModelAiAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetSettingModelAiAsync(dataBuild);
            });
        }

        private async Task<Result<IDictionary<string, object>>> OnGetModelChatStudioAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelChatStudioAsync(dataBuild);
            });
        }

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsAiAsync()
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsAiAsync();
            });
        }

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsByDialectAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsByDialectAsync(dataBuild);
            });
        }

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsByGenderAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsByGenderAsync(dataBuild);
            });
        }

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsByLanguageAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsByLanguageAsync(dataBuild);
            });
        }

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsByIsStandardAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsByIsStandardAsync(dataBuild);
            });
        }

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsByLanguageAndDialectAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsByLanguageAndDialectAsync(dataBuild);
            });
        }

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsByTypeAndGenderAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsByTypeAndGenderAsync(dataBuild);
            });
        }

        private async Task<Result<ICollection<ModelAiResponse>>> OnGetModelsByLanguageDialectTypeAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelsByLanguageDialectTypeAsync(dataBuild);
            });
        }

        private async Task<Result<IDictionary<string, object>>> OnGetModelSpeechStudioAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelSpeechStudioAsync(dataBuild);
            });
        }

        private async Task<Result<IDictionary<string, object>>> OnGetModelTextStudioAsync(DataBuildModelAi dataBuild)
        {
            return await safeInvoker.InvokeAsync(async () =>
            {
                return await _builderApi.GetModelTextStudioAsync(dataBuild);
            });
        }
    }
}