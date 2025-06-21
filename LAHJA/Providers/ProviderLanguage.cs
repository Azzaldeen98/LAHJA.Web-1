using Shared.Interfaces;
using System.Globalization;

namespace LAHJA.Providers
{

    public interface IProviderLanguage:ITScope {
        public string Language { get; }
    }

    public class ProviderLanguage : IProviderLanguage {

  
        public string Language => CultureInfo.CurrentUICulture.Name;

    
    }
}
