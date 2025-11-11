using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Interfaces.Services
{
    public interface IClientService
    {
        List<Client> GetAllClients();
        Client GetClientById(int id);
        Client GetClientByCode(string clientCode);
        bool AddClient(Client client, int createdByUserId);
        bool UpdateClient(Client client);
        bool DeleteClient(int id);
        bool DeleteClientByCode(string clientCode);
        List<Client> SearchClients(string searchTerm);
     
    }
}