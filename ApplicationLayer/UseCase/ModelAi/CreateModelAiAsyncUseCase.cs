    public async Task<ModelAiResponse> CreateModelAiAsync(ModelAiCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateModelAiAsync(body, cancellationToken);
        

   }

