    public async Task<ICollection<StatisticsUsedRequests>> ServiceUsageDataAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.ServiceUsageDataAsync(cancellationToken);
        

   }

