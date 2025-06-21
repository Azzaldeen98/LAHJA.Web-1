    public async Task<ICollection<PlanView>> GetPlansAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetPlansAsync(lg, cancellationToken);
        

   }

