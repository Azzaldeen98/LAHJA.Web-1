namespace AutoGenerator.Config.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ValidatorEnabledAttribute : Attribute
    {
        public bool IsValidatorped { get; set; }

        // Constructor to define whether Validatorping is enabled or not.
        public ValidatorEnabledAttribute(bool isValidatorped = true)
        {
            IsValidatorped = isValidatorped;
        }
    }




}
