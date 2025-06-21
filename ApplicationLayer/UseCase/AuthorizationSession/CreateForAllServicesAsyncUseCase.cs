    public async Task<AuthorizationSessionWebResponse> CreateForAllServicesAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateForAllServicesAsync(body, cancellationToken);
        

   }

