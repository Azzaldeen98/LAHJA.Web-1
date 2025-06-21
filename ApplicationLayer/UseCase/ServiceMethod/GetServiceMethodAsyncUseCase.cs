    public async Task<ServiceMethodResponse> GetServiceMethodAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetServiceMethodAsync(id, cancellationToken);
        

   }

