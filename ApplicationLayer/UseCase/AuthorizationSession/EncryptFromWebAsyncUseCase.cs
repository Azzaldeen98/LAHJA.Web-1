    public async Task<TokenVm> EncryptFromWebAsync(EncryptTokenRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.EncryptFromWebAsync(body, cancellationToken);
        

   }

