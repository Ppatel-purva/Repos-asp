using JWT_Tokens.Models;


namespace JWT_Tokens.Repository
{
    public interface IJWTManagerRepository
    {

        Tokens Authenticate(Users user);

        
    }
}
