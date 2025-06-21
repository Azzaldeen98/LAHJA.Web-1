    public async Task<DeletedResponse> DeleteAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteAuthorizationSessionAsync(id, cancellationToken);
        

   }

