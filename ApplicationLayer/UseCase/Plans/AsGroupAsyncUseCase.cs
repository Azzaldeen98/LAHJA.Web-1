    public async Task<ICollection<PlanView>> AsGroupAsync(string langauge, CancellationToken cancellationToken)
   {

    
         return    await _repository.AsGroupAsync(langauge, cancellationToken);
        

   }

