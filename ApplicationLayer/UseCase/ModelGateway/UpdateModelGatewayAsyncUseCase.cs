    public async Task<ModelGatewayResponse> UpdateModelGatewayAsync(string id, ModelGatewayUpdate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdateModelGatewayAsync(id, body, cancellationToken);
        

   }

