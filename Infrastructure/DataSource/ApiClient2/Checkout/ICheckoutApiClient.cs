
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


public interface ICheckoutApiClient : ITBaseShareApiClient 
{
    public Task<CheckoutResponse> CreateCheckoutAsync(CheckoutOptions body, CancellationToken cancellationToken);

    public Task<ResponseClientSecret> CreateWebCheckoutAsync(CheckoutWebOptions body, CancellationToken cancellationToken);

    public Task<CheckoutResponse> ManageAsync(SessionCreate body, CancellationToken cancellationToken);

    public Task<ResponseClientSecret> CreateCustomerSessionAsync(PaymentMethodsRequest body, CancellationToken cancellationToken);

    public Task<SessionResponse> SessionStatusAsync(string session_id, CancellationToken cancellationToken);

}

