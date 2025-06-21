using System.ComponentModel.DataAnnotations;

namespace Domain.ShareData.Base.Billing
{
    public class BillingDetailsBase
    {

        public string? Id { get; set; } 
        public string? FullName { get; set; } 
        public string? Email { get; set; } 
        public string? SecondaryEmail { get; set; } 
        public string? MobilePhoneNumber { get; set; } 
        public string? Address1 { get; set; } 
        public string? Address2 { get; set; } 
        public string? City { get; set; } 
        public string? State { get; set; }
        public string? ZipCode { get; set; } 
        public string? Country { get; set; } 
        public string? BillingRegistrationNumber { get; set; } 
        public string? VatNumber { get; set; } 
        public string? Currency { get; set; } 
    }
}
