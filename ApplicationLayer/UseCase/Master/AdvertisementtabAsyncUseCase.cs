    public async Task<AdvertisementTabView> AdvertisementtabAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.AdvertisementtabAsync(id, lg, cancellationToken);
        

   }

