    public async Task<Invoice> GetInvoiceAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetInvoiceAsync(id, cancellationToken);
        

   }

