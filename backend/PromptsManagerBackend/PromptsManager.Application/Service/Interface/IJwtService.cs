using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptsManager.Application.Service.Interface
{
    public interface IJwtService
    {
        public string GenerateToken(string userId, string email, List<string> roles);
    }
}
