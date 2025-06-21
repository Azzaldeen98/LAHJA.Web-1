using Blazorise;
using MudBlazor;
namespace LAHJA.Data.UI.Components.Base
{




    public  enum TypeIconCard
    {
        Icon,
        Image
    }
    public interface IStyleCardIcon: IStyleBaseComponentCard
    {
        public string? ClassImg { set; get; }
    }
    public interface ICardIcon :IStyleCardIcon
    {
      
        
        public TypeIconCard TypeIconCard { set; get; }

    }

    public class CardComponentIcon : ComponentBaseCard<string>, ICardIcon
    {
        public TypeIconCard TypeIconCard { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? ClassImg { get; set; } = "";
        public override TypeComponentCard Type => TypeComponentCard.Icon;

        public override void Build(string db)
        {
            DataBuild = db;
        }
    }



   

   
    public interface ICardText
    {


        public Typo TypeTextCard { set; get; }

    }
    public class CardText : ComponentBaseCard<string>, ICardText
    {
        public Typo TypeTextCard { get; set; } = Typo.body1;

        public override TypeComponentCard Type =>TypeComponentCard.Text;

        public override void Build(string db)
        {
            DataBuild = db;
        }
    }
    public  interface ICardTextBar
    {

    }

    

    public class DataCardTextBar
    {
        public string CardText { set; get; } = "\"We provide models that help to aid in the creation of different attack sequences. You can deal with AGS models choosing the model you want ?.\";\r\n   ";
        public string Header { set; get; } = "LAHJA AI";
        public string SAC { set; get; } = "AI";
    }
    public class CardTextBar: ComponentBaseCard<DataCardTextBar>
    {

        public CardText? CardText { set; get; } 


        public override TypeComponentCard Type => throw new NotImplementedException();

        public override void Build(DataCardTextBar db)
        {
            DataBuild = db;
            CardText = new CardText();
            CardText.Build(db.CardText);

        }
    }

    public class DataBuildCardTextAndIconBar
    {

        public string? Src { set; get; } = "css/ICON-removebg-preview.png";
        public DataCardTextBar? DataCardTextBar { set; get; } =new DataCardTextBar();



        public bool IsActive { set; get; } = true;
        
    }
    public class CardTextAndIconBar: ComponentBaseCard<DataBuildCardTextAndIconBar>
    {

        public CardTextBar? CardTextBar { set; get; } 

        public CardComponentIcon? IconCard { set; get; }

        public override TypeComponentCard Type => throw new NotImplementedException();

        public static CardTextAndIconBar GetGenarelCard(DataBuildCardTextAndIconBar db)
        {
            CardTextAndIconBar cardTextAndIconBar = new CardTextAndIconBar();
            cardTextAndIconBar.IconCard = new CardComponentIcon
            {
               
                ClassItem = "",
                ClassContainer = "main-section-image",
                ClassImg = "main-section-image ",



            };
            cardTextAndIconBar.CardTextBar = new CardTextBar()
            {



                CardText = new CardText()
                {

                    ClassItem = "main-section-image"
                }



            };
            cardTextAndIconBar.Build(db);
            return cardTextAndIconBar;
        }

        public override void Build(DataBuildCardTextAndIconBar db)
        {
            DataBuild = db;
            CardTextBar.Build(db.DataCardTextBar);
            IconCard.Build(db.Src);



        }
    }


    public class CardIcon
    {
        public string? Src { set; get; }

        public string? ClassContanier { set; get; } = "list-inline-item";

        public string? ClassIcon { set; get; } = "icon-xl btn-transition bg-white border border-white border-opacity-10 d-flex justify-content-center align-items-center rounded-2";


        public string? ClassImg { set; get; } = "h-40px";
    }
    public class CardIconServics : CardIcon
    {
        public new string? ClassContanier { set; get; } = "list-inline-item me-0";
    }



    public class CardIconItems
    {
        public List<CardIconServics>? CardIconServics { set; get; }

        public static readonly string INEERCLASS = "list-inline d-flex justify-content-center flex-wrap gap-4 my-5 my-lg-6";

        public string? ClassItems { set; get; } = "";


        public bool IsUseStyleIneerItems { set; get; } = true;

        public string Description { set; get; } = "";

        public string Name { set; get; } = "Name";
        public bool IsName { set; get; } = true;



        public string ClassContainer { set; get; } = "inner-container text-center mt-8";

        public string NameFoter { set; get; } = " Uncover our AI capabilities";
        public bool INameFoter { set; get; } = true;





    }

    public class CardTextAndIcon
    {

        public static readonly string INEERCLASS = "hover-item d-flex align-items-center border-bottom position-relative py-4";
        public bool IsUseStyleIneerItems { set; get; } = true;

        public string? ClassItems { set; get; } = "";
        public CardIcon? Icon { set; get; }
        public string? ImageUrl { get; set; }
        public string? Role { get; set; }

        public string? Name { set; get; } = "AI consulting and strategy";
        public bool IsName { set; get; } = true;
        public string? Description { set; get; } = "";
        public bool IsDescription { set; get; } = true;
        public string ButtonLink { get; set; } = "";
        public bool IsButtonLink { get; set; } = true;
        public string? PriceDisplay { get; set; } = "";
        public string? ButtonText { get; set; } = "";
        public string? Details { get; set; } = "";
        public string? CardClass { get; set; } = "";

    }

    public class Testimonial
    {
        public string Name { get; set; }
        public string Role { get; set; }

        public string Message { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CaerdSevicisIcon
    {

        public static readonly string INEERCLASS = "list-inline d-flex justify-content-center flex-wrap gap-2 gap-md-4 mb-0 mt-4 mt-xl-5";
        public bool IsUseStyleIneerItems { set; get; } = true;

        public string? ClassItems { set; get; } = "";
        public CardIcon? Icon { set; get; }
        public string? Name { set; get; } = "";
        public bool IsName { set; get; } = true;
        public string? Description { set; get; } = "";
        public bool IsDescription { set; get; } = true;
        public string ButtonLink { get; set; } = "";
        public bool IsButtonLink { get; set; } = true;


    }

}
