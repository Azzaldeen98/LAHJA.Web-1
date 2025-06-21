namespace Shared.Failures.Auth
{

    /// <summary>
    /// 403 Forbidden The user is recognized, but does not have permission to perform this request or access this resource.
    /// </summary>
    public class ForbiddenFailure : AuthFailure
    {
        public ForbiddenFailure(string message = "ليس لديك صلاحية الوصول إلى هذا المورد.")
            : base(message)
        {
        }
    }

}