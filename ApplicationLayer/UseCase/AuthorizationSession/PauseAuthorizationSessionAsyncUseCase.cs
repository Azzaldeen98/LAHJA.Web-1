    public async Task<DeletedResponse> PauseAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.PauseAuthorizationSessionAsync(id, cancellationToken);
        

   }

