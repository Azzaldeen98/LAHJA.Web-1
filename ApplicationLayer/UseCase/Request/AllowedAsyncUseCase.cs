    public async Task<RequestAllowed> AllowedAsync(string serviceId, CancellationToken cancellationToken)
   {

    
         return    await _repository.AllowedAsync(serviceId, cancellationToken);
        

   }

