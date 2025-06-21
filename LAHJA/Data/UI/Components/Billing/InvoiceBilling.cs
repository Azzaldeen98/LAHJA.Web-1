namespace LAHJA.Data.UI.Billing
{
    

        public class InvoiceBilling
        {

            public string InvoiceNumber { get; set; }
            public DateTime InvoiceDate { get; set; }
            public decimal InvoiceAmount { get; set; }
            public string Currency { get; set; }
            public string Status { get; set; }  
            public DateTime? PaymentDate { get; set; }
            public string PaymentMethod { get; set; }  

           
            public string SubscriptionName { get; set; }  
            public string Address { get; set; } 
            public string City { get; set; }  
            public string State { get; set; }  
            public string ZipCode { get; set; }  
            public string Country { get; set; }  

          
            public string PlanName { get; set; }  
            public string PlanDescription { get; set; } 
            public string BillingCycle { get; set; }  
            public decimal PlanPrice { get; set; }  
            public DateTime PlanStartDate { get; set; }  
            public DateTime PlanEndDate { get; set; }  
      
    }
}
