using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICurrentUser
    {
        string? Name { get; }
        string? name { get; }
        int? RoleId { get; }
        int? UserId { get; }
    }
}
