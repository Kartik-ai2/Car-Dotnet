using Entities.Dbset;

namespace Service.Interface
{
    public  interface IUserService
    {
        User LoginUser(string username, string password);

        void BlockAndUnBlockUser(string userId);
    }
}
