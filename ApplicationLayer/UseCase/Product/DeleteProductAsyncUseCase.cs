    public async Task<DeletedResponse> DeleteProductAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteProductAsync(id, cancellationToken);
        

   }

