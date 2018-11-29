using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCP_DealCommon;
using WCP_Repositories.IRepositories;

namespace WCP_Repositories
{
    public class UserRepository : SqlConnections, IUserRepository
    {

        public UserRepository(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"))
        {
        }       

        public async Task<List<UserInfo>> GetUserInfoList()
        {           
            using (Connection)
            {
                DynamicParameters param = new DynamicParameters();
                string sql = "select * from userinfo where 1=1;";

                var user = await Connection.QueryAsync<UserInfo>(sql);
                return user.ToList();
            }
        }
    }
}
