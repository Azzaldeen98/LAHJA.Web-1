    public async Task<ICollection<AdvertisementTabView>> AdvertisementtabsAllAsync(string advertisementId, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.AdvertisementtabsAllAsync(advertisementId, lg, cancellationToken);
        

   }

