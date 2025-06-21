    public async Task<TypeModelView> TypesGETAsync(string name, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.TypesGETAsync(name, lg, cancellationToken);
        

   }

