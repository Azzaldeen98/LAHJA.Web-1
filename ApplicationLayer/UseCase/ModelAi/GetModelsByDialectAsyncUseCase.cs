    public async Task<ICollection<ModelAiResponse>> GetModelsByDialectAsync(string dialect, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByDialectAsync(dialect, cancellationToken);
        

   }

