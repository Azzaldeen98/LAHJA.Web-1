namespace Infrastructure.DataSource.Seeds
{
    using Domain.Entities.Service.Request;
    using Domain.ShareData.Base;
    using Domain.ShareData.Enums;
    using Infrastructure.Repository.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SeedsServiceAiModelsData
    {
        private List<QueryRequestTextToSpeech> models;

        public SeedsServiceAiModelsData()
        {
            models = new List<QueryRequestTextToSpeech>
        {
            new QueryRequestTextToSpeech
            {
                Id = "1",
                ModelID = "model_001",
                ModelName = "Arabic Gulf Dialect Model",
                Key = "key_001",
                ServiceType = ServiceModelType.Text2Speech,
                TagId = "Tag001",
                TypeSound = GenderType.Male,
                LahjaType = new LahjaTypeModel
                {
                    Id = "lahja_001",
                    Name = "Gulf Arabic",
                    Description = "Supports Gulf Arabic dialect",
                    Language = "ar"
                },
                Headers = new AiModelHeader
                {
                    Authorization = "Bearer token_001",
                    ContentType = "application/json"
                }
            },
            new QueryRequestTextToSpeech
            {
                Id = "2",
                ModelID = "model_002",
                ModelName = "English US Model",
                Key = "key_002",
                ServiceType = ServiceModelType.Text2Speech,
                TagId = "Tag002",
                TypeSound = GenderType.Famele,
                LahjaType = new LahjaTypeModel
                {
                    Id = "lahja_002",
                    Name = "US English",
                    Description = "Supports US English accent",
                    Language = "en"
                },
                Headers = new AiModelHeader
                {
                    Authorization = "Bearer token_002",
                    ContentType = "application/json"
                }
            },
            new QueryRequestTextToSpeech
            {
                Id = "3",
                ModelID = "model_003",
                ModelName = "French Parisian Model",
                Key = "key_003",
                ServiceType = ServiceModelType.Text2Speech,
                TagId = "Tag003",
                TypeSound = GenderType.Male,
                LahjaType = new LahjaTypeModel
                {
                    Id = "lahja_003",
                    Name = "Parisian French",
                    Description = "Supports Parisian French accent",
                    Language = "fr"
                },
                Headers = new AiModelHeader
                {
                    Authorization = "Bearer token_003",
                    ContentType = "application/json"
                }
            }
        };
        }

        public void AddModel(QueryRequestTextToSpeech model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            models.Add(model);
        }

        public bool UpdateModel(string id, QueryRequestTextToSpeech updatedModel)
        {
            var model = models.FirstOrDefault(m => m.Id == id);
            if (model == null)
                return false;

            model.Id = updatedModel.Id;
            model.ModelID = updatedModel.ModelID;
            model.ModelName = updatedModel.ModelName;
            model.Key = updatedModel.Key;
            model.ServiceType = updatedModel.ServiceType;
            model.TagId = updatedModel.TagId;
            model.TypeSound = updatedModel.TypeSound;
            model.LahjaType = updatedModel.LahjaType;
            model.Headers = updatedModel.Headers;

            return true;
        }

        public bool DeleteModel(string id)
        {
            var model = models.FirstOrDefault(m => m.Id == id);
            if (model == null)
                return false;

            models.Remove(model);
            return true;
        }

        public List<QueryRequestTextToSpeech> SearchModels(Func<QueryRequestTextToSpeech, bool> predicate)
        {
            return models.Where(predicate).ToList();
        }

        public List<QueryRequestTextToSpeech> GetAllModels()
        {
            return new List<QueryRequestTextToSpeech>(models);
        }
    }

}
