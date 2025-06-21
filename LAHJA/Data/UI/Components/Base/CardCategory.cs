using LAHJA.Data.UI.Components.Category;
using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Components.Base
{



    public interface IStyleCardCategory : IStyleBaseComponentCard
    {
        public string? ClassCategory { set; get; }

    }
    public class CardCategory<T> : ComponentBaseCard<T>, IStyleCardCategory
    {


      
        public override TypeComponentCard Type => throw new NotImplementedException();




        public override void Build(T db)
        {
            DataBuild = db;
        }
        [Parameter]
        public EventCallback<T> OnSubmit { get; set;}
        [Parameter]
        public IEnumerable<T> Params { get; set; } = null;
        public string? ClassCategory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }









    public class CardCategoryy : ComponentBaseCard<CategoryComponent>
    {


        public override TypeComponentCard Type => throw new NotImplementedException();

        public override void Build(CategoryComponent db)
        {

             DataBuild = db;
        }
    }

    public class CardCategoryBar : ComponentBaseCard<DataBuildCategory>

    {


    public CardCategoryy ?cardCategory { get; set; }


        public override TypeComponentCard Type => throw new NotImplementedException();


        public static CardCategoryBar GetGenarelCard(DataBuildCategory db)
        {
            CardCategoryBar cardTextAndIconBar = new CardCategoryBar();
            cardTextAndIconBar.cardCategory = new CardCategoryy
            {

                ClassItem = "",
                ClassContainer = "main-section-image",
           
            };
           
            cardTextAndIconBar.Build(db);
            return cardTextAndIconBar;
        }
        public override void Build(DataBuildCategory db)
        {

            DataBuild = db;
            cardCategory.Build(db.categoryComponent);


        }
    }



    public   class DataBuildCategory 
    {

        public CategoryComponent? categoryComponent { set; get; }= new CategoryComponent();

    }

 


}
