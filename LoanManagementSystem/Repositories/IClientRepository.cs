using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetAllClients();
        Client GetClientById(int id);
        bool AddClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(int id);
        List<Client> SearchClients(string searchTerm);
    }
}