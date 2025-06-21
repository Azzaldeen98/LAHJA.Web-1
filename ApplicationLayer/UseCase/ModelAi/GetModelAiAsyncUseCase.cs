    public async Task<ModelAiResponse> GetModelAiAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelAiAsync(id, cancellationToken);
        

   }

