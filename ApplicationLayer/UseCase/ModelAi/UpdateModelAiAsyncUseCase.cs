    public async Task<ModelAiResponse> UpdateModelAiAsync(string id, ModelAiUpdate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdateModelAiAsync(id, body, cancellationToken);
        

   }

