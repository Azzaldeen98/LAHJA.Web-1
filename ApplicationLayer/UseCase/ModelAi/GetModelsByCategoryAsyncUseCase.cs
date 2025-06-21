    public async Task<ICollection<ModelAiResponse>> GetModelsByCategoryAsync(string category, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByCategoryAsync(category, cancellationToken);
        

   }

