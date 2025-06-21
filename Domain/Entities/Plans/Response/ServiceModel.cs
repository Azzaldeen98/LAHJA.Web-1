using Domain.ShareData.Base;

namespace Domain.Entities.Plans.Response
{
    public class ContainerPlans : BaseContainerPlans
    {
        public new List<SubscriptionPlan>? SubscriptionsPlans { get; set; }
    }

    //public class SubscriptionPlan
    //{
    //    public string? Id { get; set; }
    //    public string Name { get; set; }
    //           //public string? GroupId { get; set; }
    //    public string? Description { get; set; }
    //    public bool Active { get; set; } = true;
    //    public decimal Price { get; set; } = 0;
    //    public bool? IsFixed { get; set; } = true; // خاصية جديدة
    //    public bool? IsPaid { get; set; } = false; // خاصية جديدة
    //    public int Count { get; set; } = 1;
    //    public int Quantity { get; set; } = 1;
    //    public decimal TotalAmount { get; set; } = 0;
    //    public List<BasePlanFeature>? Features { get; set; }
    //}
    //public class BasePlanFeature
    //{
    //    public string? Id { get; set; }
    //    public string Name { get; set; }
    //    public string? Description { get; set; }
    //    public bool Active { get; set; } = true;
    //    public decimal Price { get; set; } = 0;
    //    public bool? IsFixed { get; set; } = true;
    //    public bool? IsPaid { get; set; }
    //    public int Count { get; set; } = 1;
    //    public int Quantity { get; set; } = 1;
    //    public decimal TotalAmount { get; set; } = 0;
    //}
    //public class GroupPlans
    //{
    //    public string? Id { get; set; }
    //    public string Name { get; set; }
    //    public string? Description { get; set; }
    //    public bool Active { get; set; } = true;
    //    //public List<SubscriptionPlan>? SubscriptionPlans { get; set; }
    //}

    //var groupPlans = new List<GroupPlans>
    //    {
    //        new GroupPlans
    //        {
    //            Id = "1",
    //            Name = "Group 1",
    //            Description = "First group of plans",
    //            Active = true,
    //            SubscriptionPlans = new List<SubscriptionPlan>
    //            {
    //                new SubscriptionPlan
    //                {
    //                    Id = "1-1",
    //                    Name = "Basic Plan",
    //                    Description = "Basic subscription plan",
    //                    Price = 9.99m,
    //                    IsFixed = true,
    //                    IsPaid = false,
    //                    Features = new List<BasePlanFeature>
    //                    {
    //                        new BasePlanFeature { Id = "F1", Name = "Feature 1", Price = 1.99m },
    //                        new BasePlanFeature { Id = "F2", Name = "Feature 2", Price = 2.99m }
    //                    }
    //                }
    //            }
    //        },
    //        new GroupPlans
    //        {
    //            Id = "2",
    //            Name = "Group 2",
    //            Description = "Second group of plans",
    //            Active = true,
    //            SubscriptionPlans = new List<SubscriptionPlan>
    //            {
    //                new SubscriptionPlan
    //                {
    //                    Id = "2-1",
    //                    Name = "Standard Plan",
    //                    Description = "Standard subscription plan",
    //                    Price = 19.99m,
    //                    IsFixed = false,
    //                    IsPaid = true,
    //                    Features = new List<BasePlanFeature>
    //                    {
    //                        new BasePlanFeature { Id = "F3", Name = "Feature 3", Price = 3.99m },
    //                        new BasePlanFeature { Id = "F4", Name = "Feature 4", Price = 4.99m }
    //                    }
    //                }
    //            }
    //        },
    //        new GroupPlans
    //        {
    //            Id = "3",
    //            Name = "Group 3",
    //            Description = "Third group of plans",
    //            Active = false,
    //            SubscriptionPlans = new List<SubscriptionPlan>
    //            {
    //                new SubscriptionPlan
    //                {
    //                    Id = "3-1",
    //                    Name = "Premium Plan",
    //                    Description = "Premium subscription plan",
    //                    Price = 29.99m,
    //                    IsFixed = true,
    //                    IsPaid = true,
    //                    Features = new List<BasePlanFeature>
    //                    {
    //                        new BasePlanFeature { Id = "F5", Name = "Feature 5", Price = 5.99m },
    //                        new BasePlanFeature { Id = "F6", Name = "Feature 6", Price = 6.99m }
    //                    }
    //                }
    //            }
    //        }
    //    };
}
