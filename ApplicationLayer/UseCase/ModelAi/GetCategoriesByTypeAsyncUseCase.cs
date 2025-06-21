    public async Task<ArrayResponse> GetCategoriesByTypeAsync(string type, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetCategoriesByTypeAsync(type, cancellationToken);
        

   }

