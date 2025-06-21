namespace LAHJA.Data.UI.Components.StudioLahjaAiVM
{
    public class ChangeLogModels
    {

        public DateTime Date { get; set; }
        public string NameModel { get; set; }
        public string Descrption { get; set; }

    }   

    public class ChangeLogService
    {


        public List<ChangeLogModels> GenerateRealisticChangeLEnglish(int count)
        {
            var changeLogs = new List<ChangeLogModels>();

            // List of model names (e.g., features or modules)
            var modelNames = new List<string>
        {
            "Registration Form", "Search Form", "Authentication Module", "Payment Gateway", "Profile Settings"
        };

            // List of possible change descriptions
            var descriptions = new List<string>
        {
            "Fixed the issue with password-based authentication.",
            "Improved search functionality for faster and more accurate results.",
            "Added new customization options to user profiles.",
            "Updated the privacy policy of the platform.",
            "Added digital wallet payment option."
        };

            // Generate realistic data starting from 30 days ago
            var baseDate = DateTime.Now.AddDays(-30); // Start from 30 days ago
            for (int i = 0; i < count; i++)
            {
                var changeLog = new ChangeLogModels
                {
                    Date = baseDate.AddDays(i), // Dates increase gradually starting from the base date
                    NameModel = modelNames[i % modelNames.Count], // Rotate model names periodically
                    Descrption = descriptions[i % descriptions.Count] // Rotate descriptions periodically
                };

                changeLogs.Add(changeLog);
            }

            return changeLogs;
        }
        public List<ChangeLogModels> GenerateRealisticChangeLogs(int count)
        {
            var changeLogs = new List<ChangeLogModels>();

            // قائمة بأسماء النماذج
            var nameModels = new List<string>
                {
                    "نموذج التسجيل", "نموذج البحث", "نموذج التوثيق", "نموذج الدفع", "نموذج الملف الشخصي"
                };

            // قائمة بالأوصاف لتغييرات ممكنة
            var descriptions = new List<string>
                {
                    "تم إصلاح مشكلة في التوثيق باستخدام كلمة المرور",
                    "تم تحسين واجهة البحث لتكون أسرع وأكثر دقة",
                    "تم إضافة خيارات تخصيص جديدة في ملف المستخدم",
                    "تم تحديث سياسة الخصوصية للموقع",
                    "تم إضافة خيار الدفع عبر المحفظة الرقمية"
                };

            // توليد بيانات واقعية بدون عشوائية
            var baseDate = DateTime.Now.AddDays(-30); // البدء من تاريخ قبل 30 يومًا
            for (int i = 0; i < count; i++)
            {
                var changeLog = new ChangeLogModels
                {
                    Date = baseDate.AddDays(i), // تواريخ تزداد تدريجيًا من التاريخ السابق
                    NameModel = nameModels[i % nameModels.Count], // تدوير النماذج بشكل دوري
                    Descrption = descriptions[i % descriptions.Count] // تدوير الأوصاف بشكل دوري
                };

                changeLogs.Add(changeLog);
            }

            return changeLogs;
        }
    }

}
