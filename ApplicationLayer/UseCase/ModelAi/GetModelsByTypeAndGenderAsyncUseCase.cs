    public async Task<ICollection<ModelAiResponse>> GetModelsByTypeAndGenderAsync(string type, string gender, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByTypeAndGenderAsync(type, gender, cancellationToken);
        

   }

