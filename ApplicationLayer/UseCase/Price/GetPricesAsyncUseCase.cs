    public async Task<ICollection<PriceResponse>> GetPricesAsync(string productId, bool? active, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetPricesAsync(productId, active, cancellationToken);
        

   }

