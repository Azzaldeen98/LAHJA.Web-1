    public async Task<ICollection<ArrayResponse>> GetModelsByTypeAsync(string type, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByTypeAsync(type, cancellationToken);
        

   }

