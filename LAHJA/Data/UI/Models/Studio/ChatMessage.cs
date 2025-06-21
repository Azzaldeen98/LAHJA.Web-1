namespace LAHJA.Data.UI.Models.Studio
{
    public class ChatMessage
    {
        public string Content { get; set; }
        public string DisplayedContent { get; set; } = string.Empty;
        public string IsUser { get; set; }
        public string BubbleColor { get; set; }
        public bool IsProcessing { get; set; } = false;
        public bool IsSpeaking { get; set; } = false;
    }


}
