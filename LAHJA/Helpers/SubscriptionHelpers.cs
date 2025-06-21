using LAHJA.Data.UI.Components.Plan;
using LAHJA.Data.UI.Models.Profile;

namespace LAHJA.Helpers
{
    public class SubscriptionHelpers
    {

        public static async Task<List<PlanViewModel>> filterPlansAsync(List<PlanViewModel> plans, List<DataBuildUserSubscriptionInfo> userSubscriptions)
        {
            List<PlanViewModel> _dataBuilds = new();

            if (plans != null && plans.Any())
            {
                // var res = await TemplateProfile.GetDataBuildSubscriptions(new FilterResponseData { lg = lg });

                // var countUserSubscriptions = userSubscriptions?.Count(sub => sub?.Status.ToLower() == "active");
                // التحقق مما إذا كان هناك اشتراك نشط
                bool hasActiveSubscription = userSubscriptions?.Any(sub => isActiveSubscription(sub)) == true;

                if (hasActiveSubscription)
                {
                    // التحقق مما إذا كان المستخدم قد اشترك سابقًا في الخطة المجانية
                    bool hasSubscribedToFreeBefore = userSubscriptions?.Any(sub => plans.Any(plan => isFreePlan(plan.Name) && plan.Id == sub.PlanId)) == true;

                    // bool hasSubActive = false; // مؤشر لوجود اشتراك نشط في أي خطة مدفوعة
                    // bool atLeastOnePlanAvailable = false; // مؤشر للتأكد من أن هناك خطة متاحة على الأقل

                    foreach (var plan in plans)
                    {
                        // var planName = plan.Name.ToLower();
                        // var activePlanSubscriptions = userSubscriptions?.Where(sub => sub.PlanId == plan.Id && isActiveSubscription(sub))?.ToList();
                        // bool planHasActiveSubscription = activePlanSubscriptions?.Any() == true;
                        // int numberOfSubscriptionsInPlan = userSubscriptions?.Count(sub => sub.PlanId == plan.Id) ?? 0;
                        var activeSubscription = userSubscriptions?.FirstOrDefault(sub => sub.PlanId == plan.Id && isActiveSubscription(sub));
                        plan.IsSubscriptionActive = activeSubscription != null; // userSubscriptions?.Any(sub => sub.PlanId == plan.Id && isActiveSubscription(sub))??false;
                        plan.NumberOfSubscriptions = userSubscriptions?.Count(sub => sub.PlanId == plan.Id) ?? 0;
                       
                        if (plan.IsSubscriptionActive)
                        {
                            plan.SubscriptionId = activeSubscription.Id;
                        }

                        if (isFreePlan(plan.Name))
                        {
                            // الخطة المجانية غير متاحة إذا تم الاشتراك بها مسبقًا
                            plan.IsSubscriptionAllowed = !hasSubscribedToFreeBefore;
                            plan.IsUpgradeAllowed = false;
                        }
                        // else if (!hasActiveSubscription)
                        // {
                        //   //  إذا لم يكن هناك أي اشتراك نشط، جميع الخطط المدفوعة متاحة للاشتراك
                        //     plan.IsSubscriptionAllowed = true;
                        //     atLeastOnePlanAvailable = true;
                        // }
                        else
                        {
                            plan.IsSubscriptionAllowed = isAllowSubscription(plan, userSubscriptions);
                            plan.IsUpgradeAllowed = plan.IsSubscriptionAllowed;

                            // if (!hasActiveSubscription)
                            // {
                            //     // إذا لم يكن هناك أي اشتراك نشط، جميع الخطط المدفوعة متاحة للاشتراك
                            //     plan.IsSubscriptionAllowed = true;
                            //     atLeastOnePlanAvailable = true;
                            // }
                            // else
                            // {
                            //     if (planHasActiveSubscription)
                            //     {
                            //         // إذا كانت هذه الخطة نشطة حاليًا، لا يمكن الاشتراك فيها مجددًا
                            //         plan.IsSubscriptionAllowed = false;
                            //         plan.IsUpgradeAllowed = false;
                            //         hasSubActive = true; // لدينا خطة نشطة
                            //     }
                            //     else if (hasSubActive)
                            //     {
                            //         // إذا كان هناك اشتراك نشط، يمكن الترقية لهذه الخطة
                            //         plan.IsSubscriptionAllowed = true;
                            //         plan.IsUpgradeAllowed = true;
                            //         atLeastOnePlanAvailable = true;
                            //     }
                            // }
                        }

                        _dataBuilds.Add(plan);
                    }
                }
                else
                {
                    _dataBuilds = plans;
                }



                // // التأكد من أن هناك دائمًا خطة واحدة متاحة على الأقل
                // if (!atLeastOnePlanAvailable)
                // {
                //     var firstAvailablePlan = dataBuilds.FirstOrDefault(p => p.Name.ToLower() != "free");
                //     if (firstAvailablePlan != null)
                //     {
                //         firstAvailablePlan.IsSubscriptionAllowed = true;
                //     }
                // }
            }

            return _dataBuilds;
        }

        public static bool isAllowSubscription(PlanViewModel plan, List<DataBuildUserSubscriptionInfo>? userSubscriptions)
        {

            if (userSubscriptions != null && userSubscriptions.Any())
            {
                // var freeSubscriptions = userSubscriptions?.Any(sub => isFreePlan(plan.Name) && plan.Id == sub.PlanId) == true;
                // bool hasSubscribedToFreeBefore
                var standardSubscriptions = userSubscriptions.Where(sub => sub.PlanId == plan.Id && isStandardPlan(plan.Name)).ToList();
                if (standardSubscriptions?.Any(sub => isActiveSubscription(sub)) == true)
                {
                    int currentYear = DateTimeOffset.Now.Year;
                    int currentMonth = DateTimeOffset.Now.Month;

                    // التحقق مما إذا كان هناك أكثر من عنصر في نفس الشهر الحالي
                    bool hasDuplicateInCurrentMonth = standardSubscriptions
                    .Where(x => x.StartDate.Year == currentYear && x.StartDate.Month == currentMonth) // تصفية الشهر الحالي
                    .GroupBy(x => new { x.StartDate.Year, x.StartDate.Month }) // تجميع حسب السنة والشهر
                        .Any(g => g.Count() > 1);
                    return hasDuplicateInCurrentMonth;
                }
            }

            return true;


        }
        public static bool isActiveSubscription(DataBuildUserSubscriptionInfo subscription)
        {

            return subscription?.Status?.ToLower().Contains("active") ?? false;
        }
        public static bool isStandardPlan(string planName)
        {
            if (string.IsNullOrEmpty(planName))
                return false;
            planName = planName.ToLower();
            return planName.Contains("standard") || planName.Contains("قياسي") || planName.Contains("قياسية") || planName.Contains("قياسيه");

        }
        public static bool isFreePlan(string planName)
        {
            if (string.IsNullOrEmpty(planName))
                return false;

            planName = planName.ToLower();
            return planName.Contains("free") || planName.Contains("مجاني") || planName.Contains("مجانية") || planName.Contains("مجانيه");
        }
    }
}
