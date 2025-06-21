using Domain.ShareData.Base;

namespace Infrastructure.Models.Plans.Response
{
    public class PlansContainerModel : BaseProduct 
    {
            public string Id { get; set; }
            public string Name { get; set; }

            //public string Category { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }

            public List<PlanResponseModel>? plans { get; set; }
        
    }

}
