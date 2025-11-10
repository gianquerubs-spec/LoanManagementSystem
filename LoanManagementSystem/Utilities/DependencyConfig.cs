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

        public static IAuthService CreateAuthService()
        {
            return new AuthService(CreateUserRepository()); 
        }
    }
}