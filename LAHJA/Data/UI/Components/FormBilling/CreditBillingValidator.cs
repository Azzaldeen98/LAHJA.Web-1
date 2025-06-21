namespace LAHJA.Data.UI.Components.Billing
{
    public class CreditBillingValidator
    {


        public List<string> Errors { get; private set; } = new List<string>();



        public bool Validate(CreditBilling contact)
        {
            Errors.Clear();

            if (string.IsNullOrWhiteSpace(contact.FullName))
                Errors.Add("Full name is required.");

            if (string.IsNullOrWhiteSpace(contact.Email) || !IsValidEmail(contact.Email))
                Errors.Add("Invalid email address.");

            if (string.IsNullOrWhiteSpace(contact.Phone) || !IsValidPhone(contact.Phone))
                Errors.Add("Invalid phone number.");

            if (string.IsNullOrWhiteSpace(contact.Address))
                Errors.Add("Address is required.");

            if (string.IsNullOrWhiteSpace(contact.City))
                Errors.Add("City is required.");

            if (string.IsNullOrWhiteSpace(contact.Country))
                Errors.Add("Country is required.");

            return !Errors.Any();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 10;  
        }
    }
}
