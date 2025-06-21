    public async Task<ICollection<ProductResponse>> SearchAllAsync(string query, int? limit, string page, CancellationToken cancellationToken)
   {

    
         return    await _repository.SearchAllAsync(query, limit, page, cancellationToken);
        

   }

