using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using System.Collections.Generic;


namespace Infrastructure.DataSource.Seeds
{
    public class SeedsPlansContainers
    {
        List<Service> ServicesAR = new List<Service>
        {
            new Service
            {
                Id = "1",
                Name = "تحويل النص إلى صوت",
                Description = "تحويل النصوص المكتوبة إلى صوت باستخدام تقنيات الذكاء الاصطناعي المتقدمة.",
                Active = true,
                Image = "/chatbot-03.png",
                Price = 50.0m,
                Amount = 100.0m,
                Token = "TOKEN123",
                NumberRequests = 1000,
                NumberOfRequestsUsed = 0
            },
            new Service
            {
                Id = "2",
                Name = "تحويل النص إلى لهجة",
                Description = "تحويل النص إلى لهجة محددة بدقة عالية.",
                Active = true,
                Image = "/chatbot-03.png",
                Price = 30.0m,
                Amount = 50.0m,
                Token = "TOKEN456",
                NumberRequests = 500,
                NumberOfRequestsUsed = 0
            },
            new Service
            {
                Id = "3",
                Name = "روبوت تفاعلي (API)",
                Description = "دمج روبوت تفاعلي من خلال API للعديد من المهام.",
                Active = true,
                Image = "/chatbot-03.png",
                Price = 100.0m,
                Amount = 200.0m,
                Token = "TOKEN789",
                NumberRequests = 2000,
                NumberOfRequestsUsed = 0
            }
        };
        List<Service> ServicesEN = new List<Service>
{
    new Service
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
    },
    new Service
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
    new Service
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
    }
};

        public static List<Service> dbServices = new List<Service>();
        public string Language { get; set; } = "ar";
        public static List<ContainerPlansModel> db= new List<ContainerPlansModel>();



        public SeedsPlansContainers()
        {

            db =(Language=="ar")? SeedsPlansContainersAR(): SeedsPlansContainersEN();
            dbServices = (Language == "ar") ? ServicesAR : ServicesEN;
            //db = SeedsPlansContainersEN();



        }
        public   List<Service> GetServices()
        {
           return dbServices = (Language == "ar") ? ServicesAR : ServicesEN;
        }

        public List<ContainerPlansModel> SeedsPlansContainersEN()
        {
         
            return new List<ContainerPlansModel>{
                new ContainerPlansModel
                {
                    Id = "1",
                    Name = "Text-to-Speech",
                    Description = "Convert written text to speech using advanced AI technologies.",
                    Active = true,
                    Image = "/chatbot-03.png",  // You can change the card image here
                
                },
                new ContainerPlansModel
                {
                    Id = "2",
                    Name = "Text-to-Dialect",
                    Description = "Convert text into a specific dialect with high accuracy.",
                    Active = true,
                    Image = "/chatbot-03.png",  // You can change the card image here
                
                },
                new ContainerPlansModel
                {
                    Id = "3",
                    Name = "Interactive Bot (API)",
                    Description = "Integrate an interactive bot through API for various tasks.",
                    Active = true,
                    Image = "/chatbot-03.png",  // You can change the card image here
                  
                }
            };

        }

        public List<ContainerPlansModel> SeedsPlansContainersAR()
        {
    //        var plans = new List<SubscriptionPlanModel>
    //        {
    //                new SubscriptionPlanModel
    //                {
    //                    Id = "price_1QSOh8KMQ7LabgRTu8QHKFJE",
    //                    Name = "الخطة العامة (Basic Plan)",
    //                    Description = "خطة اشتراك أساسية",
    //                    Active = true,
    //                    Price = 0m,
    //                    IsFixed = false,
    //                    IsPaid = false,
    //                    Quantity = 1,
    //                    BillingPeriod = "Monthly",
    //                    TotalAmount = 0m,
    //                    ContainerId = "1",
    //                    TotalBilling = 119.88m,
    //                    Image = "basic-plan.png",
    //                    MonthlyPrice = 0m,
    //                    AnnualPrice = 0m,
    //                    WeeklyPrice = 0m,
    //                    Features = new List<PlanFeatureModel>
    //                    {
    //                        new PlanFeatureModel { Id = "1", Name = "Requests", Description = "1,000 طلب", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
    //                        new PlanFeatureModel { Id = "2", Name = "CPU", Description = "مشترك مع خوادم أخرى", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
    //                        new PlanFeatureModel { Id = "3", Name = "RAM", Description = "4 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
    //                        new PlanFeatureModel { Id = "4", Name = "Speed (Response Time)", Description = "متوسط 2 ثانية لكل طلب", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
    //                        new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم عبر البريد الإلكتروني فقط", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true }
    //                    }
    //                },
    //                new SubscriptionPlanModel
    //                {
    //                    Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
    //                    Name = "الخطة المتوسطة (Standard Plan)",
    //                    Description = "خطة اشتراك متوسطة",
    //                    Active = true,
    //                    Price = 29.99m,
    //                    IsFixed = false,
    //                    IsPaid = true,
    //                    Quantity = 1,
    //                    BillingPeriod = "Monthly",
    //                    TotalAmount = 29.99m,
    //                    ContainerId = "2",
    //                    TotalBilling = 359.88m,
    //                    Image = "standard-plan.png",
    //                    MonthlyPrice = 29.99m,
    //                    AnnualPrice = 299.99m,
    //                    WeeklyPrice = 7.49m,
    //                    Features = new List<PlanFeatureModel>
    //                    {
    //                        new PlanFeatureModel { Id = "1", Name = "Requests", Description = "10,000 طلب", BillingPeriod = "Monthly", NumberRequests = 10000, TotalAmount = 29.99m, Active = true },
    //                        new PlanFeatureModel { Id = "2", Name = "CPU", Description = "معالج مستقل رباعي النواة", BillingPeriod = "Monthly", TotalAmount = 29.99m, Active = true },
    //                        new PlanFeatureModel { Id = "3", Name = "RAM", Description = "8 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 29.99m, Active = true },
    //                        new PlanFeatureModel { Id = "4", Name = "Customization", Description = "إمكانية تعديل نبرة الصوت وسرعته", BillingPeriod = "Monthly", TotalAmount = 29.99m, Active = true },
    //                        new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم عبر البريد الإلكتروني والدردشة الفورية خلال ساعات العمل", BillingPeriod = "Monthly", TotalAmount = 29.99m, Active = true }
    //                    }
    //                },
    //                new SubscriptionPlanModel
    //                {
    //                    Id = "price_1QSOh8KMQ7LabgRTu8QHKFJE",
    //                    Name = "الخطة الاحترافية (Professional Plan)",
    //                    Description = "خطة اشتراك احترافية",
    //                    Active = true,
    //                    Price = 49.99m,
    //                    IsFixed = false,
    //                    IsPaid = true,
    //                    Quantity = 1,
    //                    BillingPeriod = "Monthly",
    //                    TotalAmount = 49.99m,
    //                    ContainerId = "3",
    //                    TotalBilling = 599.88m,
    //                    Image = "professional-plan.png",
    //                    MonthlyPrice = 49.99m,
    //                    AnnualPrice = 499.99m,
    //                    WeeklyPrice = 12.49m,
    //                    Features = new List<PlanFeatureModel>
    //                    {
    //                        new PlanFeatureModel { Id = "1", Name = "Requests", Description = "50,000 طلب", BillingPeriod = "Monthly", NumberRequests = 50000, TotalAmount = 49.99m, Active = true },
    //                        new PlanFeatureModel { Id = "2", Name = "CPU", Description = "معالج مستقل ثماني النواة", BillingPeriod = "Monthly", TotalAmount = 49.99m, Active = true },
    //                        new PlanFeatureModel { Id = "3", Name = "RAM", Description = "16 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 49.99m, Active = true },
    //                        new PlanFeatureModel { Id = "4", Name = "Customization", Description = "تخصيص كامل لتجربة الاستخدام", BillingPeriod = "Monthly", TotalAmount = 49.99m, Active = true },
    //                        new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم فوري على مدار الساعة عبر البريد الإلكتروني والدردشة", BillingPeriod = "Monthly", TotalAmount = 49.99m, Active = true }
    //                    }
    //                },
    //                new SubscriptionPlanModel
    //{
    //    Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
    //    Name = "الخطة المتقدمة (Advanced Plan)",
    //    Description = "خطة اشتراك متقدمة للمؤسسات",
    //    Active = true,
    //    Price = 99.99m,
    //    IsFixed = false,
    //    IsPaid = true,
    //    Quantity = 1,
    //    BillingPeriod = "Monthly",
    //    TotalAmount = 99.99m,
    //    ContainerId = "4",
    //    TotalBilling = 1199.88m,
    //    Image = "advanced-plan.png",
    //    MonthlyPrice = 99.99m,
    //    AnnualPrice = 999.99m,
    //    WeeklyPrice = 24.99m,
    //    Features = new List<PlanFeatureModel>
    //    {
    //        new PlanFeatureModel { Id = "1", Name = "Requests", Description = "100,000 طلب", BillingPeriod = "Monthly", NumberRequests = 100000, TotalAmount = 99.99m, Active = true },
    //        new PlanFeatureModel { Id = "2", Name = "CPU", Description = "معالج مستقل متعدد الأنوية", BillingPeriod = "Monthly", TotalAmount = 99.99m, Active = true },
    //        new PlanFeatureModel { Id = "3", Name = "RAM", Description = "32 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 99.99m, Active = true },
    //        new PlanFeatureModel { Id = "4", Name = "Customization", Description = "إعدادات متقدمة لتجربة الاستخدام", BillingPeriod = "Monthly", TotalAmount = 99.99m, Active = true },
    //        new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم فوري وشامل عبر جميع القنوات", BillingPeriod = "Monthly", TotalAmount = 99.99m, Active = true }
    //    }
    //}
    //            // Add other plans similarly...
    //        }; 
            return new List<ContainerPlansModel>
            {
                new ContainerPlansModel
                {
                    Id = "1",
                    Name = "تحويل النص إلى صوت",
                    Description = "تحويل النصوص المكتوبة إلى صوت باستخدام تقنيات الذكاء الاصطناعي المتقدمة.",
                    Active = true,
                    Image = "/chatbot-03.png",  // يمكن تغيير صورة البطاقة هنا

                },
                new ContainerPlansModel
                {
                    Id = "2",
                    Name = "تحويل النص إلى لهجة",
                    Description = "تحويل النص إلى لهجة محددة بدقة عالية.",
                    Active = true,
                    Image = "/chatbot-03.png",  // يمكن تغيير صورة البطاقة هنا
                    //SubscriptionsPlans = plans
                },
                new ContainerPlansModel
                {
                    Id = "3",
                    Name = "روبوت تفاعلي (API)",
                    Description = "دمج روبوت تفاعلي من خلال API للعديد من المهام.",
                    Active = true,
                    Image = "/chatbot-03.png",  // يمكن تغيير صورة البطاقة هنا
                    //SubscriptionsPlans = plans
                }
            };




        }
        public async Task<IEnumerable<PlansContainerModel>?> getAllContainersAsync()
        {

            return new List<PlansContainerModel>{
                new PlansContainerModel
                {
                    Id = "1",
                    Name = "Basic Plan",
                    Description = "This is a basic plan with minimal features.",
                    Price = 19.99m,
                    ImageUrl = "/ai-hand.png",

                },
                new PlansContainerModel
                {
                    Id = "2",
                    Name = "Standard Plan",
                    Description = "This is a standard plan with more features.",
                    Price = 49.99m,
                    ImageUrl = "/ai-hand.png",

                },
                new PlansContainerModel
                {
                    Id = "3",
                    Name = "Premium Plan",
                    Description = "This is a premium plan with all features.",
                    Price = 99.99m,
                    ImageUrl = "/ai-hand.png",


                }
         };
        }


        public List<SubscriptionPlanModel> GetBasicSubscriptionsPlansEN()
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
                        Services =new List<Domain.ShareData.Base.Service>{ ServicesEN[0] },
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
                            Services =new List<Domain.ShareData.Base.Service>{ ServicesEN[0], ServicesEN[1] },
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
                           Services =new List<Domain.ShareData.Base.Service>{ ServicesEN[2], ServicesEN[1] },
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
                           Services =new List<Domain.ShareData.Base.Service>{ ServicesEN[1], ServicesEN[0] },
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
        public List<SubscriptionPlanModel> GetBasicSubscriptionsPlans()
        {
           return (Language == "ar") ? GetBasicSubscriptionsPlansAR() : GetBasicSubscriptionsPlansEN();
        }
        public List<SubscriptionPlanModel> GetBasicSubscriptionsPlansAR()
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
                          Services =new List<Domain.ShareData.Base.Service>{ ServicesAR[0] },
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
                           Services =new List<Domain.ShareData.Base.Service>{ ServicesAR[0], ServicesAR[1] },
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
                          Services =new List<Domain.ShareData.Base.Service>{ ServicesAR[2], ServicesAR[1] },
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
         Services =new List<Domain.ShareData.Base.Service>{ ServicesAR[1], ServicesAR[0] },
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


        public async Task<IEnumerable<ContainerPlansModel>?> getAllAsync()
        {

            db = (Language == "ar") ? SeedsPlansContainersAR() : SeedsPlansContainersEN();
            return db;
        }

        public async Task<ContainerPlansModel?> getOneAsync(string containerId)
        {
            db = (Language == "ar") ? SeedsPlansContainersAR() : SeedsPlansContainersEN();
            return db.FirstOrDefault(x=>x.Id== containerId) ??null;
        }

        public async Task<List<SubscriptionPlanModel>?> getSubscriptionsPlansAsync(string containerId)
        {
            db = (Language == "ar") ? SeedsPlansContainersAR() : SeedsPlansContainersEN();
            return db.FirstOrDefault(x => x.Id == containerId)?.SubscriptionsPlans??null;
        }

        public async Task<List<SubscriptionPlanModel>?> getAllSubscriptionsPlansAsync()
        {
         return  (Language == "ar") ? GetBasicSubscriptionsPlansAR() : GetBasicSubscriptionsPlansEN();
            //return GetBasicSubscriptionsPlansAR();
            //var subscriptionPlans = db.Where(x => x.SubscriptionsPlans != null && x.SubscriptionsPlans.Any())
            //                          .SelectMany(x => x.SubscriptionsPlans)
            //                          .ToList();

            //return subscriptionPlans;
        }

        public async Task<List<PlanFeatureModel>?> getSubscriptionsPlansFeaturesAsync(string planId)
        {
            foreach (var item in db)
            {
                var plan = item?.SubscriptionsPlans?.FirstOrDefault(X => X.Id == planId);
                if (plan!=null && plan.Id==planId)
                    return plan.Features??null;
            }
            return  null;
        }
        public async Task<SubscriptionPlanModel?> getOneSubscriptionPlanAsync(string planId)
        {
            foreach (var item in db)
            {
                var plan = item?.SubscriptionsPlans?.FirstOrDefault(X => X.Id == planId);
                if (plan != null)
                {
                    return plan;
                }
            }
            return null;
        }




    }
}
