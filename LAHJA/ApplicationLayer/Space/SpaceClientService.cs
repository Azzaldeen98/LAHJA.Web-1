using Application.UseCase.Request;
using Application.UseCase.Space;
using Domain.Entities.AuthorizationSession;
using Domain.Entities.Event.Request;
using Domain.Entities.Event.Response;
using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Entities.Service.Response;
using Domain.Entities.Space.Request;
 using Shared.Wrapper;


namespace Application.Service.Service
{
    public class SpaceClientService
    {
        private readonly SpaceService spaceService;

        public SpaceClientService(SpaceService spaceService)
        {
            this.spaceService = spaceService;
        }



        public async Task<Result<AuthorizationSessionWebResponse>> CreateSpaceAsync(SpaceRequest request)
        {
            return await spaceService.CreateSpaceAsync(request);
        }

        


    }
}
