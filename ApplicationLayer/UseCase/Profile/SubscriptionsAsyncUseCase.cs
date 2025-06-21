    public async Task<ICollection<SubscriptionResponse>> SubscriptionsAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.SubscriptionsAsync(cancellationToken);
        

   }

