    public async Task<DeletedResponse> DeleteServiceAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteServiceAsync(id, cancellationToken);
        

   }

