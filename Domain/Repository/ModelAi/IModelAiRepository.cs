using Domain.Entities.ModelAi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.ModelAi
{
    public interface IModelAiRepository
    {

            Task<ICollection<ModelAiResponseEntity>> GetModelsByCategoryAsync(string category);
            Task<ModelAiResponseEntity> GetModelAiAsync(string id);
            Task<ItemEntity> GetStartStudioAsync(string lg);
            Task<ICollection<ValueFilterModelEntity>> GetValueFilterServiceAsync(string lg);
            Task<ModelPropertyValuesEntity> GetSettingModelAiAsync(string lg);
            Task<IDictionary<string, object>> GetModelChatStudioAsync(string lg);
            Task<ICollection<ModelAiResponseEntity>> GetModelsAiAsync();
            Task<ICollection<ModelAiResponseEntity>> GetModelsByDialectAsync(string dialect);
            Task<ICollection<ModelAiResponseEntity>> GetModelsByGenderAsync(string gender);
            Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageAsync(string lg);
            Task<ICollection<ModelAiResponseEntity>> GetModelsByIsStandardAsync(string isStandard);
            Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageAndDialectAsync(string language, string dialect);
            Task<ICollection<ModelAiResponseEntity>> GetModelsByTypeAndGenderAsync(string type, string gender);
            Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageDialectTypeAsync(string language, string dialect, string type);
            Task<IDictionary<string, object>> GetModelSpeechStudioAsync(string lg);
            Task<IDictionary<string, object>> GetModelTextStudioAsync(string lg);
        

    }
}
