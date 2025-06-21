    public async Task<AdvertisementView> AdvertisementsGETAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.AdvertisementsGETAsync(id, lg, cancellationToken);
        

   }

