    public async Task<DeletedResponse> DeleteSpaceAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteSpaceAsync(id, cancellationToken);
        

   }

