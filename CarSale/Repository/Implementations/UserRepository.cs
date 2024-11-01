using Entities.Dbset;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementations
{

    public class UserRepository : IUserRepository
    {
        private readonly CarContext _carContext;
        public UserRepository(CarContext carContext)
        {
            _carContext = carContext;
        }
        public User LoginUser(string userId)
        {
            return _carContext.Users.Include(x => x.UserRoles).ThenInclude(x => x.Roles).FirstOrDefault(x => x.UserId.Equals(userId));
        }

        public void BlockAndUnBlockUser(string userId)
        {
            var user= _carContext.Users.FirstOrDefault(x=>x.UserId.Equals(userId));
            user.IsBlocked=!user.IsBlocked;
            _carContext.Users.Update(user);
            _carContext.SaveChanges();
        }
    }
}
