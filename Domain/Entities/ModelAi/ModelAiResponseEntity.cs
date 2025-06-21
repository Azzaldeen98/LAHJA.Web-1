namespace Domain.Entities.ModelAi
{
    public partial class ModelAiResponseEntity
    {
      public string Id { get; set; }
      public string Name { get; set; }
      public string Token { get; set; }
      public string AbsolutePath { get; set; }
      public string ModelGatewayId { get; set; }
      public string Category { get; set; }
      public string Language { get; set; }
      public bool? IsStandard { get; set; }
      public string Gender { get; set; }
      public string Dialect { get; set; }
      public string Type { get; set; }

    }
}
