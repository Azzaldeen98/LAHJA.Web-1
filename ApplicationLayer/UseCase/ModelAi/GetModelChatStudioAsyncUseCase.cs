    public async Task<IDictionary<string, object>> GetModelChatStudioAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelChatStudioAsync(lg, cancellationToken);
        

   }

