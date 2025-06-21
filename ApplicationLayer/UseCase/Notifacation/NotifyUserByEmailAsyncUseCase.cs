    public async Task NotifyUserByEmailAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    
          await _repository.NotifyUserByEmailAsync(email, subject, htmlMessage, cancellationToken);
        

   }

