    public async Task<DeletedResponse> DeleteServiceMethodsAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteServiceMethodsAsync(id, cancellationToken);
        

   }

