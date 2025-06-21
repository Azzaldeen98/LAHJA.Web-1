    public async Task<AuthorizationSessionWebResponse> CreateForDashboardAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateForDashboardAsync(body, cancellationToken);
        

   }

