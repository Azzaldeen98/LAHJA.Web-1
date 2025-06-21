

namespace LAHJA.Data.UI.Components.Payment.CreditCards
{
    public class CreditCardInput
    {

        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CardHolder { get; set; }
        public string CardType { get; set; }
    }


    public class CreditCardDisplay
    {
        public string CardNumber { get; set; }     
        public string ExpiryDate { get; set; }    
        public string CardHolder { get; set; }    
        public string CardType { get; set; }     
        public bool IsSelected { get; set; }      
    }
}
