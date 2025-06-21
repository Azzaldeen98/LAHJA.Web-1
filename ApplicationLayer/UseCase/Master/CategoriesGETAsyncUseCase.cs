    public async Task CategoriesGETAsync(string name, string lg, CancellationToken cancellationToken)
   {

    
          await _repository.CategoriesGETAsync(name, lg, cancellationToken);
        

   }

