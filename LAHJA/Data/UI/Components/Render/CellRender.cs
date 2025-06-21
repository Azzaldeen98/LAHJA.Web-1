using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Data.UI.Components.Render
{
    public class CellRender : BaseCellRender, ICellRender
    {
       
   
        public override void Create(object data)
        {

            fragment= builder => builder.AddContent(0, (RenderFragment)(b =>
            {
                b.OpenComponent<MudButton>(0);
                b.AddAttribute(1, "Variant", Variant.Text);
                b.AddAttribute(2, "StartIcon", Icons.Material.Filled.Person);
                b.AddAttribute(3, "ChildContent", (RenderFragment)(c => c.AddContent(0, "الملف الشخصي")));
                b.CloseComponent();
            }));
        

        }

        public override RenderFragment View()
        {
            return fragment;
        }


     
    }
}
