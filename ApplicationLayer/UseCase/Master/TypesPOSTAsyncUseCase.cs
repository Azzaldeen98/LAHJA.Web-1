    public async Task<TypeModelView> TypesPOSTAsync(string lg, TypeModelCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.TypesPOSTAsync(lg, body, cancellationToken);
        

   }

