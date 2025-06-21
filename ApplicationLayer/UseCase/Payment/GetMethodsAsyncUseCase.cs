    public async Task<ICollection<PaymentMethodResponse>> GetMethodsAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetMethodsAsync(cancellationToken);
        

   }

