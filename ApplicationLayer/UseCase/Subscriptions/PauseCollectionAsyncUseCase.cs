    public async Task PauseCollectionAsync(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken)
   {

    
          await _repository.PauseCollectionAsync(id, body, cancellationToken);
        

   }

