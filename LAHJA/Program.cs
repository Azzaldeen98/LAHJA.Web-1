using LAHJA;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using MudBlazor.Services;
using Blazorise.Captcha.ReCaptcha;
using Blazorise;
using Infrastructure;
using Shared.Settings;
using Shared;
using Shared.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Models;
using LAHJA.Helpers.Services;
using Domain.ShareData;
using LAHJA.ApiClient;
using Microsoft.AspNetCore.ResponseCompression;
using LAHJA.Notification;
using Microsoft.AspNetCore.Mvc.Razor;
using Blazored.LocalStorage;
using Shared.Services.Infrastructure.Extensions;
using FluentValidation;
using LAHJA.Validators;
using LAHJA.Data.UI.Components.Base;
using System.Reflection;
using Domain;
using AutoGenerator;
using Client.Shared;
using Shared.LocalStorage;
using AutoGenerator.Config;
using AutoGenerator.AppFolder;
using LAHJA.Generator.Config;
using LAHJA.UI.Components.General.DialogBox;
using Client.Shared.Execution;
using Infrastructure.DataSource.ApiClientFactory;
using Microsoft.Extensions.DependencyInjection;
using LAHJA.Config;
using Shared.Constants;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //builder.Services.Configure<ApiKeysSettings>(builder.Configuration.GetSection("ApiKeys"));
        //var apiKeysSettings = builder.Configuration.GetSection("ApiKeys").Get<ApiKeysSettings>();
        //ApiKeys.Initialize(apiKeysSettings);

        // Retrieve the "BaseUrls" section from the configuration and bind it to a strongly typed object
        var baseUrl = builder.Configuration
                              .GetSection(ConstantsApp.Settings.BASE_URL)
                              .Get<BaseUrl>();

        // Register an HttpClient named "API_CLIENT_NAME" and configure its base address
        builder.Services.AddHttpClient(ConstantsAPI.API_CLIENT_NAME, client =>
        {
            client.BaseAddress = new Uri(baseUrl.Api); // Set the base URL for API requests
        });

        // Register additional API client factory configuration (e.g., handlers, logging, policies)
        ApiClientFactoryConfigServices.InstallConfiguration(builder.Services, builder.Configuration);


        // Load and register all required assemblies across the application layers
        var assemblies = new Assembly[]
        {
                // The currently executing assembly (usually the ASP.NET Core Web App project)
                ApplicationAssemblies.AssemblyWebApp = Assembly.GetExecutingAssembly(),

                // Shared code between client and server, like DTOs or common interfaces
                ApplicationAssemblies.AssemblyClientShared = typeof(IClientSharedMarker).Assembly,

                // Assembly responsible for auto-generation (e.g., scaffolding or code generators)
                ApplicationAssemblies.AssemblyAutoGenerator = typeof(IAutoGeneratorMarker).Assembly,

                // Shared layer used across multiple other layers (e.g., constants, helpers)
                ApplicationAssemblies.AssemblyShared = typeof(ISharedLayerMarker).Assembly,

                // Domain layer that holds business rules and domain models
                ApplicationAssemblies.AssemblyDomain = typeof(IDomainLayerMarker).Assembly,

                // Application layer for application services, commands, and use cases
                ApplicationAssemblies.AssemblyApplication = typeof(IApplicationLayerMarker).Assembly,

                // Infrastructure layer (e.g., database, external APIs, logging implementations)
                ApplicationAssemblies.AssemblyInfrastructure = typeof(IInfrastructureLayerMarker).Assembly
        };




        builder.Services.AddScoped<ProtectedLocalStorage>();
        builder.Services.AddScoped<ProtectedSessionStorage>();
        builder.Services.AddScoped<IProtectedStorage, ProtectedCookieStorage>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<ISessionUserManager, SessionUserManager>();
        builder.Services.AddScoped<ICancelableTaskExecutor, CancelableTaskExecutor>();



        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        var buildLogger = loggerFactory.CreateLogger("Web");

        //await AutoGeneratorAppFactory.GenerateAsync("Application");

        //await AutoGeneratorAppFactory.GenerateAsync("Web");


        if (args.Length > 0 && args[0].Equals("generate", StringComparison.OrdinalIgnoreCase))
        {
            buildLogger.LogInformation("Start Auto Generator");

            if (args.Length < 2)
            {
                await AutoGeneratorAppFactory.GenerateAsync("Infrastructure");
                await AutoGeneratorAppFactory.GenerateAsync("Application");
                await AutoGeneratorAppFactory.GenerateAsync("Web");
                buildLogger.LogError("No valid generator name provided. Please specify 'all', 'infrastructure', 'application', or 'web'.");
                //return;
            }
            else
            {
                // args[1] تحتوي على نوع التوليد المطلوب
                string target = args[1].ToLower();

                switch (target)
                {
                    case "all":
                        await AutoGeneratorAppFactory.GenerateAsync("Infrastructure");
                        await AutoGeneratorAppFactory.GenerateAsync("Application");
                        await AutoGeneratorAppFactory.GenerateAsync("Web");
                        break;

                    case "infrastructure":
                        await AutoGeneratorAppFactory.GenerateAsync("Infrastructure");
                        break;

                    case "application":
                        await AutoGeneratorAppFactory.GenerateAsync("Application");
                        break;

                    case "web":
                        await AutoGeneratorAppFactory.GenerateAsync("Web");
                        break;

                    default:
                        buildLogger.LogError($"Invalid generator target: '{target}'. Please specify 'all', 'infrastructure', 'application', or 'web'.");
                        break;
                }
            }
        }

        builder.Services.AddAutoMapper(cfg =>
        {
            var logger = loggerFactory.CreateLogger("AutoMappingConfig");
            if(logger!=null)
                cfg.AddProfile(new AutoMappingConfig(logger));
        });

        ////////////////////////////////////////////////////

        // Register all services in all specified assemblies of type (Singleton - Scoped - Transient)
        // that inherit from the following interfaces (ITScope, ITTransient, ITSingleton)
        builder.Services.RegisterServicesByLifetimes(assemblies, buildLogger);


        //builder.Services.RegisterServicesByLifetime();




        builder.Services.AddScoped<IUserClaimsHelper, UserClaimsHelper>();
        ////////////////////////////////////////////////////

        builder.Services.InstallSharedConfigServices();
        builder.Services.InstallInfrastructureConfigServices(configuration: builder.Configuration);
        builder.Services.InstallApplicationConfigServices();
        builder.Services.InstallLAHJAConfigServices();
        builder.Services.InstallApiClientConfigServices();

        // تهيئة التسجيل (Logging)
        builder.Logging.ClearProviders(); // مسح مقدمي الخدمة الافتراضيين
        builder.Logging.AddConsole(); // إضافة تسجيل في وحدة التحكم
        builder.Logging.AddDebug(); // تسجيل الأخطاء في نافذة التصحيح




        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");



        builder.Services.AddRazorPages()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

        // تسجيل IHttpContextAccessor لاستخدام HttpContext داخل Blazor
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddBlazoredLocalStorage();

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();


        builder.Services.AddAuthorizationCore();  // تسجيل تفويض المستخدمين
        builder.Services.AddAuthorization();  // تسجيل خدمات التفويض بشكل كامل
        builder.Services.AddCascadingAuthenticationState();  // تسجيل حالة المصادقة
        builder.Services.AddScoped<CustomAuthenticationStateProvider>();  // تسجيل موفر حالة المصادقة المخصص
        builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());



        // Add services to the container.  
        var jwtSettings = builder.Configuration.GetSection("JWTSettings").Get<JWTSettings>();
        builder.Services.AddSingleton(jwtSettings);



        builder.Services.Configure<ReCaptchaSettings>(builder.Configuration.GetSection("ReCaptchaSettings"));
        builder.Services.AddOptions<ReCaptchaSettings>().BindConfiguration("ReCaptchaSettings");

        ///////////////////////////////////////////////////


        builder.Services.AddValidatorsFromAssemblyContaining<Program>(); // تسجيل الـ Validators من نفس التجميع
        builder.Services.AddScoped<IValidator<DataBuildAuthBase>, LoginModelValidator>();



        ///////////////////////////////////////////////////////TODO
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(options =>
        {
            options.LoginPath = "/Login";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Strict;
        });




        builder.Services
            .AddBlazorise(options =>
            {
                options.Immediate = true;
            })
            .AddBlazoriseGoogleReCaptcha(reCaptchaOptions =>
            {
                reCaptchaOptions.SiteKey = "dddddddgffee";
                //Set any other ReCaptcha options here...
            });





        builder.Services.AddMudBlazorSnackbar(config =>
        {
            config.PositionClass = Defaults.Classes.Position.BottomRight;
            config.PreventDuplicates = true;
            config.NewestOnTop = true;
            config.ShowCloseIcon = true;
            config.VisibleStateDuration = 5000; // ��� ��� ������� (3 �����)
            config.SnackbarVariant = Variant.Text; // ����� �����
        });



        // جلب المفتاح من متغير البيئة
        //var key = Environment.GetEnvironmentVariable("6Ld41JsqAAAAAEvJSBeM48mCbu3ndltGRi7u06gU");

        //builder.Services.AddDataProtection()
        //    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "App_Data"))) // حفظ المفاتيح في مجلد آمن
        //    .ProtectKeysWithDpapi() 
        //    .SetApplicationName("LAHJA");




        builder.Services.AddServerSideBlazor()
            .AddCircuitOptions(options => { options.DetailedErrors = true; });

        builder.Services.AddMudServices();


        ///  تفعيل الجلسات (Sessions)
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromDays(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddSignalR();
        builder.Services.AddSingleton<UserContextService>();  // ����� UserContextService
        builder.Services.AddSingleton<NotificationService>();

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ConfigureHttpsDefaults(o => o.AllowAnyClientCertificate());
        });

        builder.Services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/octet-stream"]);
        });

        //builder.Services.RegisterInterceptorServices<ITInterceptor, ErrorHandlingInterceptor>();

        //builder.Services.AddSingleton<NavigationManager>(sp => sp.GetRequiredService<NavigationManager>());

        //PreProcessingNSwagCode.Run("NSwageCode.txt", "..\\Infrastructure\\DataSource\\ApiClientFactory\\Nswag\\WebClientApi2.cs");

        var app = builder.Build();


        // الحصول على `ILogger` من DI (Dependency Injection)
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("The application started running...");


        //app.UseMiddleware<ApiInvoker>();


        //app.UseMiddleware<ErrorHandlerMiddleware>();

        //app.UseMiddleware<AuthMiddleware>();
        //NavigationHelper.Init(app.Services);

        //var supportedCultures = new[] { "en", "ar" };
        var supportedCultures = builder.Configuration.GetSection("Cultures")
              .GetChildren().ToDictionary(x => x.Key, x => x.Value).Keys.ToArray();
        var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        //


        app.UseRequestLocalization(localizationOptions);

        app.UseResponseCompression();


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }



        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("Content-Security-Policy", "frame-ancestors 'none';");
            await next();
        });
        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseRouting();
        app.UseSession();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<NotificationHub>("/notificationHub"); // SignalR Hub
        });
        //await ATTK.Load();
        app.Run();
    }
}