using ApexCharts;
using LAHJA.UI.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants;
using Shared.Wrapper;

namespace LAHJA.Data.UI.Components
{


    public partial class DataBuildModelAICardHeader 
    {
          public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public string Name { get; set; }
    }

    public class ModelAIDisplayCard
    {
        public string? ImageUrl { get; set; }
        public string? LinkUrl { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Downloads { get; set; }
        public int Likes { get; set; }


        public string GetRelativeTime()
        {
            var diff = DateTime.UtcNow - UpdatedAt;
            if (diff.TotalDays >= 1)
                return $"{(int)diff.TotalDays} يوم مضى";
            if (diff.TotalHours >= 1)
                return $"{(int)diff.TotalHours} ساعة مضت";
            return $"{(int)diff.TotalMinutes} دقيقة مضت";
        }
    }
}
