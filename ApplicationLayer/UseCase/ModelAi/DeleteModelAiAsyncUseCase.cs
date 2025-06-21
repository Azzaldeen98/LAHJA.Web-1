    public async Task<DeletedResponse> DeleteModelAiAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteModelAiAsync(id, cancellationToken);
        

   }

