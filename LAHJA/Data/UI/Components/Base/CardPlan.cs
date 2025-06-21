using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Components.Base
{


    public enum InputTypePlan
    {
        Single, 
        List    

    }
    public enum DisplayModePlan
    {
        Page,     
        Dialog    
    }



    public class CardPlan<T> : ComponentBaseCard<T>
    {

        public override TypeComponentCard Type => throw new NotImplementedException();
     
        public override void Build(T db)
        {
            DataBuild = db;
        }
        [Parameter]
        public T SingleItem { get; set; }  
        [Parameter]
        public IEnumerable<T> Items { get; set; } = null;
        [Parameter]
        public InputTypePlan InputTypeComponts { get; set; }
        [Parameter]
        public DisplayModePlan DisplayMode { get; set; }
        [Parameter]
        public EventCallback<T> OnSubmit { get ; set; }
        
        string[] errors = { };
        [Parameter]
        public List<string> ErrorMessages
        {

            set
            {
                if (value != null && value.Count() > 0)
                    errors = value.ToArray();
            }
        }

           bool flag = false;

    }
}
