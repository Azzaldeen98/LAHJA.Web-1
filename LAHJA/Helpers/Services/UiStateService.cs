namespace LAHJA.Helpers.Services
{

    using System;

    public interface IUiStateService {

        event Action? OnLoadingChanged;
         bool IsLoading { get; set; }
    }
    public class UiStateService: IUiStateService
    {
        // حدث لإعلام المكونات عند تغيّر حالة التحميل
        public event Action? OnLoadingChanged;

        private bool _isLoading=true;

        // خاصية تتحكم في عرض/إخفاء واجهة التحميل
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    //OnLoadingChanged?.Invoke(); // نطلق الحدث عند التغيير
                }
            }
        }

        // يمكن إضافة خصائص مستقبلًا، مثل:
        // public string? LoadingMessage { get; set; }
    }
}
