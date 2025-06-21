namespace Infrastructure.Models.Base.Response
{
    public partial class BaseMonitorResponseModel: IBaseMonitorResponseModel
    {

        public string ServiceUrl { get; set; }
        public string ServiceToken { get; set; }

    }

}
