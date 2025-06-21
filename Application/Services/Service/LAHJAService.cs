using Application.UseCase.Service;
using Domain.Entities.Event.Request;
using Domain.Entities.Event.Response;
using Domain.Entities.Service.Request;
using Domain.Entities.Service.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;


namespace Application.Service.Service
{
    public class LAHJAService
    {
        private readonly GetAllServicesUseCase getAllServicesUseCase;
        private readonly GetServiceByIdUseCase getServiceByIdUseCase;
        private readonly CreateServiceUseCase createServiceUseCase;
        private readonly UpdateServiceUseCase updateServiceUseCase;
        private readonly DeleteServiceUseCase deleteServiceUseCase;

        public LAHJAService(
            GetAllServicesUseCase getAllServicesUseCase,
            GetServiceByIdUseCase getServiceByIdUseCase,
            CreateServiceUseCase createServiceUseCase,
            UpdateServiceUseCase updateServiceUseCase,
            DeleteServiceUseCase deleteServiceUseCase)
        {
            this.getAllServicesUseCase = getAllServicesUseCase;
            this.getServiceByIdUseCase = getServiceByIdUseCase;
            this.createServiceUseCase = createServiceUseCase;
            this.updateServiceUseCase = updateServiceUseCase;
            this.deleteServiceUseCase = deleteServiceUseCase;
        }

        public async Task<Result<List<ServiceResponse>>> GetAllAsync()
        {
            return await getAllServicesUseCase.ExecuteAsync();
        }

        public async Task<Result<ServiceResponse>> GetOneAsync(string id)
        {
            return await getServiceByIdUseCase.ExecuteAsync(id);
        }

        public async Task<Result<ServiceResponse>> CreateAsync(ServiceRequest request)
        {
            return await createServiceUseCase.ExecuteAsync(request);
        }

        public async Task<Result<ServiceResponse>> UpdateAsync(ServiceRequest request)
        {
            return await updateServiceUseCase.ExecuteAsync(request);
        }

        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await deleteServiceUseCase.ExecuteAsync(id);
        }

        public async Task<Result<EventResponse>> CreateEventAsync(EventRequest request)
        {
            throw new NotImplementedException();

            //return await voiceBotService.TextToSpeechAsync(request);
        }
        public async Task<Result<ServiceResponse>> ResultRequestAsync(ResultRequest request)
        {
            throw new NotImplementedException();
            //return await voiceBotService.TextToSpeechAsync(request);
        }
    }
}
