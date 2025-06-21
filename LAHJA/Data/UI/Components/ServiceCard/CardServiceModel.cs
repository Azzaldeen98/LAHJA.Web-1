using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Components.ServiceCard
{
    public  enum TypeComponentCard
    {
        Base,
        Icon,
        Text,
        TextAndIcon
    } 

    public interface IStyleBaseComponentCard
    {
        public string? ClassItem { set; get; }
        public string? ClassContainer { set; get; }

    }
    public interface IDataBaseComponentCard<T>
    {
        
        void Build(T db);

    }


    public interface IBaseComponentCard<T>: IDataBaseComponentCard<T>,IStyleBaseComponentCard
    {
        TypeComponentCard Type { get; }      
        bool IsActive { get; set; }
        bool IsAuth { get; set; }
        
        T DataBuild { set; get; }
    }




    public abstract class ComponentBaseCard<T> : ComponentBase, IBaseComponentCard<T>
    {
        public abstract TypeComponentCard Type { get; }
        public bool IsActive { get; set; } = true;
        public bool IsAuth { get; set; } = true;
        public T DataBuild { get; set;}
        public string? ClassItem { get; set; } = "";
        public string? ClassContainer { get; set; } = "";

        public abstract void Build(T db);
       
    }

 public class CardServiceForm<T> : ComponentBaseCard<T>
    {
        public override TypeComponentCard Type => throw new NotImplementedException();
        public override void Build(T db)
        {
            DataBuild = db;
        }


    }
public class TextToSpeechComponent:CardServiceForm<TextToSpeechStep>
{
     public override TypeComponentCard Type => throw new NotImplementedException();

       
        public override void Build(TextToSpeechStep db)
        {
            DataBuild = db;
        }



} 

public class TextToDialectComponent:CardServiceForm<TextToDialectStep>
{
     public override TypeComponentCard Type => throw new NotImplementedException();
       
        public override void Build(TextToDialectStep db)
        {
            DataBuild = db;
        }



}

public class ServiceComponentPar:CardServiceForm<DataBuildServicePage>
{
    
     public TextToSpeechComponent textToSpeechComponent{get;set;}
     public TextToDialectComponent textToDialectComponent{get;set;}
     public override TypeComponentCard Type => throw new NotImplementedException();
        


    
        public override void Build(DataBuildServicePage db)
        {
            DataBuild = db;
        }

       public static ServiceComponentPar  GetGenarelCard(DataBuildServicePage db)
       {
           ServiceComponentPar obj=new ServiceComponentPar();
           obj.ClassContainer="mt-16";
            obj.ClassItem="mt-16";
           obj.textToSpeechComponent=new TextToSpeechComponent()
           {
                 ClassItem = "",
                 ClassContainer = "main-section-image",
           };
            obj.textToDialectComponent=new TextToDialectComponent()
           {
                 ClassItem = "",
                 ClassContainer = "main-section-image",
           };

            obj.textToSpeechComponent.Build(db.TextToSpeech);
            obj.textToDialectComponent.Build(db.TextToDialect);
           return obj;
           // obj.Build(db);

       }


}

















    public enum OperationType
{
    TextToSpeech,   
    TextToDialect,   
    ApiTesting,      
    SaveSound,      
    PlaySound,      
    ShareResult,    
    WatchVideo        
    

}



public class OnDataResult
{
    


    public string Text{get;set;}
    public string OperationType{get;set;}
    public bool Sccess{get;set;}=false;
    public string SelectLanguage{get;set;}
    public string  TypeSend{get;set;}
    public string Url{get;set;}
    



}

public class TextToSpeechStep
{ 


  public string TolTabText{get;set;} ="";
    public string NameCompoent{get;set;} ="Text To Speech";
    public string Valtion{get;set;}="!@#$%^&*()";
    public int CountText{get;set;}=10;
    public string Description { get; set; } = "Convert text to speech by selecting a language.";
    public List<string> AvailableLanguages { get; set; } = new List<string> { "English", "Arabic", "Spanish", "French" };
    public string VideoLink { get; set; } = "https://www.youtube.com/embed/example_video1";

}


public class TextToDialectStep
{
    public string TolTabText{get;set;}="ENTER THE ";
    public string NameCompoent{get;set;}="Text To Text";
    public string Valtion{get;set;}="!@#$%^&*()";
    public int CountText{get;set;}=10;
    public string Description { get; set; } = "Convert text into a specific dialect of a language.";
    public List<string> AvailableDialects { get; set; } = new List<string> { "Egyptian", "Levantine", "Gulf" };
    public string VideoLink { get; set; } = "https://youtu.be/Ci6CGbe33TU?si=BDus0nN0tM6QVnFc";
}

public class ApiTestingStep
{   public string TolTabText{get;set;} ="";
    public string NameCompoent{get;set;} ="";
    public string Valtion{get;set;} ="";
    public string Description { get; set; } = "Test API connection with example code.";
    public string ApiCode { get; set; } = "curl -X POST https://example.com/api";
    public string VideoLink { get; set; } = "https://youtu.be/Ci6CGbe33TU?si=BDus0nN0tM6QVnFc";
}

public class DataBuildServicePage
{
    
    public TextToSpeechStep TextToSpeech { get; set; } = new TextToSpeechStep();
    public TextToDialectStep TextToDialect { get; set; } = new TextToDialectStep();
    public ApiTestingStep ApiTesting { get; set; } = new ApiTestingStep();
}


}