    public async Task<ICollection<SpaceResponse>> GetSpacesAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSpacesAsync(cancellationToken);
        

   }

