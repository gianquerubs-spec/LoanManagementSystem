using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public interface IClientService
    {
        List<Client> GetAllClients();
        Client GetClientById(int id);
        bool AddClient(Client client, int createdByUserId);
        bool UpdateClient(Client client);
        bool DeleteClient(int id);
        List<Client> SearchClients(string searchTerm);
    }
}