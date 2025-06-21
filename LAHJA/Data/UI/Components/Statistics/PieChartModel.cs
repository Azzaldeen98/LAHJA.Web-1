namespace LAHJA.Data.UI.Components.Statistics
{
    public class PieChartModel
    {


        public int Id { get; set; }
        public string Category { get; set; }
        public decimal TotalNumber { get; set; }
        public decimal RemainingNumber { get; set; }


    }



    public class CountRequesstToScope

    {

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal GrossValue { get; set; }

    }
    public class FilterPieChart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PieChartModel> ListPieChartModel { get; set; }
        public List<CountRequesstToScope> ListScope { get; set; }

    }



}
