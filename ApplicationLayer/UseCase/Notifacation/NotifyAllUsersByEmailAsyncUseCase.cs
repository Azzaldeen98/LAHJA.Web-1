    public async Task NotifyAllUsersByEmailAsync(string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    
          await _repository.NotifyAllUsersByEmailAsync(subject, htmlMessage, cancellationToken);
        

   }

