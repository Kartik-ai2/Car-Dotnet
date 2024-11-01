using Entities.Dbset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        User LoginUser(string username);
        void BlockAndUnBlockUser(string userId);
        
    }
}
