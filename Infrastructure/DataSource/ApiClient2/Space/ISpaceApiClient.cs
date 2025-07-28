using Infrastructure.Nswag;
using Shared.Interfaces;
namespace Infrastructure.DataSource.ApiClient2;


public interface ISpaceApiClient :  ITBaseShareApiClient  
{
    public Task<ICollection<SpaceOutputVM>> GetSpacesAsync(CancellationToken cancellationToken);

    public Task<SpaceOutputVM> CreateSpaceAsync(SpaceCreateVM body, CancellationToken cancellationToken);

    public Task<SpaceOutputVM> GetSpaceAsync(string id, CancellationToken cancellationToken);

    public Task<SpaceOutputVM> UpdateSpaceAsync(string id, SpaceUpdateVM body, CancellationToken cancellationToken);

    public Task DeleteSpaceAsync(string id, CancellationToken cancellationToken);

    public Task<SpaceOutputVM> GetSpaceByLgAsync(SpaceFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<SpaceOutputVM>> GetSpacesByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<SpaceOutputVM>> CreateRange16Async(IEnumerable<SpaceCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountSpaceAsync(CancellationToken cancellationToken);

}

