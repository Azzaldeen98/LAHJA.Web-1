    public async Task<SessionVm> GetSessionAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSessionAsync(id, cancellationToken);
        

   }

