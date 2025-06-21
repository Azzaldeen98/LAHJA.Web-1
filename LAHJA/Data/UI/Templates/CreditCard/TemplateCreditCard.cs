using Application.Service.Plans;
using AutoMapper;
using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
 
using Shared.Wrapper;
using IdentityModel.Client;
using Infrastructure.Nswag;
using LAHJA.Data.UI.Components.Payment.DataBuildBillingBase;
using LAHJA.Data.UI.Components.Payment.CreditCard;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Domain.ShareData.Base;

namespace LAHJA.Data.UI.Templates.CreditCard
{

    public class DataBuildCreditCardBase {

        public string CreditCardId  { get; set; }
        public string Email  { get; set; }

        public string SuccessUrl { get; set; } 
        public string CancelUrl { get; set; } 
        public CardDetails? CreditCard { get; set; }
    }


    public interface IBuilderCreditCardComponent<T> : IBuilderComponents<T>
    {

        public Func<T, Task> SubmitActiveCreditCard { get; set; }
        public Func<T, Task> SubmitCreateCreditCardDetails { get; set; }
        public Func<T, Task> SubmitUpdateCreditCardDetails { get; set; }
        public Func<T, Task> SubmitDeleteCreditCardDetails { get; set; }
  


    }



    public interface IBuilderCreditCardApi<T> : IBuilderApi<T>
    {


        //Task<Result<List<InputCategory>>> OnInitialize();



          Task<Result<List<CardDetailsResponse>>> GetCreditCardDetails(T data);
          Task<Result<CardDetailsResponse>> CreateCreditCardDetails(T data);
          Task<Result<CardDetailsResponse>> ActiveCreditCard(T data);
          Task<Result<CardDetailsResponse>> UpdateCreditCardDetails(T data);
          Task<Result<DeleteResponse>> DeleteCreditCardDetails(T data);


    }

    public abstract class BuilderCreditCardApi<T, E> : BuilderApi<T, E>, IBuilderCreditCardApi<E>
    {

        public BuilderCreditCardApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

        //public abstract Task<Result<List<InputCategory>>> OnInitialize();

        public abstract Task<Result<List<CardDetailsResponse>>> GetCreditCardDetails(E data);
        public abstract Task<Result<CardDetailsResponse>> CreateCreditCardDetails(E data);
        public abstract Task<Result<CardDetailsResponse>> ActiveCreditCard(E data);
        public abstract Task<Result<CardDetailsResponse>> UpdateCreditCardDetails(E data);
        public abstract Task<Result<DeleteResponse>> DeleteCreditCardDetails(E data);




    }
    public class BuilderCreditCardComponent<T> : IBuilderCreditCardComponent<T>
    {
        public Func<T, Task> SubmitActiveCreditCard { get; set; }
        public Func<T, Task> SubmitCreateCreditCardDetails { get; set; }
        public Func<T, Task> SubmitUpdateCreditCardDetails { get; set; }
        public Func<T, Task> SubmitDeleteCreditCardDetails { get; set; }
        


    }


