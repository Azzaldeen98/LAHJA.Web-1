namespace LAHJA.Data.UI.Components.Base
{
    public class InputFieldProperties
    {
        public string T { set; get; } = "string";
        public bool Disabled { get; set; } = false;
        public bool Required { get; set; } = true;
        public string Label { get; set; } = string.Empty;
        public string RequiredError { get; set; } = string.Empty;
    }

    public interface ICardInput
    {
        InputFieldProperties Properties { set; get; }
    }

    public class CardInput<T> : ComponentBaseCard<T>, ICardInput
    {
        public override TypeComponentCard Type => throw new NotImplementedException();

        public InputFieldProperties Properties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Build(T db)
        {
            DataBuild = db;
        }
    }

}