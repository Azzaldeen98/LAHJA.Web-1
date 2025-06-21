 
using System.ComponentModel.DataAnnotations;

namespace CardShopping.Web.VitsModel 
{
    public class InputPlance
    {
        [Required(ErrorMessage = "Product name is Required")]
        public string PlanceName { get; set; }
        [Required(ErrorMessage = "Product id is Required")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Price id is Required")]
        public string PriceId { get; set; }
        [Range(10, int.MaxValue, ErrorMessage = "The number must be greater than 10")]
        public int NumberRequests { get; set; }
        [Required(ErrorMessage = "Product name is Required")]
        public string Features { get; set; }
        [Required(ErrorMessage = "Product name is Required")]
        public string PaymentPeriod {  get; set; }
    }
}
