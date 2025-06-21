    public async Task<SubscriptionResponse> GetSubscriptionAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSubscriptionAsync(id, cancellationToken);
        

   }

