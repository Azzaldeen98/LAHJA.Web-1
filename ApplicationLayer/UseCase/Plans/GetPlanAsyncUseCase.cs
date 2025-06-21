    public async Task<PlanView> GetPlanAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetPlanAsync(id, lg, cancellationToken);
        

   }

