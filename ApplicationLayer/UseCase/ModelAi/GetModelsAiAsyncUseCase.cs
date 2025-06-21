    public async Task<ICollection<ModelAiResponse>> GetModelsAiAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsAiAsync(cancellationToken);
        

   }

