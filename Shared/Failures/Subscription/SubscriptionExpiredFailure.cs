namespace Shared.Failures.Subscription
{
    /// <summary>
    /// SubscriptionExpiredFailure The subscription exists but has expired (expired).
    /// </summary>
    public class SubscriptionExpiredFailure : SubscriptionFailure
    {
        public SubscriptionExpiredFailure(string message = "انتهت صلاحية الاشتراك. الرجاء التجديد لمتابعة الاستخدام.")
            : base(message)
        {
        }
        public SubscriptionExpiredFailure(int statusCode, string message = "انتهت صلاحية الاشتراك. الرجاء التجديد لمتابعة الاستخدام.") : base(statusCode, message)
        {
        }
    }
}
