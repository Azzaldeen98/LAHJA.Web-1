    public async Task<ICollection<ModelAiResponse>> FilterMaodelAiAsync(FilterModelAI body, CancellationToken cancellationToken)
   {

    
         return    await _repository.FilterMaodelAiAsync(body, cancellationToken);
        

   }

