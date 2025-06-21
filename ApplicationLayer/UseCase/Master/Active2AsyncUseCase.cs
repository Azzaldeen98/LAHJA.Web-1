    public async Task<ICollection<AdvertisementView>> Active2Async(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.Active2Async(lg, cancellationToken);
        

   }

