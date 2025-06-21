    public async Task<ModelGatewayResponse> GetModelGatewayAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelGatewayAsync(id, cancellationToken);
        

   }

