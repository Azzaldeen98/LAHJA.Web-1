    public async Task<CheckoutResponse> ManageAsync(SessionCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.ManageAsync(body, cancellationToken);
        

   }

