    public async Task<DeletedResponse> DeleteModelGatewayAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteModelGatewayAsync(id, cancellationToken);
        

   }

