using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Plans;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsSubscriptionsData
    {
        private List<SubscriptionModel> subscriptions;

        public SeedsSubscriptionsData()
        {
           

          subscriptions = new List<SubscriptionModel>
        {
            new SubscriptionModel
            {
                Id = "1",
                UserId = "test@gmail.com",
                PlanId = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                CustomerId = "customer_001",
                BillingPeriod = "Monthly",
                StartDate = DateTime.Now,
                Status = "Active",
                CancelAtPeriodEnd = false,
                SubscriptionPlan =   new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Free",
                        Description = "Basic subscription plan",
                        Active = true,
                        Price = 0m,
                        IsFixed = false,
                        IsPaid = false,
                        Quantity = 1,
                        NumberRequests = 10,
                        NumberOfRequestsUsed = 0,
                        BillingPeriod = "Monthly",
                        TotalAmount = 0m,
                        ContainerId = "1",
                        TotalBilling = 08m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 0m,
                        AnnualPrice = 0m,
                        WeeklyPrice = 0m,
                        Services =new List<Domain.ShareData.Base.Service>{     new Domain.ShareData.Base.Service
                        {
                         Id = "1",
                        Name = "Text-to-Speech Conversion",
                        Description = "Convert written text into speech using advanced artificial intelligence technologies.",
                        Active = true,
                        Image = "/chatbot-03.png",
                        Price = 50.0m,
                        Amount = 100.0m,
                        Token = "TOKEN123",
                        NumberRequests = 1000,
                        NumberOfRequestsUsed = 0
                        },new Domain.ShareData.Base.Service
                        {
                            Id = "2",
                            Name = "Text-to-Dialect Conversion",
                            Description = "Convert text into a specific dialect with high precision.",
                            Active = true,
                            Image = "/chatbot-03.png",
                            Price = 30.0m,
                            Amount = 50.0m,
                            Token = "TOKEN456",
                            NumberRequests = 1000,
                            NumberOfRequestsUsed = 0
                        },new Domain.ShareData.Base.Service
                        {
                            Id = "3",
                            Name = "Interactive Bot (API)",
                            Description = "Integrate an interactive bot via API for various tasks.",
                            Active = true,
                            Image = "/chatbot-03.png",
                            Price = 100.0m,
                            Amount = 200.0m,
                            Token = "TOKEN789",
                            NumberRequests = 1000,
                            NumberOfRequestsUsed = 0
                                            },
                        },
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "1,000 requests", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "Shared", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "2 GB", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "2 pre/Second", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "1", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                        }
                    }
            },
            new SubscriptionModel
            {
                Id = "2",
                UserId = "user_002",
                PlanId = "plan_002",
                CustomerId = "customer_002",
                BillingPeriod = "Yearly",
                StartDate = DateTime.Now,
                Status = "Active",
                CancelAtPeriodEnd = true,
                SubscriptionPlan =  new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Free",
                        Description = "Basic subscription plan",
                        Active = true,
                        Price = 0m,
                        IsFixed = false,
                        IsPaid = false,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 0m,
                        ContainerId = "1",
                        TotalBilling = 08m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 0m,
                        AnnualPrice = 0m,
                        WeeklyPrice = 0m,
                                  Services =new List<Domain.ShareData.Base.Service>{     new Domain.ShareData.Base.Service
                        {
                            Id = "2",
                            Name = "Text-to-Dialect Conversion",
                            Description = "Convert text into a specific dialect with high precision.",
                            Active = true,
                            Image = "/chatbot-03.png",
                            Price = 30.0m,
                            Amount = 50.0m,
                            Token = "TOKEN456",
                            NumberRequests = 500,
                            NumberOfRequestsUsed = 0
                        },
                        },
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "1,000 requests", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "Shared", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "2 GB", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "2 pre/Second", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "1", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                        }
                    }
            },
            new SubscriptionModel
            {
                Id = "3",
                UserId = "user_003",
                PlanId = "plan_003",
                CustomerId = "customer_003",
                BillingPeriod = "Monthly",
                StartDate =DateTime.Now,
                Status = "Pending",
                CancelAtPeriodEnd = false,
                //Services=new List<PlanFeatureModel>{},/**/
                SubscriptionPlan =  new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Free",
                        Description = "Basic subscription plan",
                        Active = true,
                        Price = 0m,
                        IsFixed = false,
                        IsPaid = false,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 0m,
                        ContainerId = "1",
                        TotalBilling = 08m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 0m,
                        AnnualPrice = 0m,
                        WeeklyPrice = 0m,
                        Services =new List<Domain.ShareData.Base.Service>{     new Domain.ShareData.Base.Service
                        {
                      Id = "3",
        Name = "Interactive Bot (API)",
        Description = "Integrate an interactive bot via API for various tasks.",
        Active = true,
        Image = "/chatbot-03.png",
        Price = 100.0m,
        Amount = 200.0m,
        Token = "TOKEN789",
        NumberRequests = 2000,
        NumberOfRequestsUsed = 0
                        },
                        },
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "1,000 requests", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "Shared", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "2 GB", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "2 pre/Second", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "1", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                        }
                    }
            }
        };
        }

        // Add a new subscription
        public void AddSubscription(SubscriptionModel subscription)
        {
            if (subscription == null)
                throw new ArgumentNullException(nameof(subscription));

            subscriptions.Add(subscription);
        }

        // Update an existing subscription by Id
        public bool UpdateSubscription(string id, SubscriptionModel updatedSubscription)
        {
            var subscription = subscriptions.FirstOrDefault(s => s.Id == id);
            if (subscription == null)
                return false;

            subscription.UserId = updatedSubscription.UserId;
            subscription.PlanId = updatedSubscription.PlanId;
            subscription.CustomerId = updatedSubscription.CustomerId;
            subscription.BillingPeriod = updatedSubscription.BillingPeriod;
            subscription.StartDate = updatedSubscription.StartDate;
            subscription.Status = updatedSubscription.Status;
            subscription.CancelAtPeriodEnd = updatedSubscription.CancelAtPeriodEnd;

            return true;
        }

        // Delete a subscription by Id
        public bool DeleteSubscription(string id)
        {
            var subscription = subscriptions.FirstOrDefault(s => s.Id == id);
            if (subscription == null)
                return false;

            subscriptions.Remove(subscription);
            return true;
        }

        // Search for subscriptions by a predicate
        public List<SubscriptionModel> SearchSubscriptions(Func<SubscriptionModel, bool> predicate)
        {
            return subscriptions.Where(predicate).OrderDescending().ToList();
        }

        public List<SubscriptionModel>? getActiveSubscriptions(string userId)
        {
            return subscriptions.Where(x => x.UserId == userId && x?.SubscriptionPlan?.Active==true)?.OrderDescending()?.ToList();
          
        }


        public SubscriptionModel getActiveSubscription(string userId)
        {
            return subscriptions.FirstOrDefault(x => x.UserId == userId && x?.SubscriptionPlan?.Active == true);

        }
        public bool AllowedRequest(string userId,string serviceId)
        {
            var item = subscriptions.FirstOrDefault(x => x.UserId == userId && x?.SubscriptionPlan?.Active == true);
            return item.SubscriptionPlan.Services.FirstOrDefault(x => x.Id == serviceId && x.NumberOfRequestsUsed < x.NumberRequests) != null ;

        }
        public bool CreateRequest(string userId,string serviceId)
        {
            var res= subscriptions.FirstOrDefault(x => x.UserId == userId && x?.SubscriptionPlan?.Active == true);
            var tem= res.SubscriptionPlan.Services.FirstOrDefault(x=>x.Id== serviceId);
            if (tem != null && tem.NumberOfRequestsUsed < tem.NumberRequests)
            {
                tem.NumberOfRequestsUsed += 1;
                return true;
            }
            return false;

        }


        public List<SubscriptionModel>? getAllUserSubscriptions(string userId)
        {
            return subscriptions.Where(x => x.UserId == userId)?.OrderDescending()?.ToList();

        }

        // Get all subscriptions (optional utility)
        public List<SubscriptionModel> GetAllSubscriptions()
        {
            return new List<SubscriptionModel>(subscriptions);
        }
    }
}
