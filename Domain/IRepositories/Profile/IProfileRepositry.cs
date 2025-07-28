using AutoGenerator.Attributes;
using Domain.Entity;
using Shared.Interfaces;
using Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public  interface IProfileRepository : ITBaseShareRepository
    {
            [AutoMapper]
            public Task<User> GetUserAsync(CancellationToken cancellationToken);
            [AutoMapper]
            public Task UpdateAsync(User body, CancellationToken cancellationToken);
            [AutoMapper]
            public Task<PaginatedResult<Subscription>> GetUserSubscriptionsAsync(CancellationToken cancellationToken);
            [AutoMapper]
            [RouteTo("ModelAisAsync")]
            public Task<ICollection<ModelAi>> GetModelsAiAsync(CancellationToken cancellationToken);
            [AutoMapper]
            [RouteTo("ServicesAsync")]
            public Task<ICollection<Service>> GetServicesAsync(CancellationToken cancellationToken);
            [AutoMapper]
            [RouteTo("SpacesSubscriptionAsync")]
            public Task<ICollection<Space>> GetSpacesSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken);
            [AutoMapper]
            [RouteTo("SpaceSubscriptionAsync")]
            public Task<Space> GetSpaceSubscriptionAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken);
          
            public Task<PaginatedResult<Request>> RequestsSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken);

            public Task<PaginatedResult<Request>> RequestsServiceAsync(string serviceId, CancellationToken cancellationToken);

    }
}
