using AutoMapper;
using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Middlewares;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class ModelAiApiClient : BuildApiClient<ModelAiClient>
    {

        public ModelAiApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler)
            : base(clientFactory, mapper, config, apiSafelyHandler)
        {
        }

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsAiAsync()
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelAisAsync("ar");
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }
        public  async Task<ICollection<ModelAiResponseEntity>> GetModelsByCategoryAsync(string category)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelsByCategoryAsync(category);
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e) {

                throw new ServerException(e.Message,e.StatusCode);
            }
        }

        //public async Task<ModelAiResponseEntity> CreateModelAiAsync(ModelAiCreateEntity model)
        //{

        //    try
        //    {
        //        var client = await GetApiClient();
        //        var response = await client.CreateModelAiAsync(id);
        //        return _mapper.Map<ModelAiResponseEntity>(response);
        //    }
        //    catch (ApiException e)
        //    {

        //        throw new ServerException(e.Message, e.StatusCode);
        //    }
        //}


        //public async Task<ModelAiResponseEntity> UpdateModelAiAsync(ModelAiUpdateEntity model)
        //{

        //    try
        //    {
        //        var client = await GetApiClient();
        //        var response = await client.UpdateModelAiAsync(id);
        //        return _mapper.Map<ModelAiResponseEntity>(response);
        //    }
        //    catch (ApiException e)
        //    {

        //        throw new ServerException(e.Message, e.StatusCode);
        //    }
        //}

        public async Task<ModelAiResponseEntity> GetModelAiAsync(string id)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelAiAsync(id,"ar");
                return _mapper.Map<ModelAiResponseEntity>(response);

            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }

        public async Task<ItemEntity> GetStartStudioAsync(string lg)
        {

            try
            {
                var client = await GetApiClient();
                //var response = await client.GetStartStudioAsync(lg);
                //return _mapper.Map<ItemEntity>(response);
                return new ItemEntity();
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }
        }

        public async Task<ICollection<ValueFilterModelEntity>> GetValueFilterServiceAsync(string lg)
        {

            try
            {
                var client = await GetApiClient();
                //var response = await client.GetValueFilterServiceAsync(lg);
                //return _mapper.Map<ICollection<ValueFilterModelEntity>>(response);

                return new List<ValueFilterModelEntity>();
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }


        public async Task<ModelPropertyValuesEntity> GetSettingModelAiAsync(string lg)
        {

            try
            {
                var client = await GetApiClient();
                //var response = await client.GetSettingModelAiAsync(lg);
                //return _mapper.Map<ModelPropertyValuesEntity>(response);
                return new ModelPropertyValuesEntity();
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }
        }
        public async Task<IDictionary<string, object>> GetModelChatStudioAsync(string lg)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelAisAsync(lg);
                return _mapper.Map<IDictionary<string, object>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }


        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByDialectAsync(string dialect)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelsByCategoryAsync(dialect);
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }
        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByGenderAsync(string gender)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelAisAsync("en");
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageAsync(string lg)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelAisAsync(lg);
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }
        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByIsStandardAsync(string isStandard)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelsByTypeAsync(isStandard);
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }
        }

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageAndDialectAsync(string language, string dialect)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelAisAsync(language);
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByTypeAndGenderAsync(string type, string gender)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelsByTypeAsync(type);
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }

        public async Task<ICollection<ModelAiResponseEntity>> GetModelsByLanguageDialectTypeAsync(string language, string dialect,string type)
        {

            try
            {
                var client = await GetApiClient();
                //var response = await client.GetModelsByLanguageDialectTypeAsync(language, dialect,type);
                var response = await client.GetModelsByCategoryAsync(dialect);
                return _mapper.Map<ICollection<ModelAiResponseEntity>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }

        public async Task<IDictionary<string, object>> GetModelSpeechStudioAsync(string lg)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelAisAsync(lg);
                return _mapper.Map<IDictionary<string, object>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }

        public async Task<IDictionary<string, object>> GetModelTextStudioAsync(string lg)
        {

            try
            {
                var client = await GetApiClient();
                var response = await client.GetModelAisAsync(lg);
                return _mapper.Map<IDictionary<string, object>>(response);
            }
            catch (ApiException e)
            {

                throw new ServerException(e.Message, e.StatusCode);
            }
        }

       
    }
}
