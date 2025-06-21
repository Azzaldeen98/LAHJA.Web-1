    public async Task<ICollection<ModelAiServiceData>> ModelAiServiceRequestsAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.ModelAiServiceRequestsAsync(cancellationToken);
        

   }

