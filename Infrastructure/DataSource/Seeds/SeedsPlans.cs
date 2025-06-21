using Domain.Entities.Plans.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsPlans
    {
      private static List<PlanResponseModel> db= new List<PlanResponseModel>();
      private static List<PlansGroupModel> basicDB= new List<PlansGroupModel>();


        public SeedsPlans()
        {
            db.AddRange(new List<PlanResponseModel>(){
                new PlanResponseModel
                {
                    Id = "1",
                    ProductName = "Basic Plan",
                    ProductId = "P001",
                    BillingPeriod = "Monthly",
                    NumberRequests = 100,
                    Amount = 19.99,
                    Active = true,
                    Subscriptions = new List<PlanSubscriptionResponseModel>
                    {
                        new PlanSubscriptionResponseModel
                        {
                            Id = "S001",
                            PlanId = "1",
                            Nr = 1,
                            CustomerId = "C001",
                            StartDate = DateTime.Now,
                            Status = "Active",
                            BillingPeriod = "Monthly",
                            CancelAt = null,
                            CancelAtPeriodEnd = false,
                           
                        }
                    }
                },
                new PlanResponseModel
                {
                    Id = "2",
                    ProductName = "Standard Plan",
                    ProductId = "P002",
                    BillingPeriod = "Monthly",
                    NumberRequests = 500,
                    Amount = 49.99,
                    Active = true,
                    Subscriptions = new List<PlanSubscriptionResponseModel>
                    {
                        new PlanSubscriptionResponseModel
                        {
                            Id = "S002",
                            PlanId = "2",
                            Nr = 2,
                            CustomerId = "C002",
                            StartDate = DateTime.Now.AddDays(-30),
                            Status = "Active",
                            BillingPeriod = "Monthly",
                            CancelAt = null,
                            CancelAtPeriodEnd = false,
                       
                        }
                    }
                },
                new PlanResponseModel
                {
                    Id = "3",
                    ProductName = "Premium Plan",
                    ProductId = "P003",
                    BillingPeriod = "Yearly",
                    NumberRequests = 2000,
                    Amount = 499.99,
                    Active = true,
                    Subscriptions = new List<PlanSubscriptionResponseModel>
                    {
                        new PlanSubscriptionResponseModel
                        {
                            Id = "S003",
                            PlanId = "3",
                            Nr = 3,
                            CustomerId = "C003",
                            StartDate = DateTime.Now.AddDays(-365),
                            Status = "Expired",
                            BillingPeriod = "Yearly",
                            CancelAt = DateTime.Now.AddDays(-10),
                            CancelAtPeriodEnd = true,
                       
                        }
                    }
                }
            });

       
            var plans = new List<PlansGroupModel>
        {
            new PlansGroupModel
            {
                Id = "1",
                ProductName = "Basic Plan",
                Active = true,
                SubscriptionFeatures = new List<PlanSubscriptionFeaturesModel>
                {
                     new PlanSubscriptionFeaturesModel { Id = "1",Name="TextToSpeechService",Description="Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, Amount = 9.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "2",Name="Voice Quality",Description="Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, Amount = 29.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "3",Name="Voice Type",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "4",Name="support Types",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "5",Name="server Speeds",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                },
                TechnicalFeatures = new List<PlanTechnicalFeaturesModel>
                {
                    new PlanTechnicalFeaturesModel { Id = "1", Name = "Number of Requests", Description = "Unlimited requests", Price = 19.99m, Quantity = 10, Status = "Active" },
                    new PlanTechnicalFeaturesModel { Id = "2", Name = "Scope Android", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "3", Name = "Scope Web", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "4", Name = "Scope Report", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "5", Name = "Scope Word Quantity", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                }
            },
            new PlansGroupModel
            {
                Id = "2",
                ProductName = "Standard Plan",
                Active = true,
                SubscriptionFeatures = new List<PlanSubscriptionFeaturesModel>
                {
                      new PlanSubscriptionFeaturesModel { Id = "1",Name="TextToSpeechService",Description="Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, Amount = 9.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "2",Name="Voice Quality",Description="Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, Amount = 29.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "3",Name="Voice Type",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "4",Name="support Types",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "5",Name="server Speeds",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                },
                TechnicalFeatures = new List<PlanTechnicalFeaturesModel>
                {

                    new PlanTechnicalFeaturesModel { Id = "1", Name = "Number of Requests", Description = "Unlimited requests", Price = 19.99m, Quantity = 10, Status = "Active" },
                    new PlanTechnicalFeaturesModel { Id = "2", Name = "Scope Android", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "3", Name = "Scope Web", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "4", Name = "Scope Report", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "5", Name = "Scope Word Quantity", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                }
            },
            new PlansGroupModel
            {
                Id = "3",
                ProductName = "Premium Plan",
                Active = true,
                SubscriptionFeatures = new List<PlanSubscriptionFeaturesModel>
                {
                     new PlanSubscriptionFeaturesModel { Id = "1",Name="TextToSpeechService",Description="Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, Amount = 9.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "2",Name="Voice Quality",Description="Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, Amount = 29.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "3",Name="Voice Type",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "4",Name="support Types",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "5",Name="server Speeds",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                },
                TechnicalFeatures = new List<PlanTechnicalFeaturesModel>
                {

                    new PlanTechnicalFeaturesModel { Id = "1", Name = "Number of Requests", Description = "Unlimited requests", Price = 19.99m, Quantity = 10, Status = "Active" },
                    new PlanTechnicalFeaturesModel { Id = "2", Name = "Scope Android", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "3", Name = "Scope Web", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "4", Name = "Scope Report", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "5", Name = "Scope Word Quantity", Description = "Unlimited requests", Price = 29.99m, Quantity = 20, Status = "NoActive" },
                }
            }
        };

            basicDB.AddRange(plans);





    }

    public async Task<IEnumerable<PlanResponseModel>?> getAllPlansAsync()
    {
        return db;
    }   
        
    public async Task<IEnumerable<PlansGroupModel>> getPlansGroupAsync()
    {
        return basicDB;
    }


    public async Task<PlanResponseModel?> getPlanByIdAsync(string id)
    {

            return (db.Count() > 0) ? db.FirstOrDefault(x => x.Id == id) : null;
    }

        public async Task<PlanInfoResponse?> getPlanInfoByIdAsync(string id)
        {
            var random = new Random();
            new PlanInfoResponse
            {
                Id =id,
                //Name = "Plan 1",
         
                //Description = "Random generated plan description",
                //Status = random.Next(0, 2) == 0 ? "Active" : "Inactive",
                //TotalPrice = (decimal)(random.Next(100, 1000) + random.NextDouble()),
                //TechnologyServices = new List<TechnologyService>
                //{

                //    new TechnologyService
                //    {
                //        Id = $"T{random.Next(1000, 9999)}",
                //        Name = "Tech Service " + (i + 1),
                //        Description = "Random tech service description",
                //        TechnicalServices = new List<TechnicalService>
                //        {
                //            new TechnicalService { Id = $"TS{random.Next(1000, 9999)}", Name = "Random Tech", Price = (decimal)(random.NextDouble() * 1000), Status = "Active" }
                //        }
                //    }

                //},
                //ServiceDetailsList = new List<DigitalService>
                //{
                //    new DigitalService { ServiceType = "Internet", Id = $"SD{random.Next(1000, 9999)}", Quantity = random.Next(1, 10), UnitPrice = (decimal)(random.NextDouble() * 100) },
                //    new DigitalService { ServiceType = "Storage", Id = $"SD{random.Next(1000, 9999)}", Quantity = random.Next(1, 10), UnitPrice = (decimal)(random.NextDouble() * 200) }
                //}
            };
            return new PlanInfoResponse();// (db.Quantity > 0) ? db.FirstOrDefault(x => x.Id == id) : null;
        }
    }

}
