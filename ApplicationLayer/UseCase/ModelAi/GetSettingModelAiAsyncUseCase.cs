    public async Task<ModelPropertyValues> GetSettingModelAiAsync(string langage, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSettingModelAiAsync(langage, cancellationToken);
        

   }

