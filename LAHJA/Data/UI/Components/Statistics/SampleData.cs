
using LAHJA.Data.UI.Billing;
using System;
using System.Collections.Generic;

namespace LAHJA.Data.UI.Components.Statistics
{
    public static class SampleData
    {

        public static List<FilterPieChart> GetFilterar()
        {


            return new List<FilterPieChart>()
{
    new FilterPieChart()
    {
        Id = 1,
        Name = "الكل",
        ListPieChartModel = new List<PieChartModel>()
        {
            new PieChartModel { Category = "نص إلى نص", TotalNumber = 200, RemainingNumber = 10 },
            new PieChartModel { Category = "نص إلى كلام", TotalNumber = 30, RemainingNumber = 20 },
            new PieChartModel { Category = "الدردشة", TotalNumber = 30, RemainingNumber = 10 },
            //  new PieChartModel { Category = "تقرير النطاق", TotalNumber = 20, RemainingNumber = 10 }
        },
        ListScope = new List<CountRequesstToScope>()
        {
            new CountRequesstToScope()
            {
                Id = "", Name = "نطاق أندرويد", GrossValue = 100
            },
            new CountRequesstToScope()
            {
                Id = "", Name = "نطاق الويب", GrossValue = 40
            },
            new CountRequesstToScope()
            {
                Id = "", Name = "تقرير النطاق", GrossValue = 50
            },
        }
    },
    new FilterPieChart()
    {
        Id = 2,
        Name = "الخطة الحالية",
        ListPieChartModel = new List<PieChartModel>()
        {
            new PieChartModel { Category = "نص إلى نص", TotalNumber = 30, RemainingNumber = 10 },
            new PieChartModel { Category = "نص إلى كلام", TotalNumber = 50, RemainingNumber = 20 },
            new PieChartModel { Category = "الدردشة", TotalNumber = 60, RemainingNumber = 10 },
            //  new PieChartModel { Category = "تقرير النطاق", TotalNumber = 20, RemainingNumber = 10 }
        },
        ListScope = new List<CountRequesstToScope>()
        {
            new CountRequesstToScope()
            {
                Id = "", Name = "نطاق أندرويد", GrossValue = 40
            },
            new CountRequesstToScope()
            {
                Id = "", Name = "نطاق الويب", GrossValue = 20
            },
            new CountRequesstToScope()
            {
                Id = "", Name = "تقرير النطاق", GrossValue = 10
            },
        }
    },
};

        }
        

            public static List<FilterPieChart> GetFilter()
        {
            return new List<FilterPieChart>()
            {


               new FilterPieChart()
               {
                   Id=1,
                   Name="All",
                   ListPieChartModel=new List<PieChartModel>()
                   {


                         new PieChartModel { Category = "Text To Text", TotalNumber = 200, RemainingNumber = 10 },
                         new PieChartModel { Category = "Text To Speech", TotalNumber = 30, RemainingNumber = 20 },
                         new PieChartModel { Category = "Chat", TotalNumber = 30, RemainingNumber = 10 },
                       //  new PieChartModel { Category = "Scope Report", TotalNumber = 20, RemainingNumber = 10 }
                   },
                   ListScope=new List<CountRequesstToScope>()
                   {
                       new CountRequesstToScope()
                       {
                           Id="",Name="Scope Indroid",GrossValue=100
                       },
                        new CountRequesstToScope()
                       {
                           Id="",Name="Scope Web",GrossValue=40
                       },
                          new CountRequesstToScope()
                       {
                           Id="",Name="Scope Report",GrossValue=50
                       },
                   }

               },

                 new FilterPieChart()
               {
                   Id=2,
                   Name="Current Plan",
                   ListPieChartModel=new List<PieChartModel>()
                   {
                         new PieChartModel { Category = "Text To Text", TotalNumber = 30, RemainingNumber = 10 },
                         new PieChartModel { Category = "Text To Speech", TotalNumber = 50, RemainingNumber = 20 },
                         new PieChartModel { Category = "Chat", TotalNumber = 60, RemainingNumber = 10 },
                       //  new PieChartModel { Category = "Scope Report", TotalNumber = 20, RemainingNumber = 10 }
                   },
                     ListScope=new List<CountRequesstToScope>()
                   {

                       new CountRequesstToScope()
                       {

                           Id="",Name="Scope Indroid",GrossValue=40
                       },
                        new CountRequesstToScope()
                       {

                           Id="",Name="Scope Web",GrossValue=20
                       },
                          new CountRequesstToScope()
                       {
                           Id="",Name="Scope Report",GrossValue=10
                       },
                   }
               },



            };




        }
    }
}