    public class TemplateCreditCardShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderCreditCardApi<E> builderApi;
        private readonly IBuilderCreditCardComponent<E> builderComponents;
        public IBuilderCreditCardComponent<E> BuilderComponents { get => builderComponents; }
        public TemplateCreditCardShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderCreditCardComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderCreditCardComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }

     
    public class BuilderCreditCardApiClient : BuilderCreditCardApi<CreditCardClientService, DataBuildCreditCardBase>, IBuilderCreditCardApi<DataBuildCreditCardBase>
    {
        public BuilderCreditCardApiClient(IMapper mapper, CreditCardClientService service) : base(mapper, service)
        {
        }


        public async override Task<Result<CardDetailsResponse>> CreateCreditCardDetails(DataBuildCreditCardBase data)
        {
            var model = Mapper.Map<CardDetailsRequest>(data.CreditCard);
            var res = await Service.UpdateAsync(model);
            return res;
        } 
        
        public async override Task<Result<CardDetailsResponse>> ActiveCreditCard(DataBuildCreditCardBase data)
        {
            var model = Mapper.Map<CardDetailsRequest>(data.CreditCard);
            var res = await Service.UpdateAsync(model);
            return res;
        }

        public async override Task<Result<CardDetailsResponse>> UpdateCreditCardDetails(DataBuildCreditCardBase data)
        {
            var model = Mapper.Map<CardDetailsRequest>(data.CreditCard);
            var res = await Service.UpdateAsync(model);
            return res;
        }
        public async override Task<Result<DeleteResponse>> DeleteCreditCardDetails(DataBuildCreditCardBase data)
        {
          
            var res = await Service.DeleteAsync(data?.CreditCard.CardNumber);
            if (res.Succeeded)
            {
                try
                { 
                    return Result<DeleteResponse>.Success();

                }
                catch (Exception e)
                {
                    return Result<DeleteResponse>.Fail();
                }
            }
            else
            {
                return Result<DeleteResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<CardDetailsResponse>>> GetCreditCardDetails(DataBuildCreditCardBase data)
        {

 
            var res = await Service.GetSubscriptionCreditCardsAsync();
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<CardDetailsResponse>>(res.Data);
                    return Result<List<CardDetailsResponse>>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<List<CardDetailsResponse>>.Fail();
                }
            }
            else
            {
                return Result<List<CardDetailsResponse>>.Fail(res.Messages);
            }
        }

 
    }


    public class TemplateCreditCard : TemplateCreditCardShare<CreditCardClientService, DataBuildCreditCardBase>
    {

   
        public List<string> Errors { get => _errors; }

   


        public TemplateCreditCard(
            IMapper mapper,
            AuthService AuthService,
            CreditCardClientService client,
            IBuilderCreditCardComponent<DataBuildCreditCardBase> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitActiveCreditCard = onSubmitActiveCreditCard;
            this.BuilderComponents.SubmitCreateCreditCardDetails = onCreateCreditCardDetails;
            this.BuilderComponents.SubmitUpdateCreditCardDetails = onUpdateCreditCardDetails;
            this.BuilderComponents.SubmitDeleteCreditCardDetails = onDeleteCreditCardDetails;
       

            this.builderApi = new BuilderCreditCardApiClient(mapper, client);

            //Task.FromResult(OnInitialize());

        }



        public async Task<Result<List<CardDetails>>> GetCreditCardDetails()
        {


            var res = await builderApi.GetCreditCardDetails(new DataBuildCreditCardBase());

            if (res.Succeeded)
            {
                try
                {
                    var map = mapper.Map<List<CardDetails>>(res.Data);
                    return Result<List<CardDetails>>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<List<CardDetails>>.Fail();
                }
            }
            else
            {
                return Result<List<CardDetails>>.Fail(res.Messages);
            }

        }

        public async Task onSubmitActiveCreditCard(DataBuildCreditCardBase DataBuildCreditCardBase)
        {
            try
            {
                var res = await builderApi.CreateCreditCardDetails(DataBuildCreditCardBase);
                if (res.Succeeded)
                {

                }
                else
                {
                    //return Result<CardDetailsResponse>.Fail(res.Messages);
                }

            }
            catch (Exception e)
            {
                //return Result<CardDetailsResponse>.Fail();
            }
           

        }
        
        public async Task onCreateCreditCardDetails(DataBuildCreditCardBase DataBuildCreditCardBase)
        {
            try
            {
                var res = await builderApi.CreateCreditCardDetails(DataBuildCreditCardBase);
                if (res.Succeeded)
                {

                }
                else
                {
                    //return Result<CardDetailsResponse>.Fail(res.Messages);
                }

            }
            catch (Exception e)
            {
                //return Result<CardDetailsResponse>.Fail();
            }
           

        }

        public async Task onUpdateCreditCardDetails(DataBuildCreditCardBase DataBuildCreditCardBase)
        {
            try
            {

                var res = await builderApi.UpdateCreditCardDetails(DataBuildCreditCardBase);
                if (res.Succeeded)
                {
             
                }
                else
                {
                    //return Result<CardDetailsResponse>.Fail(res.Messages);
                }
            }
            catch (Exception e)
            {
                //return Result<CardDetailsResponse>.Fail();
            }

        }
        public async Task onDeleteCreditCardDetails(DataBuildCreditCardBase DataBuildCreditCardBase)
        {
            try
            {
                await builderApi.DeleteCreditCardDetails(DataBuildCreditCardBase);

            }
            catch (Exception e)
            {
                //return Result<CardDetailsResponse>.Fail();
            }

          

        }


        


    }

}
