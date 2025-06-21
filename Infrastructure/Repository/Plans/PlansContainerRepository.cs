
using AutoMapper;
using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Infrastructure.DataSource.Seeds;
using Shared.Settings;

namespace Infrastructure.Repository.Plans
{
    public class PlansContainerRepository : IPlansContainerRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public PlansContainerRepository(
            IMapper mapper,
            SeedsPlans seedsPlans, 
            ApplicationModeService appModeService)
        {

            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;
        }



        public Task<IEnumerable<PlansContainerResponse>> getAllPlansContainerAsync()
        {
            throw new NotImplementedException();
        }



    }
}
