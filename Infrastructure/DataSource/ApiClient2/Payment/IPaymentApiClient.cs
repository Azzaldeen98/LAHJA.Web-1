
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


public interface IPaymentApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<PaymentOutputVM>> GetPaymentsAsync(CancellationToken cancellationToken);

    public Task<PaymentOutputVM> CreatePaymentAsync(PaymentCreateVM body, CancellationToken cancellationToken);

    public Task<PaymentOutputVM> UpdatePaymentAsync(PaymentUpdateVM body, CancellationToken cancellationToken);

    public Task<PaymentInfoVM> GetPaymentAsync(string id, CancellationToken cancellationToken);

    public Task DeletePaymentAsync(string id, CancellationToken cancellationToken);

    public Task<PaymentOutputVM> GetPaymentByLgAsync(PaymentFilterVM body, CancellationToken cancellationToken);

    public Task<ICollection<PaymentOutputVM>> GetPaymentsByLgAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<PaymentOutputVM>> CreateRange11Async(IEnumerable<PaymentCreateVM> body, CancellationToken cancellationToken);

    public Task<int> CountPaymentAsync(CancellationToken cancellationToken);

}

