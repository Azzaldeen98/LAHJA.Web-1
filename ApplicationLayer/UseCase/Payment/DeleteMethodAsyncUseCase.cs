    public async Task DeleteMethodAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.DeleteMethodAsync(id, cancellationToken);
        

   }

