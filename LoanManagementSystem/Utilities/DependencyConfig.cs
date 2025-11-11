using LoanManagementSystem.Interfaces.Services;
using LoanManagementSystem.Repositories;
using LoanManagementSystem.Services;

namespace LoanManagementSystem.Utilities
{
    public static class DependencyConfig
    {
        public static IUserRepository CreateUserRepository()
        {
            return new UserRepository();
        }

        public static IClientRepository CreateClientRepository()
        {
            return new ClientRepository();
        }

        public static ILoanRepository CreateLoanRepository()
        {
            return new LoanRepository();
        }

        public static IAuthService CreateAuthService()
        {
            return new AuthService(CreateUserRepository());
        }

        public static IClientService CreateClientService()
        {
            return new ClientService(); // Your existing ClientService
        }

        public static ILoanService CreateLoanService()
        {
            return new LoanService();
        }
        public static IUserService CreateUserService()
        {
            return new UserService(CreateUserRepository());
        }
    }
}