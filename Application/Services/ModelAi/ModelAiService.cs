using Application.UseCase.ModelAi;
using Domain.Entities.ModelAi;
 using Shared.Wrapper;

namespace Application.Service.ModelAi
{

    public class ModelAiService
        {
            private readonly GetModelsByCategoryUseCase _getModelsByCategoryUseCase;
            private readonly GetModelAiUseCase _getModelAiUseCase;
            private readonly GetStartStudioUseCase _getStartStudioUseCase;
            private readonly GetValueFilterServiceUseCase _getValueFilterServiceUseCase;
            private readonly GetSettingModelAiUseCase _getSettingModelAiUseCase;
            private readonly GetModelChatStudioUseCase _getModelChatStudioUseCase;
            private readonly GetModelsAiUseCase _getModelsAiUseCase;
            private readonly GetModelsByDialectUseCase _getModelsByDialectUseCase;
            private readonly GetModelsByGenderUseCase _getModelsByGenderUseCase;
            private readonly GetModelsByLanguageUseCase _getModelsByLanguageUseCase;
            private readonly GetModelsByIsStandardUseCase _getModelsByIsStandardUseCase;
            private readonly GetModelsByLanguageAndDialectUseCase _getModelsByLanguageAndDialectUseCase;
            private readonly GetModelsByTypeAndGenderUseCase _getModelsByTypeAndGenderUseCase;
            private readonly GetModelsByLanguageDialectTypeUseCase _getModelsByLanguageDialectTypeUseCase;
            private readonly GetModelSpeechStudioUseCase _getModelSpeechStudioUseCase;
            private readonly GetModelTextStudioUseCase _getModelTextStudioUseCase;

            public ModelAiService(
                GetModelsByCategoryUseCase getModelsByCategoryUseCase,
                GetModelAiUseCase getModelAiUseCase,
                GetStartStudioUseCase getStartStudioUseCase,
                GetValueFilterServiceUseCase getValueFilterServiceUseCase,
                GetSettingModelAiUseCase getSettingModelAiUseCase,
                GetModelChatStudioUseCase getModelChatStudioUseCase,
                GetModelsAiUseCase getModelsAiUseCase,
                GetModelsByDialectUseCase getModelsByDialectUseCase,
                GetModelsByGenderUseCase getModelsByGenderUseCase,
                GetModelsByLanguageUseCase getModelsByLanguageUseCase,
                GetModelsByIsStandardUseCase getModelsByIsStandardUseCase,
                GetModelsByLanguageAndDialectUseCase getModelsByLanguageAndDialectUseCase,
                GetModelsByTypeAndGenderUseCase getModelsByTypeAndGenderUseCase,
                GetModelsByLanguageDialectTypeUseCase getModelsByLanguageDialectTypeUseCase,
                GetModelSpeechStudioUseCase getModelSpeechStudioUseCase,
                GetModelTextStudioUseCase getModelTextStudioUseCase)
            {
                _getModelsByCategoryUseCase = getModelsByCategoryUseCase;
                _getModelAiUseCase = getModelAiUseCase;
                _getStartStudioUseCase = getStartStudioUseCase;
                _getValueFilterServiceUseCase = getValueFilterServiceUseCase;
                _getSettingModelAiUseCase = getSettingModelAiUseCase;
                _getModelChatStudioUseCase = getModelChatStudioUseCase;
                _getModelsAiUseCase = getModelsAiUseCase;
                _getModelsByDialectUseCase = getModelsByDialectUseCase;
                _getModelsByGenderUseCase = getModelsByGenderUseCase;
                _getModelsByLanguageUseCase = getModelsByLanguageUseCase;
                _getModelsByIsStandardUseCase = getModelsByIsStandardUseCase;
                _getModelsByLanguageAndDialectUseCase = getModelsByLanguageAndDialectUseCase;
                _getModelsByTypeAndGenderUseCase = getModelsByTypeAndGenderUseCase;
                _getModelsByLanguageDialectTypeUseCase = getModelsByLanguageDialectTypeUseCase;
                _getModelSpeechStudioUseCase = getModelSpeechStudioUseCase;
                _getModelTextStudioUseCase = getModelTextStudioUseCase;
            }

