using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Components.StudioLahjaAiVM
{
    public class FilterItemData
    {
        public int? Id { get; set; } 
        public string? Identifier { get; set; } = string.Empty;
        public Dictionary<string, string> Text { get; set; } = new();
        public string? Icon { get; set; } = string.Empty;
        public Type? Component { get; set; }
        public string? TypeModel { get; set; } = string.Empty;
    }

    public class StudioFilterDefinition
    {
        public string? Title { get; set; } = string.Empty;
        public string? Icon { get; set; } = string.Empty;
        public List<FilterItemData>? Options { get; set; } 
        public EventCallback<FilterItemData> OnSelectionChanged { get; set; }
    }


    public class SelectedStudioFilter {

        public FilterItemData SelectedCategory { get; set; }
        public FilterItemData SelectedServiceType { get; set; }
        public FilterItemData SelectedLangague { get; set; }
        public FilterItemData SelectedTypeLahaga { get; set; }
        public FilterItemData SelectedModelType { get; set; }
        public FilterItemData SelectedDialectType { get; set; }
        public FilterItemData SelectedModelRelease { get; set; }
        public FilterItemData SelectedSpeakerGenders { get; set; }
        public FilterItemData SelectedSpeakerName { get; set; }

    }

    public class DataBuildStudioBase
    {
        public StudioFilterDefinition CategoriesFilter { get; set; }
        public StudioFilterDefinition LanguagesFilter { get; set; } 
        public StudioFilterDefinition ModelTypesFilter { get; set; } 
        public StudioFilterDefinition DialectsFilter { get; set; } 
        public StudioFilterDefinition ServiceTypeFilter { get; set; } 
        public StudioFilterDefinition SpeakerGendersFilter { get; set; } 
        public StudioFilterDefinition ModelReleasesFilter { get; set; } 
        public StudioFilterDefinition SpeakerNameFilter { get; set; } 

    }

}
