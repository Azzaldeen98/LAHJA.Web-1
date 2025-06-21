using Application.Service.ModelAi;
using Domain.Entities.ModelAi;
 using Shared.Wrapper;

namespace LAHJA.ApplicationLayer.ModelAi
{
    public class ModelAiClientService
    {
        private readonly ModelAiService _modelAiService;

        public ModelAiClientService(ModelAiService modelAiService)
        {
            _modelAiService = modelAiService;
        }

        // دالة لاستدعاء GetModelsByCategoryAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByCategoryAsync(string category)
        {
            return await _modelAiService.GetModelsByCategoryAsync(category);
        }

        // دالة لاستدعاء GetModelAiAsync من ModelAiService
        public async Task<Result<ModelAiResponseEntity>> GetModelAiAsync(string id)
        {
            return await _modelAiService.GetModelAiAsync(id);
        }

        // دالة لاستدعاء GetStartStudioAsync من ModelAiService
        public async Task<Result<ItemEntity>> GetStartStudioAsync(string lg)
        {
            return await _modelAiService.GetStartStudioAsync(lg);
        }

        // دالة لاستدعاء GetValueFilterServiceAsync من ModelAiService
        public async Task<Result<ICollection<ValueFilterModelEntity>>> GetValueFilterServiceAsync(string lg)
        {
            return await _modelAiService.GetValueFilterServiceAsync(lg);
        }

        // دالة لاستدعاء GetSettingModelAiAsync من ModelAiService
        public async Task<Result<ModelPropertyValuesEntity>> GetSettingModelAiAsync(string lg)
        {
            return await _modelAiService.GetSettingModelAiAsync(lg);
        }

        // دالة لاستدعاء GetModelChatStudioAsync من ModelAiService
        public async Task<Result<IDictionary<string, object>>> GetModelChatStudioAsync(string lg)
        {
            return await _modelAiService.GetModelChatStudioAsync(lg);
        }

        // دالة لاستدعاء GetModelsAiAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsAiAsync()
        {
            return await _modelAiService.GetModelsAiAsync();
        }

        // دالة لاستدعاء GetModelsByDialectAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByDialectAsync(string dialect)
        {
            return await _modelAiService.GetModelsByDialectAsync(dialect);
        }

        // دالة لاستدعاء GetModelsByGenderAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByGenderAsync(string gender)
        {
            return await _modelAiService.GetModelsByGenderAsync(gender);
        }

        // دالة لاستدعاء GetModelsByLanguageAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAsync(string lg)
        {
            return await _modelAiService.GetModelsByLanguageAsync(lg);
        }

        // دالة لاستدعاء GetModelsByIsStandardAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByIsStandardAsync(string isStandard)
        {
            return await _modelAiService.GetModelsByIsStandardAsync(isStandard);
        }

        // دالة لاستدعاء GetModelsByLanguageAndDialectAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageAndDialectAsync(string language, string dialect)
        {
            return await _modelAiService.GetModelsByLanguageAndDialectAsync(language, dialect);
        }

        // دالة لاستدعاء GetModelsByTypeAndGenderAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByTypeAndGenderAsync(string type, string gender)
        {
            return await _modelAiService.GetModelsByTypeAndGenderAsync(type, gender);
        }

        // دالة لاستدعاء GetModelsByLanguageDialectTypeAsync من ModelAiService
        public async Task<Result<ICollection<ModelAiResponseEntity>>> GetModelsByLanguageDialectTypeAsync(string language, string dialect, string type)
        {
            return await _modelAiService.GetModelsByLanguageDialectTypeAsync(language, dialect, type);
        }

        // دالة لاستدعاء GetModelSpeechStudioAsync من ModelAiService
        public async Task<Result<IDictionary<string, object>>> GetModelSpeechStudioAsync(string lg)
        {
            return await _modelAiService.GetModelSpeechStudioAsync(lg);
        }

        // دالة لاستدعاء GetModelTextStudioAsync من ModelAiService
        public async Task<Result<IDictionary<string, object>>> GetModelTextStudioAsync(string lg)
        {
            return await _modelAiService.GetModelTextStudioAsync(lg);
        }
    }

}
