using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Interfaces;

namespace LAHJA.Data.UI.Components
{
	public class DataBuildPlansBase: ITVM
    {
            public string CategoryId { get; set; }
            public string PlanId { get; set; }
            public string Lg { get; set; }
            public int PremiumPlanNumber { get; set; }
            public int Take { get; set; }
        }

    public  class CardStateCount<T>
    {

        public T Value { get; set; }

        public string Label { get; set; } = "Label";
        public string Class { get; set; }= "";


    }



    public  class CardActionTabel
    {
        public string Name { set; get; } = "Name";
        public string? Tag { set; get; }

        public string? Icon { set; get; }
        public bool IsMudChip { set; get; }=true;
        

        public Color Color { set; get; } = Color.Default;


    }

    public  class GroupActionTabels
    {

        public List<CardActionTabel>? Actions { get;set; }
        public Func<CardActionTabel, Task>? ChipClicked { get; set; }
        public Func<Task>? CreateSpaceClicked { get; set; }

    }

    public  class TitelBarTabel
    {
        public string Label { set; get; } = "create";

        public string Description { get; set; } = "Features ";

    }

    public  class HandleCallback<T, E>
    {

        public static Func<T,E> Delegate(Func<T, E> func)
        {

            return func;
        }
    }

     public  class EventBuildTabelCard<T>
    {
        public EventCallback<T> OnRowClicked { get; set; }
  
        public EventCallback<HashSet<T>> OnSelectedItemsChanged { get; set; }
        public EventCallback<string> OnSearch { get; set; }
        public EventCallback<SortDirection> OnSortChanged { get; set; }
        public EventCallback<int> OnPageChanged { get; set; }
        public Func<T, int, string>? OnRowRender { get; set; }
    }
    public  class DataAndEventBuildTabelCard<T>
    {
         public List<T> DataBuild { get; set; } = new();
       public bool FixedHeader { get; set; } = true;
       public bool MultiSelection { get; set; } = false;

        // الأحداث كـ Parameters
        public  EventBuildTabelCard<T>? Events { set; get; }
        public List<string> LabelColumns { get; set; } = new();
    }

    public class EventBuildViewRowDetails<T>
    {
        public EventCallback<T> DeleteClicked { get; set; }
   
        public EventCallback<T> SwitchedActiveStatus { get; set; }
        public EventCallback<T> ActiveClicked { get; set; }
        public EventCallback<T> ValidateClicked { get; set; }

    }



}
