using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Components.Base
{



    public class PaymentCard<T> : ComponentBaseCard<T>
    {




        public override TypeComponentCard Type => throw new NotImplementedException();
        public override void Build(T db)
        {

            DataBuild = db;
        }

        [Parameter]
        public EventCallback<T> OnClickSave { get; set; }
        [Parameter]
        public EventCallback<T> OnDelete { get; set; }
        [Parameter]
        public EventCallback<T> OnEdit { get; set; }
        [Parameter]
        public T? Params { get; set; }



    }
}
