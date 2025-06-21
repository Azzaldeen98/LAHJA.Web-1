    public async Task<UserResponse> AssignModelAiAsync(AssignModelAi body, CancellationToken cancellationToken)
   {

    
         return    await _repository.AssignModelAiAsync(body, cancellationToken);
        

   }

