    public async Task<SpaceResponse> GetByTokenAsync(string token, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetByTokenAsync(token, cancellationToken);
        

   }

