using Microsoft.AspNetCore.Http;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CurrentUser :ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? Name => /*_httpContextAccessor.HttpContext?.User?.Identity?.Name;*/
        _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        public string? name => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault()?.Value;
        public int? RoleId => Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirst("RoleId")?.Value);
        public int? UserId => Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value);

    }
}
