using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Components.Base
{


    public enum TypeIBillingCard
    {
        Header,
        Body
        
    }
    public interface IBillingBaseComponentCard :IStyleBaseComponentCard
    {
       

    }
    public class CardBilling<T> : ComponentBaseCard<T>
    {
        public override TypeComponentCard Type => throw new NotImplementedException();

        public override void Build(T db)
        {
            DataBuild = db;
        }

        [Parameter]
        public T Param { get; set; }
        [Parameter]
        public IEnumerable<T> Params { get; set; } = null;
        [Parameter]
        public EventCallback<T> OnClick { get; set; }
      



    }
}
