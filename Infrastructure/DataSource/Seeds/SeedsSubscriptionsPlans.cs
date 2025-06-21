using Infrastructure.Models.Plans;
using Infrastructure.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsSubscriptionsPlans
    {

        public string Language { get; set; } = "ar";
        private List<SubscriptionPlanModel> db = new List<SubscriptionPlanModel>();

		public SeedsSubscriptionsPlans()
		{
            db = GetAll();
        }

		// Add a new subscription plan
		public void AddPlan(SubscriptionPlanModel plan)
		{
			if (db.Any(p => p.Id == plan.Id))
			{
				throw new Exception("Plan with the same Id already exists.");
			}
			db.Add(plan);
			Console.WriteLine("Plan added successfully.");
		}

		// Update an existing subscription plan
		public void UpdatePlan(string id, SubscriptionPlanModel updatedPlan)
		{
			var plan = db.FirstOrDefault(p => p.Id == id);
			if (plan == null)
			{
				throw new Exception("Plan not found.");
			}
			db.Remove(plan);
			db.Add(updatedPlan);
			Console.WriteLine("Plan updated successfully.");
		}

		// Delete a subscription plan
		public void DeletePlan(string id)
		{
			var plan = db.FirstOrDefault(p => p.Id == id);
			if (plan == null)
			{
				throw new Exception("Plan not found.");
			}
			db.Remove(plan);
			Console.WriteLine("Plan deleted successfully.");
		}

		// Retrieve all plans
		public List<SubscriptionPlanModel> GetAllSubscriptionsPlansByEmail(string email)
		{
			return db.Where(x=>x.User?.Email== email).ToList();
		}
		public List<SubscriptionPlanModel> GetAllSubscriptionsPlansById(string userId)
		{
			return db.Where(x => x.User?.Id == userId).ToList();
		}

		// Find a plan by Id
		public SubscriptionPlanModel GetPlanById(string id)
		{
			var plan = db.FirstOrDefault(p => p.Id == id);
			if (plan == null)
			{
				throw new Exception("Plan not found.");
			}
			return plan;
		}

        public List<SubscriptionPlanModel> GetSubscriptionsPlansEN()
        {

            return new List<SubscriptionPlanModel>
                {
                    new SubscriptionPlanModel
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
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "price_1QSOh8KMQ7LabgRTu8QHKFJE",
                        Name = "Standard",
                        Description = "Intermediate subscription plan",
                        Active = true,
                        Price = 29.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 29.99m,
                        ContainerId = "2",
                        TotalBilling = 359.88m,
                        Image = "standard-plan.png",
                        MonthlyPrice = 29.99m,
                        AnnualPrice = 299.99m,
                        WeeklyPrice = 7.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "10,000", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "2 GB", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "2 GB", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "1 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "No", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "No", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "Yes", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "3", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "10", Name = "Scalability", Description = "Twice a month", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                        }
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Professional",
                        Description = "Professional subscription plan",
                        Active = true,
                        Price = 49.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 49.99m,
                        ContainerId = "3",
                        TotalBilling = 599.88m,
                        Image = "professional-plan.png",
                        MonthlyPrice = 49.99m,
                        AnnualPrice = 499.99m,
                        WeeklyPrice = 12.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "12", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "100,000", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "4 GB", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "8 GB", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "0.5 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "Yes", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "Yes", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "Yes", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "10", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "10", Name = "Scalability", Description = "Unlimited", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                        }
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "price_1QSOh8KMQ7LabgRTu8QHKFJE",
                        Name = "Enterprise",
                        Description = "Advanced subscription plan for enterprises",
                        Active = true,
                        Price = 99.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 99.99m,
                        ContainerId = "4",
                        TotalBilling = 1199.88m,
                        Image = "advanced-plan.png",
                        MonthlyPrice = 99.99m,
                        AnnualPrice = 999.99m,
                        WeeklyPrice = 24.99m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "12", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "Unlimited", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "Unlimited", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "Unlimited", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "0.5 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "Yes", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "Yes", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "Yes", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "Unlimited", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                        }
                    }
                };

        }
        public List<SubscriptionPlanModel> GetAll()
        {
            return (Language == "ar") ? GetSubscriptionsPlansAR() : GetSubscriptionsPlansEN();
        }
        public List<SubscriptionPlanModel> GetSubscriptionsPlansAR()
        {
            return new List<SubscriptionPlanModel>
            {
                    new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Free",
                        Description = "خطة اشتراك أساسية",
                        Active = true,
                        Price = 0m,
                        IsFixed = false,
                        IsPaid = false,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 0m,
                        ContainerId = "1",
                        TotalBilling = 0m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 0m,
                        AnnualPrice = 0m,
                        WeeklyPrice = 0m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "عدد النماذج AI", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "الطلبات", Description = "1,000 طلب", BillingPeriod = "Monthly", NumberRequests = 10000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "المعالج", Description = "مشترك", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "الذاكرة العشوائية", Description = "2 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "السرعة", Description = "2 pre/Second", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "الدعم", Description = "لا", BillingPeriod = "شهري", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "تخصيص", Description = "لا", BillingPeriod = "شهري", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "لا", BillingPeriod = "شهري", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "1", BillingPeriod = "شهري", TotalAmount = 0m, Active = true },

                        }
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "price_1QSOh8KMQ7LabgRTu8QHKFJE",
                        Name = "Standard",
                        Description = "خطة اشتراك متوسطة",
                        Active = true,
                        Price = 29.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 29.99m,
                        ContainerId = "2",
                        TotalBilling = 359.88m,
                        Image = "standard-plan.png",
                        MonthlyPrice = 29.99m,
                        AnnualPrice = 299.99m,
                        WeeklyPrice = 7.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "عدد النماذج AI", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "الطلبات", Description = "10,000", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "المعالج", Description = "2 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "الذاكرة العشوائية", Description = "2 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "السرعة", Description = "1 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "الدعم", Description = "لا", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "تخصيص", Description = "لا", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "3", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "10", Name = "قابلية التوسع", Description = "مرتين شهرياً", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                        }
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Professional",
                        Description = "خطة اشتراك احترافية",
                        Active = true,
                        Price = 49.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 49.99m,
                        ContainerId = "3",
                        TotalBilling = 599.88m,
                        Image = "professional-plan.png",
                        MonthlyPrice = 49.99m,
                        AnnualPrice = 499.99m,
                        WeeklyPrice = 12.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "عدد النماذج AI", Description = "12", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "الطلبات", Description = "100,000", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "المعالج", Description = "4 جيجا بايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "الذاكرة العشوائية", Description = "8 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "السرعة", Description = "0.5 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "الدعم", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "7", Name = "تخصيص", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "10", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                              new PlanFeatureModel { Id = "10", Name = "قابلية التوسع", Description = "غير محدد", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                        }
                    },
                    new SubscriptionPlanModel
    {
        Id = "price_1QSOh8KMQ7LabgRTu8QHKFJE",
        Name = "Enterprise",
        Description = "خطة اشتراك متقدمة للمؤسسات",
        Active = true,
        Price = 99.99m,
        IsFixed = false,
        IsPaid = true,
        Quantity = 1,
        BillingPeriod = "Monthly",
        TotalAmount = 99.99m,
        ContainerId = "4",
        TotalBilling = 1199.88m,
        Image = "advanced-plan.png",
        MonthlyPrice = 99.99m,
        AnnualPrice = 999.99m,
        WeeklyPrice = 24.99m,
        Features = new List<PlanFeatureModel>
        {
            new PlanFeatureModel { Id = "1", Name = "عدد النماذج AI", Description = "12", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "الطلبات", Description = "غير محدد", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "المعالج", Description = "غير محدد", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "الذاكرة العشوائية", Description = "غير محدد", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "السرعة", Description = "0.5 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "الدعم", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "7", Name = "تخصيص", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "غير محدد", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },

        }
    }

            };


        }

        public  SubscriptionPlanModel? getOne(string planId)
        {
                var plan = db?.FirstOrDefault(X => X.Id == planId);
                return plan;
        }


    }
}
