    public async Task<ServiceResponse> SettingGETAsync(string name, CancellationToken cancellationToken)
   {

    
         return    await _repository.SettingGETAsync(name, cancellationToken);
        

   }

