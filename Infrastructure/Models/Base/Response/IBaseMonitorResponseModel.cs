namespace Infrastructure.Models.Base.Response
{
    public partial interface IBaseMonitorResponseModel
    {

        public string ServiceUrl { get; set; }
        public string ServiceToken { get; set; }

    }

}
