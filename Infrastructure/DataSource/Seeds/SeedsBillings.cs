using Domain.Entities.Plans.Response;
using Infrastructure.Models.Billing.Request;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsBillings
    {

    
        private readonly List<BillingDetailsRequestModel> _billingDetailsList;

        public SeedsBillings()
        {
            // Initialize with seed data
            _billingDetailsList = new List<BillingDetailsRequestModel>
        {
            new BillingDetailsRequestModel
            {
                Id ="1213123",
                FullName = "test Doe",
                Email = "test@gmail.com",
                MobilePhoneNumber = "123-456-7890",
                Address1 = "123 Main St",
                City = "New York",
                State = "NY",
                ZipCode = "10001",
                Country = "USA",
                Currency = "USD"
            },
            new BillingDetailsRequestModel
            {    Id ="12131236",
                FullName = "azzaldeen mansour",
                Email = "azzaldeen771211417@gmail.com",
                MobilePhoneNumber = "234-567-8901",
                Address1 = "456 Oak St",
                City = "Los Angeles",
                State = "CA",
                ZipCode = "90001",
                Country = "USA",
                Currency = "USD"
            },
            new BillingDetailsRequestModel
            {    Id ="12131237",
                FullName = "Alice Johnson",
                Email = "test2@gmail.com",
                MobilePhoneNumber = "345-678-9012",
                Address1 = "789 Pine St",
                City = "Chicago",
                State = "IL",
                ZipCode = "60601",
                Country = "USA",
                Currency = "USD"
            }
        };
        }

        // Create
        public void AddBillingDetails(BillingDetailsRequestModel billingDetails)
        {
            _billingDetailsList.Add(billingDetails);
        }

        // Read
        public List<BillingDetailsRequestModel> GetAllBillingDetails()
        {
            return _billingDetailsList;
        }

        public BillingDetailsRequestModel? GetBillingDetailsByEmail(string email)
        {
            return _billingDetailsList.FirstOrDefault(b => b.Email == email);
        }

        // Update
        public bool UpdateBillingDetails(BillingDetailsRequestModel updatedDetails)
        {
            var billingDetails = GetBillingDetailsByEmail(updatedDetails.Email);
            if (billingDetails != null)
            {
                billingDetails.FullName = updatedDetails.FullName;
                billingDetails.MobilePhoneNumber = updatedDetails.MobilePhoneNumber;
                billingDetails.Address1 = updatedDetails.Address1;
                billingDetails.Address2 = updatedDetails.Address2;
                billingDetails.City = updatedDetails.City;
                billingDetails.State = updatedDetails.State;
                billingDetails.ZipCode = updatedDetails.ZipCode;
                billingDetails.Country = updatedDetails.Country;
                billingDetails.BillingRegistrationNumber = updatedDetails.BillingRegistrationNumber;
                billingDetails.VatNumber = updatedDetails.VatNumber;
                billingDetails.Currency = updatedDetails.Currency;
                return true;
            }
            return false;
        }

        // Delete
        public bool DeleteBillingDetails(string email)
        {
            var billingDetails = GetBillingDetailsByEmail(email);
            if (billingDetails != null)
            {
                _billingDetailsList.Remove(billingDetails);
                return true;
            }
            return false;
        }
    }

}
