    public async Task SettingPUTAsync(string name, SettingUpdate body, CancellationToken cancellationToken)
   {

    
          await _repository.SettingPUTAsync(name, body, cancellationToken);
        

   }

