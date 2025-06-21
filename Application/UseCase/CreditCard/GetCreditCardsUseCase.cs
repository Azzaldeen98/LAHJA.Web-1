using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain;
using Domain.Entities.Billing.Response;
using Domain.Entities.Checkout;
using Domain.Entities.Checkout.Request;
using Domain.Entities.Checkout.Response;
using Domain.Entities.Plans.Response;
using Domain.Repository.Billing;
using Domain.Repository.CreditCard;
using Domain.Repository.Checkout;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Service.Plans
{
    public class GetCreditCardsUseCase
    {

        private readonly ICreditCardRepository repository;
        public GetCreditCardsUseCase(ICreditCardRepository repository)
        {

            this.repository = repository;
        }
    

        public async Task<Result<List<CardDetailsResponse>>> ExecuteAsync()
        {

            return await repository.GetAllAsync();

        }


    }



}