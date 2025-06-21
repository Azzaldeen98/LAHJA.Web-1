    public async Task<SessionVm> GetActiveSessionAsync(string userId, string type, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetActiveSessionAsync(userId, type, cancellationToken);
        

   }

