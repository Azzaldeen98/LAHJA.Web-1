using LAHJA.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LAHJA.Data.UI.Components.Payment.CreditCard
{




    public class CardDetails
    {
    
        public string CardNumber { get; set; } = "";
        public string HolderName { get; set; } = "";
        public string CardType { get; set; } = "";

        //[Required(ErrorMessage = "ExpirationDate must be required")]
        //[RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Invalid format. Use MM/YY.")]
        //[CustomValidation(typeof(EventRecordValidator), nameof(EventRecordValidator.ValidateDate))]


        public string ExpirationDate { get; set; } = "";
        public bool IsSelected { get; set; } = false;


        //[Required(ErrorMessage = "CVC must be required")]
        //[MaxLength(4, ErrorMessage = "CVC cannot exceed 4 digits")]
        //[RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVC cannot exceed 4 digits")]


        public virtual string CVC { get=> _cvc; set => _cvc = value; }


        protected string _cvc;

        public string GetCVCBasic() => _cvc;

        public virtual CardDetails GetClone()
        {
            return new CardDetails
            {
                CardNumber = this.CardNumber,
                HolderName = this.HolderName,
                CardType = this.CardType,
                ExpirationDate = this.ExpirationDate,
                IsSelected = this.IsSelected,
                CVC = this._cvc 
            };
        }

        public  CardDetailsVM GetCloneVM()
        {
            return new CardDetailsVM
            {
                CardNumber = this.CardNumber,
                HolderName = this.HolderName,
                CardType = this.CardType,
                ExpirationDate = this.ExpirationDate,
                IsSelected = this.IsSelected,
                CVC = Helper.GetMaskedCVC(_cvc)
            };
        }

    }

    public class CardDetailsVM : CardDetails
    {
        public override string CVC
        {
            get => Helper.GetMaskedCVC(_cvc);
            set => _cvc = value;
        }

        public override CardDetails GetClone()
        {
            return new CardDetails
            {
                CardNumber = this.CardNumber,
                HolderName = this.HolderName,
                CardType = this.CardType,
                ExpirationDate = this.ExpirationDate,
                IsSelected = this.IsSelected,
                CVC = this._cvc 
            };
        }

    }




}


