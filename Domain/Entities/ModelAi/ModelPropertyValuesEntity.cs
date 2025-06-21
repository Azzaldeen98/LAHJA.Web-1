namespace Domain.Entities.ModelAi
{
    public partial class ModelPropertyValuesEntity
    {

        public ICollection<string> UsageCount { get; set; }


        public ICollection<string> ModelImageUrl { get; set; }

        public ICollection<string> Type { get; set; }

        public ICollection<string> Voice { get; set; }

        public ICollection<string> Language { get; set; }


        public ICollection<string> Dialect { get; set; }

        public ICollection<string> Quality { get; set; }

      
        public ICollection<string> Token { get; set; }


        public ICollection<string> ModelVersion { get; set; }

 
        public ICollection<string> CreationDate { get; set; }


        public ICollection<string> LastUpdated { get; set; }

        public ICollection<string> Description { get; set; }

        public ICollection<string> Author { get; set; }


        public ICollection<string> Accuracy { get; set; }


        public ICollection<string> Speed { get; set; }

        public ICollection<string> Framework { get; set; }

        public ICollection<string> Parameters { get; set; }

    }
}
