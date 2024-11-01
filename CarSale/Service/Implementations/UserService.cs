using Entities.Dbset;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userReposttory;
        private readonly ICurrentUser _currentUser;
        public UserService(IUserRepository userRepository, ICurrentUser currentUser)
        {
            _userReposttory = userRepository;
            _currentUser = currentUser;     
        }
        public User LoginUser(string username, string password)
        {
            var user= _userReposttory.LoginUser(username);
            
            if(user!=null && user.Password.Equals(password)&&user.UserId.Equals(username))
            {
                return user;
            }
            return null;
        }
        public void BlockAndUnBlockUser(string userId)
        {
            var name = _currentUser.name;
            var id=_currentUser.UserId;
            var jjj = _currentUser.Name;
            var role = _currentUser.RoleId;

            _userReposttory.BlockAndUnBlockUser(userId);
        }
    }
}
