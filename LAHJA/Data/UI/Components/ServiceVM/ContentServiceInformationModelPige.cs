namespace LAHJA.Data.UI.Components.ServiceVM
{
    public class ContentServiceInformationModelPige
    {
        public ContentItemT2T TableOfContents { get; set; }
        public ContentItemT2T ModelSummary { get; set; }
        public ContentItemT2T InferenceExamples { get; set; }
        public List<ContentItemT2T> ModelTree { get; set; }
        public ContentItemT2T DownloadsTrend { get; set; }
    }


    public class ContentItemT2T
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class InfoServecModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
       
        public List<LanguageModel> languageModels { get; set; }


    }



    public class LanguageModel
    {



        public string TypeFeture { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<DialectModel> Dialects { get; set; }
    }


  
    public class DialectModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<ServiceaAppModel> Services { get; set; }
    }



    public class ServiceaAppModel
    {


        public string Id { get; set; }
        public string IdFetureApp { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public string Input { get; set; }
        public string Type { get;set; }
        public string OutPut { get; set; }
        public decimal Price { get; set; }
        public string Sender { get; set; }
        public string Voice { get; set; }
        public bool First { get; set; }


    }



}
