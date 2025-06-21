    public async Task SearchAsync(PriceSearchOptions body, CancellationToken cancellationToken)
   {

    
          await _repository.SearchAsync(body, cancellationToken);
        

   }

