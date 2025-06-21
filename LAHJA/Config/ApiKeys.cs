namespace LAHJA.Config
{
    public static class ApiKeys
    {
        public static string HuggingFaceToken { get; private set; } = string.Empty;
        public static string GoogleApiKey { get; private set; } = string.Empty;

        // دالة لتهيئة القيم
        public static void Initialize(ApiKeysSettings settings)
        {
            HuggingFaceToken = settings.HuggingFaceToken;
            GoogleApiKey = settings.GoogleApiKey;
        }
    }


}
