    public async Task<ICollection<ModelAiResponse>> ModelAisAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.ModelAisAsync(cancellationToken);
        

   }

