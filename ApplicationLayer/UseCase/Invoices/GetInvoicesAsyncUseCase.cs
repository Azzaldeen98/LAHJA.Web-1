    public async Task<ICollection<Invoice>> GetInvoicesAsync(string customerId, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetInvoicesAsync(customerId, cancellationToken);
        

   }

