namespace Shared.Failures.Subscription
{

    /// <summary>
    /// SubscriptionUnavailableFailure There is no subscription or 
    /// its information is currently inaccessible (service failure or no associated subscription).
    /// </summary>
    public class SubscriptionUnavailableFailure : SubscriptionFailure
    {
        public SubscriptionUnavailableFailure(string message = "لا يتوفر اشتراك نشط لهذا الحساب.")
            : base(message)
        {
        }

        public SubscriptionUnavailableFailure(int statusCode, string message = "لا يتوفر اشتراك نشط لهذا الحساب."): base(statusCode,message)
        {
        }  
        public SubscriptionUnavailableFailure(string statusCode, string message = "لا يتوفر اشتراك نشط لهذا الحساب.")
            : base(ParseStatusCode(statusCode),message)
        {
        }
    }
}
