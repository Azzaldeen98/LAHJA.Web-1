    public async Task<ICollection<SpaceResponse>> SpacesSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
         return    await _repository.SpacesSubscriptionAsync(subscriptionId, cancellationToken);
        

   }

