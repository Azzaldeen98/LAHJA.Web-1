    public async Task ResetRequestsAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.ResetRequestsAsync(id, cancellationToken);
        

   }

