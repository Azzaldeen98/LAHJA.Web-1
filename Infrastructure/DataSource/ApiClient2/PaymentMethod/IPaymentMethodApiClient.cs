
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


public interface IPaymentMethodApiClient : ITBaseShareApiClient 
{
    public Task<ICollection<PaymentMethodResponse>> GetMethodsAsync(CancellationToken cancellationToken);

    public Task<CustomerResponse> UpdateBillingInformationAsync(BillingInformationRequest body, CancellationToken cancellationToken);

    public Task MakePaymentMethodDefaultAsync(string paymentMethodId, CancellationToken cancellationToken);

    public Task DeleteMethodAsync(string id, CancellationToken cancellationToken);

    public Task GetSetupIntentsAsync(CancellationToken cancellationToken);

    public Task CancelAsync(string id, CancellationToken cancellationToken);

    public Task ConfirmAsync(string id, CancellationToken cancellationToken);

    public Task<ResponseClientSecret> CreatePaymentMethodAsync(PaymentMethodsRequest body, CancellationToken cancellationToken);

}