            // وظيفة استدعاء UseCase GetModelsByCategory
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByCategoryAsync(string category)
            {
                return await _getModelsByCategoryUseCase.ExecuteAsync(category);
            }

            // وظيفة استدعاء UseCase GetModelAi
            public async Task<Result<ModelAiResponseEntity>> GetModelAiAsync(string id)
            {
                return await _getModelAiUseCase.ExecuteAsync(id);
            }

            // وظيفة استدعاء UseCase GetStartStudio
            public async Task<Result<ItemEntity>> GetStartStudioAsync(string lg)
            {
                return await _getStartStudioUseCase.ExecuteAsync(lg);
            }

            // وظيفة استدعاء UseCase GetValueFilterService
            public async Task<Result<ICollection<ValueFilterModelEntity>>> GetValueFilterServiceAsync(string lg)
            {
                return await _getValueFilterServiceUseCase.ExecuteAsync(lg);
            }

            // وظيفة استدعاء UseCase GetSettingModelAi
            public async Task<Result<ModelPropertyValuesEntity>> GetSettingModelAiAsync(string lg)
            {
                return await _getSettingModelAiUseCase.ExecuteAsync(lg);
            }

            // وظيفة استدعاء UseCase GetModelChatStudio
            public async Task<Result<IDictionary<string, object>>> GetModelChatStudioAsync(string lg)
            {
                return await _getModelChatStudioUseCase.ExecuteAsync(lg);
            }

            // وظيفة استدعاء UseCase GetModelsAi
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsAiAsync()
            {
                return await _getModelsAiUseCase.ExecuteAsync();
            }

            // وظيفة استدعاء UseCase GetModelsByDialect
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByDialectAsync(string dialect)
            {
                return await _getModelsByDialectUseCase.ExecuteAsync(dialect);
            }

            // وظيفة استدعاء UseCase GetModelsByGender
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByGenderAsync(string gender)
            {
                return await _getModelsByGenderUseCase.ExecuteAsync(gender);
            }

            // وظيفة استدعاء UseCase GetModelsByLanguage
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAsync(string lg)
            {
                return await _getModelsByLanguageUseCase.ExecuteAsync(lg);
            }

            // وظيفة استدعاء UseCase GetModelsByIsStandard
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByIsStandardAsync(string isStandard)
            {
                return await _getModelsByIsStandardUseCase.ExecuteAsync(isStandard);
            }

            // وظيفة استدعاء UseCase GetModelsByLanguageAndDialect
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAndDialectAsync(string language, string dialect)
            {
                return await _getModelsByLanguageAndDialectUseCase.ExecuteAsync(language, dialect);
            }

            // وظيفة استدعاء UseCase GetModelsByTypeAndGender
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByTypeAndGenderAsync(string type, string gender)
            {
                return await _getModelsByTypeAndGenderUseCase.ExecuteAsync(type, gender);
            }

            // وظيفة استدعاء UseCase GetModelsByLanguageDialectType
            public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageDialectTypeAsync(string language, string dialect, string type)
            {
                return await _getModelsByLanguageDialectTypeUseCase.ExecuteAsync(language, dialect, type);
            }

            // وظيفة استدعاء UseCase GetModelSpeechStudio
            public async Task<Result<IDictionary<string, object>>> GetModelSpeechStudioAsync(string lg)
            {
                return await _getModelSpeechStudioUseCase.ExecuteAsync(lg);
            }

            // وظيفة استدعاء UseCase GetModelTextStudio
            public async Task<Result<IDictionary<string, object>>> GetModelTextStudioAsync(string lg)
            {
                return await _getModelTextStudioUseCase.ExecuteAsync(lg);
            }
        }

    }
