using App.Models;
using App.Repositories;
using App.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Impl
{
    public class ClientService : IClientService
    {
        private IClientRepository repository;

        public ClientService(IClientRepository repository)
        {
            this.repository = repository;
        }

        public void AjouterClient(Client client)
        {
            this.repository.Insert(client);
            this.repository.Save();
        }
    }
}
