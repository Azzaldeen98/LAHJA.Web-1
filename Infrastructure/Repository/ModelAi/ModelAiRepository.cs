using AutoMapper;
using Domain.Entities.ModelAi;
using Domain.Repository.ModelAi;
using Infrastructure.Core.Repositories.Base;
using Shared.Settings;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class ModelAiRepository : BaseRepository<ModelAiApiClient>, IModelAiRepository
    {

        public ModelAiRepository(IMapper mapper, ApplicationModeService appModeService,ModelAiApiClient apiClient) : base(mapper, appModeService, apiClient)
        {

        }

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByCategoryAsync(string category) =>
            await _apiClient.GetModelsByCategoryAsync(category);

        public async Task<ModelAiResponseEntity> GetModelAiAsync(string id) =>
            await _apiClient.GetModelAiAsync(id);

        public async Task<ItemEntity> GetStartStudioAsync(string lg) =>
            await _apiClient.GetStartStudioAsync(lg);

        public async Task<ICollection<ValueFilterModelEntity>> GetValueFilterServiceAsync(string lg) =>
            await _apiClient.GetValueFilterServiceAsync(lg);

        public async Task<ModelPropertyValuesEntity> GetSettingModelAiAsync(string lg) =>
            await _apiClient.GetSettingModelAiAsync(lg);

        public async Task<IDictionary<string, object>> GetModelChatStudioAsync(string lg) =>
            await _apiClient.GetModelChatStudioAsync(lg);

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsAiAsync() =>
            await _apiClient.GetModelsAiAsync();

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByDialectAsync(string dialect) =>
            await _apiClient.GetModelsByDialectAsync(dialect);

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByGenderAsync(string gender) =>
            await _apiClient.GetModelsByGenderAsync(gender);

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageAsync(string lg) =>
            await _apiClient.GetModelsByLanguageAsync(lg);

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByIsStandardAsync(string isStandard) =>
            await _apiClient.GetModelsByIsStandardAsync(isStandard);

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageAndDialectAsync(string language, string dialect) =>
            await _apiClient.GetModelsByLanguageAndDialectAsync(language, dialect);

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByTypeAndGenderAsync(string type, string gender) =>
            await _apiClient.GetModelsByTypeAndGenderAsync(type, gender);

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageDialectTypeAsync(string language, string dialect, string type) =>
            await _apiClient.GetModelsByLanguageDialectTypeAsync(language, dialect, type);

        public async Task<IDictionary<string, object>> GetModelSpeechStudioAsync(string lg) =>
            await _apiClient.GetModelSpeechStudioAsync(lg);

        public async Task<IDictionary<string, object>> GetModelTextStudioAsync(string lg) =>
            await _apiClient.GetModelTextStudioAsync(lg);



    }
}
