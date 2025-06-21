    public async Task<ICollection<ModelAiResponse>> GetModelsByGenderAsync(string gender, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByGenderAsync(gender, cancellationToken);
        

   }

