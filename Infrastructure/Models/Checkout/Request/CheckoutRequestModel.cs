namespace Infrastructure.Models.Checkout.Request
{
    public class CheckoutRequestModel
    {
        public string? PlanId { get; set; }
        public string? SuccessUrl { get; set; }
        public string? CancelUrl { get; set; }

    }



}
