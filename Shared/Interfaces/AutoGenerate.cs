
namespace Shared.Interfaces;

    public interface ITBase { }
    public interface ITModel : ITBase { }
    public interface ITDto : ITBase { }
    public interface ITDso : ITBase { }
    public interface ITVM : ITBase { }
    public interface ITException : ITBase { }
    public interface ITApiClient : ITBase { }
    public interface ITBaseApiClient : ITApiClient { }
    public interface ITBuildApiClient : ITApiClient { }
    public interface ITBaseShareApiClient : ITApiClient, ITScope { }
    public interface ITShareDto : ITDto { }
    public interface ITBuildDto : ITDto { }

    public interface ISharDso : ITDso { }
    public interface IBuildDso : ITDso { }

    public interface ISharVM : ITVM { }
    public interface IBuildVM : ITVM { }

    public interface ITTransient : ITBase { }
    public interface ITSingleton : ITBase { }
    public interface ITUseCase : ITBase { }
    public interface ITBaseUseCase : ITUseCase { }
    public interface ITSharUseCase : ITUseCase, ITScope { }
    public interface ITBuildUseCase : ITUseCase { }
    public interface ITInterceptor : ITBase { }
    public interface ITScope : ITBase { }
    public interface ITRepository : ITBase { }
    public interface ITBaseRepository : ITRepository { }
    public interface ITBuildRepository : ITRepository { }
    public interface ITBaseShareRepository : ITRepository, ITScope { }
    public interface ITService : ITBase{ }
    public interface ITBaseService : ITService{ }
    public interface ITBaseShareService : ITBaseService, ITScope { }
    public interface ITranslationData
    {
        Dictionary<string, string>? Value { get; set; }
        string? ToFilter(string? lg);
    }

    public interface ITUser { }
    public interface ITRole { }
    public interface ITClaimsHelper { }




