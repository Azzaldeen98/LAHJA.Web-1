namespace LAHJA.Data.UI.Components.Plan
{
    public class TechnologyService
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TechnicalService> TechnicalServices { get; set; } = new List<TechnicalService>();
    }
}
