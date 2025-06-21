using AutoGenerator.Enums;

namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class RegisterValidatorAttribute: Attribute
    {
        //public ValidatorType ValidatorType { get; }
        public string ValidatorName { get; }

        public RegisterValidatorAttribute(string validatorName,string placeValidate)
        {

        }
        //public RegisterValidatorAttribute(ValidatorType validatorType,string validatorName)
        //{
        //    ValidatorType = validatorType;
        //    ValidatorName = validatorName;
            
        //}
    }




}
