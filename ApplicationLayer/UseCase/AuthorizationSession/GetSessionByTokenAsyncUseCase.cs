    public async Task<SessionVm> GetSessionByTokenAsync(string token, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSessionByTokenAsync(token, cancellationToken);
        

   }

