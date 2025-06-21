namespace Domain.Entities.ModelAi
{
    public partial class ValueFilterModelEntity
    {


          public ICollection<FilterModelPropertyValuesEntity> Type { get; set; }


          public ICollection<FilterModelPropertyValuesEntity> Categary { get; set; }

  
          public ICollection<FilterModelPropertyValuesEntity> Langague { get; set; }


          public ICollection<FilterModelPropertyValuesEntity> Gender { get; set; }


          public ICollection<FilterModelPropertyValuesEntity> Dialect { get; set; }

 }
}
