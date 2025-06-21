    public async Task<ICollection<ModelGatewayResponse>> GetModelGatwaysAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelGatwaysAsync(cancellationToken);
        

   }

