using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace LAHJA.Data.UI.Components.Base
{
    public class UiProviderInfo: ComponentBase
    {
        public string lg { get; set; } = CultureInfo.CurrentUICulture.Name;
    }
}
