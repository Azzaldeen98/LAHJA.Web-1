    public async Task<ICollection<SpaceResponse>> GetBySubscriptionIdAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetBySubscriptionIdAsync(subscriptionId, cancellationToken);
        

   }

