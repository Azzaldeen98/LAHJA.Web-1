namespace LAHJA.Data.UI.Components.ServiceCard
{
    using System;
    using System.Collections.Generic;
    using LAHJA.Data.UI.Components.Base;
    using Microsoft.AspNetCore.Components;
     


 

    public class CarosuelCardBase<T> : ComponentBaseCard<T>
    {
        public override TypeComponentCard Type => throw new NotImplementedException();
        public override void Build(T db)
        {
            DataBuild = db;
        }


    }






    public class CarosuelCardCompoent : CarosuelCardBase<CarosuelCardModel>
    {
        public override TypeComponentCard Type => throw new NotImplementedException();
        public override void Build(CarosuelCardModel db)
        {
            DataBuild = db;
        }

    }

    public class CarosuelCardCompoentBar : CarosuelCardBase<DataBuildCarosuelCard>
    {
        public CarosuelCardCompoent carosuelCardCompoent { get; set; }

        public override TypeComponentCard Type => throw new NotImplementedException();
        public override void Build(DataBuildCarosuelCard db)
        {
            DataBuild = db;
        }


        public static CarosuelCardCompoentBar GetGenarelCard(DataBuildCarosuelCard db)
        {
            CarosuelCardCompoentBar Obj = new CarosuelCardCompoentBar();
            Obj.ClassContainer = "contenerMain";
            Obj.carosuelCardCompoent = new CarosuelCardCompoent()
            {
                ClassItem = "",
                ClassContainer = "main-section-image"

            };
            Obj.carosuelCardCompoent.Build(db.carosuelCardModel);
            return Obj;

        }



    }


    public class ResponecCarouselCard
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class CarosuelCardModel
    {
        public string Id { get; set; } = "1";
        public string Name { get; set; } = "Azdeen";
        public string Descrption { get; set; } = "We Are you the element ";
        public List<string> UrlList { get; set; } = new List<string>()
        {
            "/ai-hand.png","/ai-hand.png","/ai-hand.png","/ai-hand.png","/ai-hand.png"

        };

    }
    public class DataBuildCarosuelCard
    {
        public CarosuelCardModel carosuelCardModel { get; set; } = new CarosuelCardModel();

    }
}

