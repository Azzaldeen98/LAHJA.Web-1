using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Data.UI.Models.Space
{
    public class DataBuildSpace
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ram { get; set; }
        public int CpuCores { get; set; }
        public int DiskSpace { get; set; }
        public bool IsGpu { get; set; }
        public bool IsGlobal { get; set; }
        public int Bandwidth { get; set; }
        public string? ServiceId { get; set; }

        public RenderFragment Dash { get; set; } = builder => builder.AddContent(0, b =>
            {
                b.OpenComponent<MudButton>(0);
                b.AddAttribute(1, "Variant", Variant.Text);
                b.AddAttribute(2, "StartIcon", Icons.Material.Filled.Person);
                b.AddAttribute(3, "ChildContent", (RenderFragment)(c => c.AddContent(0, "الملف الشخصي")));
                b.CloseComponent();
            });
    }



}
