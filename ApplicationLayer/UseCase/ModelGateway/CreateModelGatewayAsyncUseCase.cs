    public async Task<ModelGatewayResponse> CreateModelGatewayAsync(ModelGatewayCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateModelGatewayAsync(body, cancellationToken);
        

   }

