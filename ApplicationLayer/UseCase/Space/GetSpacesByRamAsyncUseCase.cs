    public async Task<ICollection<SpaceResponse>> GetSpacesByRamAsync(int ram, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSpacesByRamAsync(ram, cancellationToken);
        

   }

