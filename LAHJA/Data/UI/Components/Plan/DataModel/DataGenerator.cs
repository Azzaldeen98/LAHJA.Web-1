//using LAHJA.Data.UI.Components.Plan;
 

//namespace LAHJA.Data.UI.Components.Plan
//{
//    public class DataGenerator
//    {




//        private Random random = new Random();

//        public List<PlanViewModel> GeneratePlanInfoList(int count)
//        {
//            var PlanViewModels = new List<PlanViewModel>();

//            for (int i = 0; i < count; i++)
//            {
//                var PlanViewModel = new PlanViewModel
//                {
//                    Id = $"P{random.Next(1000, 9999)}",  
//                    Name = $"Plan {i + 1}",
//                    IdService = $"S{random.Next(100, 999)}",
//                    PlanDescription = "Random generated plan description",
//                    Status = random.Next(0, 2) == 0 ? "Active" : "Inactive",
//                    TotalPrice = (decimal)(random.Next(100, 1000) + random.NextDouble()),
//                    TechnologyServices = new List<TechnologyService>
//                {

//                    new TechnologyService
//                    {
//                        Id = $"T{random.Next(1000, 9999)}",
//                        Name = "Tech Service " + (i + 1),
//                        Description = "Random tech service description",
//                        TechnicalServices = new List<TechnicalService>
//                        {
//                            new TechnicalService { Id = $"TS{random.Next(1000, 9999)}", Name = "Random Tech", Price = (decimal)(random.NextDouble() * 1000), Status = "Active" }
//                        }
//                    }

//                },
//                    ServiceDetailsList = new List<DigitalService>
//                {
//                    new DigitalService { ServiceType = "Internet", Id = $"SD{random.Next(1000, 9999)}", Quantity = random.Next(1, 10), UnitPrice = (decimal)(random.NextDouble() * 100) },
//                    new DigitalService { ServiceType = "Storage", Id = $"SD{random.Next(1000, 9999)}", Quantity = random.Next(1, 10), UnitPrice = (decimal)(random.NextDouble() * 200) }
//                }
//                };

//                PlanViewModels.Add(planInfo);
//            }

//            return PlanViewModels;

//        }
//    }
//}
