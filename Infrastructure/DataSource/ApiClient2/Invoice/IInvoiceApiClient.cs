
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IInvoiceApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<InvoiceOutputVM>> GetInvoicesAsync(CancellationToken cancellationToken);

    public Task<InvoiceOutputVM> CreateInvoiceAsync(InvoiceCreateVM body, CancellationToken cancellationToken);

    public Task<InvoiceOutputVM> UpdateInvoiceAsync(InvoiceUpdateVM body, CancellationToken cancellationToken);

    public Task<InvoiceInfoVM> GetInvoiceAsync(string id, CancellationToken cancellationToken);

    public Task DeleteInvoiceAsync(string id, CancellationToken cancellationToken);

    public Task<InvoiceOutputVM> GetInvoiceByLgAsync(InvoiceFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<InvoiceOutputVM>> GetInvoicesByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<InvoiceOutputVM>> CreateRange7Async(IEnumerable<InvoiceCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountInvoiceAsync(CancellationToken cancellationToken);

}

