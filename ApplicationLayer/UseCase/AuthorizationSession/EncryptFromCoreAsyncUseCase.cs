    public async Task<TokenVm> EncryptFromCoreAsync(string sesstionToken, CancellationToken cancellationToken)
   {

    
         return    await _repository.EncryptFromCoreAsync(sesstionToken, cancellationToken);
        

   }

