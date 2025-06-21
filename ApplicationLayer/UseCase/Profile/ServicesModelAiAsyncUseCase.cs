    public async Task<ICollection<ServiceResponse>> ServicesModelAiAsync(string modelAiId, CancellationToken cancellationToken)
   {

    
         return    await _repository.ServicesModelAiAsync(modelAiId, cancellationToken);
        

   }

