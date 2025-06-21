    public async Task<ICollection<SessionVm>> GetSessionsAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSessionsAsync(cancellationToken);
        

   }

