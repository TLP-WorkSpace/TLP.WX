using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WCP_Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<List<UserInfo>> GetUserInfoList();
    }
}
