using Domain.ShareData.Base;
using LAHJA.ContextServices;
using LAHJA.Data.UI.Models.SessionTokenAuth;
using LAHJA.Data.UI.Templates.AuthSession;
using LAHJA.Data.UI.Templates.Services;
using LAHJA.Data.UI.Templates.Subscription;
using LAHJA.Helpers;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants.Router;
using System.Globalization;

namespace LAHJA.Data.UI.Components.StudioLahjaAiVM
{
    public class StudioAi: StudioAiCard<DataBuildStudioBase>
    {

        [Inject] TemplateAuthSession templateAuthSession { get; set; }
        [Inject] public SecureComponentService secureComponentService { get; set; }

        [Inject] public TemplateServices templateServices { get; set; }
        [Inject] public TemplateSubscription subscription  { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        public static bool IsDialogBox = false;


        protected override async Task OnInitializedAsync()
        {
            await subscription.HasActiveSubscriptionAsync();
        }


        protected string _srcFrame;
        protected string Lg { get => CultureInfo.CurrentUICulture.Name; }

        protected bool isLoading = true;
        protected string UrlCancel{ get => Helper.GetFullPath(Navigation, RouterPage.STUDIO); }
        //protected string UrlRedirect { get => Helper.GetFullPath(Navigation, RouterPage.STUDIO); }

        [Parameter] public string SrcIFrame { get=> _srcFrame; set=> _srcFrame=value; }
     
        [Parameter] public string ServiceId { get; set; }
        [Parameter] public string UrlPage { get; set; }

        [Parameter]
        public string CurrentLanguage { get=> base.CurrentLanguage; set=> base.CurrentLanguage=value; }

        [Parameter]
        public SelectedStudioFilter DataBuildSelected { get => selectedStudioFilter; set {

                if (value != null)
                {
                    selectedStudioFilter = value;

                    DataBuild.CategoriesFilter.Options  = new List<FilterItemData> { selectedStudioFilter.SelectedCategory ?? new() };
                    DataBuild.LanguagesFilter.Options = new List<FilterItemData> { selectedStudioFilter.SelectedLangague ?? new() };
                    DataBuild.ModelTypesFilter.Options = new List<FilterItemData> { selectedStudioFilter.SelectedModelType ?? new() };
                    DataBuild.DialectsFilter.Options = new List<FilterItemData> { selectedStudioFilter.SelectedDialectType ?? new() };
                    DataBuild.ModelReleasesFilter.Options = new List<FilterItemData> { selectedStudioFilter.SelectedModelRelease ?? new() };
                    DataBuild.ServiceTypeFilter.Options = new List<FilterItemData> { selectedStudioFilter.SelectedServiceType ?? new() };
                    DataBuild.SpeakerGendersFilter.Options = new List<FilterItemData> { selectedStudioFilter.SelectedSpeakerGenders ?? new() };
                    DataBuild.SpeakerNameFilter.Options = new List<FilterItemData> { selectedStudioFilter.SelectedSpeakerName??new() };

                    StateHasChanged();
                }
               
            } }

        [Parameter]
        public TypeStudioAiService TypeStudioAiService { get; set; }



        [Parameter]
        public DataBuildStudioBase DataFiltersBuild
        {
            get => DataBuild; set
            {

                DataBuild = value;

                InitializeChangedEvents();
                StateHasChanged();
            }
        }

        //protected DataBuildStudioBase DataBuild;

        protected SelectedStudioFilter selectedStudioFilter = new SelectedStudioFilter();
    

        //protected string url_cancel= $"{RouterPage.STUDIO}/start";

        protected void OnFrameLoaded()
        {
            isLoading = false;
        }
        protected  async Task CreateSessionTokenAsync()
        {
        
                if (!string.IsNullOrEmpty(ServiceId))
                {
                    if (templateAuthSession.BuilderComponents.GetSessionsAccessTokens != null)
                    {
                        var response = await templateAuthSession.BuilderComponents.GetSessionsAccessTokens();

                        if (response.Succeeded)
                        {
                            foreach (var token in response.Data)
                            {
                                if (token != null && token.ServiceId == ServiceId )
                                {
                                    if(token.IsActive){
                                        await CreateSessionAsync(ServiceId);
                                }
                                else
                                {
                                    Snackbar.Add("Session key is not active. Enable it or create a new one.",Severity.Error);
                                }
                                    return;
                               
                                }
                            }

                        }

                        await CreateSessionAsync(ServiceId);
                    }
                }
           
        }
        public  async Task CreateSessionAsync(string serviceId)
        {
            if (templateAuthSession.BuilderComponents.GetSessionsAccessTokens != null) { 
                var res = await templateAuthSession.BuilderComponents.SubmitCreateSessionToken(new DataBuildSessionTokenAuth { ServiceId = serviceId });
                if (res.Succeeded)
                {
                    //var theme = await sessionUserManager.GetThemeAsync();
                     //lg = CultureInfo.CurrentUICulture.Name;
                    //var urlRedirect = Helper.GetFullPath(Navigation, UrlPage);
                    _srcFrame = Helper.GetServiceSrcFrame(res.Data.UrlCore, res.Data.SessionToken);
                    //_srcFrame = Helper.GetServiceSrcFrame(url:url,lg:lang,theme:theme, urlRedirect, UrlCancel);
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Add((res.Messages.Any() &&  res.Messages[0].Contains("400")? "Your subscription is canceled or expired": res.Messages[0]??"Error"), Severity.Error);
                    if (!IsDialogBox)
                        Navigation.NavigateTo($"{RouterPage.STUDIO}/start");
                }
            }
        }
        public virtual async Task SpeechMessage(string message)
        {


            if (!string.IsNullOrEmpty(message))
            {

                var response = await templateServices.Text2Speech(new DataBuildServiceBase { Text = message, ServiceId = "2", Method = "POST", TagId = "LAHJAAudioPlayerId", URL = "https:api-inference.huggingface.co/models/wasmdashai/", ModelAi = selectedStudioFilter.SelectedModelRelease.Identifier });
                // var response = await templateServices.Text2Speech(new DataBuildServiceBase { Text = textSpeech, ServiceId = "2", Method = "POST", TagId = "audioPlayer", URL = "https:api-inference.huggingface.co/models/wasmdashai/", ModelAi = selectedStudioFilter.SelectedModelRelease.Identifier });
                // var res = await templateServices.Text2Speech(new DataBuildServiceBase
                //     {
                //         Url = "https:api-inference.huggingface.co/models/wasmdashai/vits-ar-sa-huba-v2",
                //         Data = message,
                //     });


            }
        }



        protected override void OnInitialized()
        {
            CurrentLanguage = CultureInfo.CurrentUICulture.Name;// await manageLanguageService.GetLanguageAsync();
            ChangeLanguage(CurrentLanguage);

            if (DataBuild == null)
            {
                DataBuild = new DataBuildStudioBase();
                DataBuild.LanguagesFilter = GetLanguages();
                selectedStudioFilter.SelectedLangague = DataBuild.LanguagesFilter.Options[0];
                selectedStudioFilter.SelectedSpeakerGenders = GetSpeakerGenders().Options[0];
                selectedStudioFilter.SelectedModelType = GetModelTypes().Options[0];
                selectedStudioFilter.SelectedServiceType = GetGPTServices().Options[0];
                selectedStudioFilter.SelectedTypeLahaga = GetDialects().Options[0];
                selectedStudioFilter.SelectedCategory = GetCategories().Options[0];
                selectedStudioFilter.SelectedSpeakerName = GetSpeakerName().Options[0];
                selectedStudioFilter.SelectedModelRelease = GetModelReleases().Options[0];
               
            }
            LoadFilters();

        }

        protected override async void OnAfterRender(bool firstRender)

        {
            if (firstRender)
            {
                //CurrentLanguage = CultureInfo.CurrentUICulture.Name;// await manageLanguageService.GetLanguageAsync();
                //ChangeLanguage(CurrentLanguage);
                //if (DataBuild != null)
                //{
                //    LoadFilters();
                //}
                //StateHasChanged();

            }


        }


        protected void InitializeChangedEvents()
        {
            if (DataBuild != null)
            {

                if (DataBuild.CategoriesFilter != null)
                {
                    DataBuild.CategoriesFilter.OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, item =>
                    {
                        selectedStudioFilter.SelectedCategory = item;
                    });

                }
                if (DataBuild.LanguagesFilter != null)
                {
                    DataBuild.LanguagesFilter.OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, item =>
                    {
                        selectedStudioFilter.SelectedLangague = item;
                    });
                }
                if (DataBuild.ModelTypesFilter != null)
                {
                    DataBuild.ModelTypesFilter.OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, item =>
                    {
                        selectedStudioFilter.SelectedModelType = item;
                    });

                }
                if (DataBuild.DialectsFilter != null)
                {
                    DataBuild.DialectsFilter.OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, item =>
                    {
                        selectedStudioFilter.SelectedDialectType = item;
                    });
                }
                if (TypeStudioAiService == TypeStudioAiService.Chat || TypeStudioAiService == TypeStudioAiService.T2T)
                {
                    if (DataBuild.ServiceTypeFilter != null)
                    {
                        DataBuild.ServiceTypeFilter.OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, item =>
                        {
                            selectedStudioFilter.SelectedServiceType = item;
                        });
                    }
                }
                else
                {

                    if (DataBuild.SpeakerGendersFilter != null)
                    {
                        DataBuild.SpeakerGendersFilter.OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, item =>
                        {
                            selectedStudioFilter.SelectedSpeakerGenders = item;
                        });
                    }

                    if (DataBuild.SpeakerNameFilter != null)
                    {
                        DataBuild.SpeakerNameFilter.OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, item =>
                        {
                            selectedStudioFilter.SelectedSpeakerName = item;
                        });
                    }

                }

                if (DataBuild.ModelReleasesFilter != null)
                {
                    DataBuild.ModelReleasesFilter.OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, item =>
                    {
                        selectedStudioFilter.SelectedModelRelease = item;
                    });
                }

            }

        }
        public void SelectCategory(FilterItemData item)
        {

            selectedStudioFilter.SelectedCategory = item;

        }
        public void SelectLanguage(FilterItemData item)
        {

            selectedStudioFilter.SelectedLangague = item;
            DataBuild.DialectsFilter = GetDialects();
            DataBuild.ModelReleasesFilter = GetModelReleases(selectedStudioFilter.SelectedLangague, selectedStudioFilter.SelectedSpeakerGenders??null);
            StateHasChanged();
        }
        public void SelectModelType(FilterItemData item)
        {

            selectedStudioFilter.SelectedModelType = item;
            //if (item.Identifier == "LAHJA")
            //{
                DataBuild.DialectsFilter = GetDialects();
                DataBuild.ModelReleasesFilter = GetModelReleases(selectedStudioFilter.SelectedLangague,selectedStudioFilter.SelectedSpeakerGenders);
            //}
            
            StateHasChanged();
        }

        public void SelectDialectType(FilterItemData item)
        {
            selectedStudioFilter.SelectedDialectType = item;
            StateHasChanged();
        }
  
        public void SelectSpeakerGender(FilterItemData item)
        { 
      
            selectedStudioFilter.SelectedSpeakerGenders = item;
            DataBuild.ModelReleasesFilter = GetModelReleases(selectedStudioFilter.SelectedLangague, item); 
            StateHasChanged();

        }

        public void SelectSpeakerName(FilterItemData item)
        {
            selectedStudioFilter.SelectedSpeakerName = item;
            DataBuild.ModelReleasesFilter = GetModelReleases(selectedStudioFilter.SelectedLangague, item);
            StateHasChanged();
        }
        public void SelectServiceType(FilterItemData item)
        {
            selectedStudioFilter.SelectedServiceType = item;
        }

        public void SelectModelRelease(FilterItemData item)
        { 

            selectedStudioFilter.SelectedModelRelease = item;


        }

        public Dictionary<string, string> TranslationLabels = new();

        public Dictionary<string, string> EnglishLabels = new()
        {
            { "Category", "Category" },
            { "Language", "Language" },
            { "Model Type", "Model Type" },
            { "Type LAHJA", "Type LAHJA" },
            { "Gender", "Gender" },
            { "SpeakerName", "Speaker Name" },
            { "Model Version", "Model Version" }  // إضافة "إصدار النموذج"
        };

        // قاموس باللغة العربية
        public Dictionary<string, string> ArabicLabels = new()
        {
            { "Category", "الفئة" },
            { "Language", "اللغة" },
            { "Model Type", "نوع النموذج" },
            { "Type LAHJA", "نوع اللهجة" },
            { "Gender", "الجنس" },
            { "SpeakerName", "اسم المتحدث" },
            { "Model Version", "إصدار النموذج" }  // إضافة "إصدار النموذج"
        };

        protected StudioFilterDefinition GetGPTServices()
        {
            return new StudioFilterDefinition
            {
                Title = GetText("GPT Services"),
                Icon = Icons.Material.Filled.ModelTraining,
                Options = new List<FilterItemData> {

                new FilterItemData
                {
                    Id = 1,
                    Identifier = "gpt",  // نفس الـ Identifier
                    Text = new Dictionary<string, string>
                    {
                        { "ar", "chat gpt " },
                        { "en", "chat gpt" }
                    },
                    Icon = Icons.Material.Filled.Group
                },
                   new FilterItemData
                {
                    Id = 2,
                    Identifier = "gpt",  // نفس الـ Identifier
                    Text = new Dictionary<string, string>
                    {
                        { "ar", "Bing " },
                        { "en", "Bing" }
                    },
                    Icon = Icons.Material.Filled.Group
                }
           },
                OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectServiceType)
            };
        }
        // دالة للحصول على بيانات الفئات (Categories)
        protected  StudioFilterDefinition GetCategories()
        {
            return new StudioFilterDefinition
            {
                Title = GetText("Category"),
                Icon = Icons.Material.Filled.Category,
                Options = new List<FilterItemData>
        {
            new FilterItemData { Id = 1, Icon = Icons.Material.Filled.Newspaper, Identifier = "news", Text = new Dictionary<string, string> { { "ar", "أخبار" }, { "en", "News" } } },
            new FilterItemData { Id = 2, Identifier = "general", Text = new Dictionary<string, string> { { "ar", "عام" }, { "en", "General" } } },
            new FilterItemData { Id = 3, Identifier = "questions", Text = new Dictionary<string, string> { { "ar", "أسئلة" }, { "en", "Questions" } } },
            new FilterItemData { Id = 4, Identifier = "sports", Text = new Dictionary<string, string> { { "ar", "رياضة" }, { "en", "Sports" } } },
            new FilterItemData { Id = 5, Identifier = "technology", Text = new Dictionary<string, string> { { "ar", "تكنولوجيا" }, { "en", "Technology" } } }
        },
                OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectCategory)
            };
        }

        // دالة للحصول على بيانات اللغات (Languages)
        protected StudioFilterDefinition GetLanguages()
        {
            return new StudioFilterDefinition
            {
                Title = GetText("Language"),
                Icon = Icons.Material.Filled.Language,
                Options = new List<FilterItemData>
        {
            new FilterItemData { Id = 1, Identifier = "en", Text = new Dictionary<string, string> { { "ar", "الإنجليزية" }, { "en", "English" } } },
            new FilterItemData { Id = 2, Identifier = "ar", Text = new Dictionary<string, string> { { "ar", "العربية" }, { "en", "Arabic" } } }
        },
                OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectLanguage)
            };
        }

        // دالة للحصول على بيانات أنواع النماذج (Model Types)
        protected StudioFilterDefinition GetModelTypes()
        {
            return new StudioFilterDefinition
            {
                Title = GetText("Model Type"),
                Icon = Icons.Material.Filled.ModelTraining,
                Options = new List<FilterItemData>
        {
            new FilterItemData { Id = 1, Identifier = "Official", Text = new Dictionary<string, string> { { "ar", "الرسمية" }, { "en", "Official" } } },
            new FilterItemData { Id = 2, Identifier = "LAHJA", Text = new Dictionary<string, string> { { "ar", "لهجة" }, { "en", "LAHJA" } } }
        },
                OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectModelType)
            };
        }

        // دالة للحصول على بيانات اللهجات (Dialects)
        protected StudioFilterDefinition GetDialects()
        {
            if (selectedStudioFilter.SelectedLangague.Identifier == "ar") {
                if (selectedStudioFilter.SelectedModelType.Identifier == "LAHJA")
                {
                    return new StudioFilterDefinition
                    {
                        Title = GetText("Type LAHJA"),
                        Icon = Icons.Material.Filled.SignLanguage,
                        Options = new List<FilterItemData>
                        {
                            new FilterItemData
                            {
                                Id = 1,
                                Identifier = "NA",
                                Text = new Dictionary<string, string>
                                {
                                    { "ar", "اللهجة النجدية" },
                                    { "en", "Najdi Accent" }
                                }
                            },
                            new FilterItemData
                            {
                                Id = 2,
                                Identifier = "HA",
                                Text = new Dictionary<string, string>
                                {
                                    { "ar", "اللهجة الحجازية" },
                                    { "en", "Hejaz Accent" }
                                }
                            },
                            new FilterItemData
                            {
                                Id = 3,
                                Identifier = "SH",
                                Text = new Dictionary<string, string>
                                {
                                    { "ar", "اللهجة الجنوبية" },
                                    { "en", "Southern Accent" }
                                }
                            },
                            new FilterItemData
                            {
                                Id = 4,
                                Identifier = "EA",
                                Text = new Dictionary<string, string>
                                {
                                    { "ar", "اللهجة الشرقية" },
                                    { "en", "Eastern Accent" }
                                }
                            }
                        },
                        OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectDialectType)
                    };
                }
                else
                {
                    return new StudioFilterDefinition
                    {
                        Title = GetText("Type LAHJA"),
                        Icon = Icons.Material.Filled.SignLanguage,
                        Options = new List<FilterItemData>
                    {
                    new FilterItemData
                    {
                        Id = 1,
                        Identifier = "Official-AR",
                        Text = new Dictionary<string, string>
                        {
                            { "ar", "الهجة الرسمية" },
                            { "en", "Official dialect" }
                        }
                    },
                     },
                        OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectDialectType)
                    };
                }
            }
            else
            {
                return new StudioFilterDefinition
                {
                    Title = GetText("Type LAHJA"),
                    Icon = Icons.Material.Filled.SignLanguage,
                    Options = new List<FilterItemData>
                    {
                    new FilterItemData
                    {
                        Id = 1,
                        Identifier = "Official-EN",
                        Text = new Dictionary<string, string>
                        {
                            { "ar", "الهجة الرسمية" },
                            { "en", "Official dialect" }
                        }
                    },
                     },
                    OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectDialectType)
                };
            }
      
        }



        // دالة للحصول على بيانات الجنس (Speaker Genders)
        protected StudioFilterDefinition GetSpeakerGenders()
        {
            return new StudioFilterDefinition
            {
                Title = GetText("Gender"),
                Icon = Icons.Material.Filled.Male,
                Options = new List<FilterItemData>
        {
            new FilterItemData { Id = 1, Icon = Icons.Material.Filled.Male, Identifier = "male", Text = new Dictionary<string, string> { { "ar", "ذكر" }, { "en", "Male" } } },
            new FilterItemData { Id = 2, Icon = Icons.Material.Filled.Female, Identifier = "female", Text = new Dictionary<string, string> { { "ar", "أنثى" }, { "en", "Female" } } }
        },
                OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectSpeakerGender)
            };
        }


        protected StudioFilterDefinition GetSpeakerName()
        {
            return new StudioFilterDefinition
            {
                Title = GetText("SpeakerName"),
                Icon = Icons.Material.Filled.Male,
                Options = new List<FilterItemData>
                {
                    new FilterItemData { Id = 1, Icon = Icons.Material.Filled.Male, Identifier = "Heba", Text = new Dictionary<string, string> { { "ar", "هبة" }, { "en", "Heba" } } },
                    new FilterItemData { Id = 2, Icon = Icons.Material.Filled.Female, Identifier = "Ahmed", Text = new Dictionary<string, string> { { "ar", "أحمد" }, { "en", "Ahmed" } } }
                },
                OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectSpeakerName)
            };
        }

        // دالة للحصول على بيانات الإصدارات (Model Releases)
        protected StudioFilterDefinition GetModelReleases(FilterItemData? langItem=null, FilterItemData? genderItem=null)
        {
            string lang = "ar";
            string gender = "male";

            if (langItem!=null)
              lang = langItem?.Identifier;
            if (gender != null)
                gender = genderItem?.Identifier;

            return lang == "ar"? getListArabicModelRelease(gender) : getListEnglishModelRelease(gender);
        }

        public async void ChangeLanguage(string currentLangCode)
        {
            CurrentLanguage = currentLangCode;
            TranslationLabels = currentLangCode == "ar" ? ArabicLabels : EnglishLabels;
           await InvokeAsync(StateHasChanged);
        }
        public string GetText(string key)
        {

            if (TranslationLabels.ContainsKey(key))
            {
                return TranslationLabels[key];
            }
            return key;
        }


        public virtual StudioFilterDefinition getListEnglishModelRelease(string gender)
        {
            return new StudioFilterDefinition
            {
                Title = GetText("Model Version"),
                Icon = Icons.Material.Filled.SignLanguage,
                Options = new List<FilterItemData>
            {
                // إضافة الإصدارات الإنجليزية
                new FilterItemData
                {
                    Id = 1,
                    Identifier = "vits-en-v1",  // نفس الـ Identifier
                    Text = new Dictionary<string, string>
                    {
                        { "ar", "لهجة 2.3 انجليزي" },
                        { "en", "Lahja English 2.3" }
                    },
                    Icon = Icons.Material.Filled.Group
                }
            },
                OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectModelRelease)
            };
        }
        public virtual StudioFilterDefinition getListArabicModelRelease(string gender)
        {
            return new StudioFilterDefinition
            {
                Title = GetText("Model Version"),
                Icon = Icons.Material.Filled.SignLanguage,
                Options = new List<FilterItemData>
        {


            // إضافة الإصدارات العربية بناءً على الجنس
            gender == "male" ? new FilterItemData
            {
                Id = 2,
                Identifier = "vits-ar-sa-A",
                Text = new Dictionary<string, string>
                {
                    { "ar", "لهجة احمد 2.1" },
                    { "en", "Lahja Ahmed 2.1" }
                },
                Icon = Icons.Material.Filled.Group
            } : new FilterItemData
            {
                Id = 3,
                Identifier = "vits-ar-sa-huba-v2",
                Text = new Dictionary<string, string>
                {
                    { "ar", "لهجة هبة 2.5" },
                    { "en", "Lahja Huba 2.5" }
                },
                Icon = Icons.Material.Filled.Group
            }
        },
                OnSelectionChanged = EventCallback.Factory.Create<FilterItemData>(this, SelectModelRelease)
            };
        }


        public void LoadFilters()
        {
            DataBuild.CategoriesFilter = GetCategories();
            DataBuild.LanguagesFilter = GetLanguages();
            DataBuild.ModelTypesFilter = GetModelTypes();
            DataBuild.DialectsFilter = GetDialects();
            DataBuild.ModelReleasesFilter = GetModelReleases();
            DataBuild.ServiceTypeFilter = GetGPTServices();
            DataBuild.SpeakerGendersFilter = GetSpeakerGenders();
            DataBuild.SpeakerNameFilter = GetSpeakerName();
        }
    }
}
