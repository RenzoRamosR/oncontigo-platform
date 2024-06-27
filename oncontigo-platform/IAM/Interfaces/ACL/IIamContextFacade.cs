namespace oncontigo_platform.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(string username, string password);
    Task<int> FetchUserIdByEmail(string username);
    Task<string> FetchEmailByUserId(int userId);
}
