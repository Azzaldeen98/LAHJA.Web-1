using AutoMapper;
using Client.Shared.Execution;
using Client.Shared.Providers;
using Infrastructure.Middlewares;
using LAHJA.Helpers;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using Shared.Constants.Localization;
using Shared.Wrapper;
using System.Globalization;

namespace LAHJA.Data.UI.Templates.Base;


public  enum TypeTemplate
{
    Base
}


public  interface IBuilderApi<T>
{
    

}

public interface IBuilderComponents<T>
{
}

public class BuilderApi<T,E> : IBuilderApi<E> 
{
    protected readonly IMapper Mapper;
    protected readonly T Service;
    public readonly LanguageCode Language;

    //[Inject] protected CultureInfo CultureInfo { get; set; }
    
    public BuilderApi(IMapper mapper, T service) { 
        Mapper = mapper;
        Service = service;
        Language = new LanguageCode{ Code = CultureInfo.CurrentUICulture.Name ?? "en" };
    }

    protected async Task<Result<TResult>> ExecuteSafeAsync<TResult>(Func<Task<TResult>> func)
    {
        try
        {
            var result = await func();
            return Result<TResult>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<TResult>.Fail(ex.Message);
        }
    }


    public object GetInstance() => this;
}

public class BuilderComponents<T> : IBuilderComponents<T>
{
  
}
public interface ITemplateBase<T,E>
{
    bool IsActive { set; get; }
    TypeTemplate Type { get; }
    List<string> Errors { get; }



}


public abstract class TemplateBase<T,E> : ITemplateBase<T, E>
{

    public bool IsActive { get; set; }
    public List<string> Errors => _errors;


    public TypeTemplate Type { get=> TypeTemplate.Base; }

    protected readonly IMapper mapper;
    protected readonly AuthService authService;
    protected readonly ISafeInvoker safeInvoker;
    protected readonly ICancelableTaskExecutor taskExecutor;

    protected readonly T client;

    protected List<string> _errors;


    public TemplateBase(IMapper mapper, AuthService authService, T client)
    {

        this.mapper = mapper;
        _errors = new List<string>();
        this.authService = authService;
        this.client = client;

    }

    public TemplateBase(IMapper mapper, AuthService authService, T client, ISafeInvoker safeInvoker) : this(mapper, authService, client)
    {

        this.safeInvoker = safeInvoker;
    }

    public TemplateBase(IMapper mapper, AuthService authService, T client, ISafeInvoker safeInvoker, ICancelableTaskExecutor taskExecutor) 
        : this(mapper, authService, client,safeInvoker)
    {
        this.taskExecutor = taskExecutor;
    }

    protected void AddError(string message)
    {
        if (!_errors.Contains(message))
            _errors.Add(message);
    }
}





