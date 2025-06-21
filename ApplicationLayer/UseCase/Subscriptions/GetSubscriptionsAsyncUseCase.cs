    public async Task<ICollection<SubscriptionResponse>> GetSubscriptionsAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSubscriptionsAsync(cancellationToken);
        

   }

