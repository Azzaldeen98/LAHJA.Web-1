    public async Task<ICollection<TypeModelView>> ActiveAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.ActiveAsync(lg, cancellationToken);
        

   }

