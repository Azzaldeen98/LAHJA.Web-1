    public async Task<ICollection<ServiceUsersCount>> ServiceUsersCountAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.ServiceUsersCountAsync(cancellationToken);
        

   }

