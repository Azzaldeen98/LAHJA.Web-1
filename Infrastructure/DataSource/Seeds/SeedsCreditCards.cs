using Infrastructure.Models.Billing;
using Infrastructure.Models.Billing.Request;
using Infrastructure.Models.Billing.Response;
using System.Xml.Linq;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsCreditCards
    {
        private readonly List<CardDetailsRequestModel> _cardDetailsList;

        public SeedsCreditCards()
        {
            _cardDetailsList = new List<CardDetailsRequestModel>
        {
            new CardDetailsRequestModel
            {
                CardNumber = "4111111111111111",
                Email = "test@gmail.com",
                ExpirationDate = "12/25",
                CVC = "123",
                CardType = "MasterCard",
                IsSelected = true
            },  
                new CardDetailsRequestModel
            {
                CardNumber = "4111111111111111",
                Email = "azzaldeen771211417@gmail.com",
                ExpirationDate = "12/25",
                CVC = "123",
                CardType = "Visa",
                IsSelected = true
            },   
              new CardDetailsRequestModel
            {
                CardNumber = "4111111111111111",
                Email = "test@gmail.com",
                ExpirationDate = "12/25",
                CVC = "123",
                CardType = "Visa",
                IsSelected = true
            },
            new CardDetailsRequestModel
            {
                CardNumber = "5500000000000004",
                Email = "azzaldeen771211417@gmail.com",
                ExpirationDate = "11/24",
                CVC = "456",
                CardType = "MasterCard",
                IsSelected = false
            },    new CardDetailsRequestModel
            {
                CardNumber = "5500000000000004",
                Email = "test@gmail.com",
                ExpirationDate = "11/24",
                CVC = "456",
                CardType = "Visa",
                IsSelected = false
            }
        };
        }

        // Create
        public void AddCardDetails(CardDetailsRequestModel cardDetails)
        {
            _cardDetailsList.Add(cardDetails);
        }

        // Read
        public List<CardDetailsRequestModel> GetAllCardDetails()
        {
            return _cardDetailsList;
        }

        public CardDetailsRequestModel? GetCardDetailsByCardNumber(string cardNumber)
        {
            return _cardDetailsList.FirstOrDefault(c => c.CardNumber == cardNumber);
        }

        public List<CardDetailsRequestModel>? GetCardDetailsByEmail(string email)
        {
            return _cardDetailsList.Where(c => c.Email == email).ToList();
        }

        // Update
        public bool UpdateCardDetails(CardDetailsRequestModel updatedCard)
        {
            var cardDetails = GetCardDetailsByCardNumber(updatedCard.CardNumber);
            if (cardDetails != null)
            {
                cardDetails.Email = updatedCard.Email;
                cardDetails.ExpirationDate = updatedCard.ExpirationDate;
                cardDetails.CVC = updatedCard.CVC;
                cardDetails.CardType = updatedCard.CardType;
                cardDetails.IsSelected = updatedCard.IsSelected;
                return true;
            }
            return false;
        }

        // Delete
        public bool DeleteCardDetails(string cardNumber)
        {
            var cardDetails = GetCardDetailsByCardNumber(cardNumber);
            if (cardDetails != null)
            {
                _cardDetailsList.Remove(cardDetails);
                return true;
            }
            return false;
        }
    }

}
