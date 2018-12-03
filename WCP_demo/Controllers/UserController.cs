using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WCP_Repositories;
using WCP_Repositories.IRepositories;

namespace WCP_demo.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        protected IUserRepository UserRepository { get; set; }

        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        /// <summary>
        /// 获取信息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserList")]
        public async Task<List<UserInfo>> GetUserList()
        {
            _logger.Info("获取信息列表");
            var list = await UserRepository.GetUserInfoList();
            return list;
        }

        /// <summary>
        /// 异常测试
        /// </summary>
        [HttpGet("TestException")]
        public void TestException()
        {
            var ran = new Random();
            var x = ran.Next(1, 100);

            if (x % 2 != 0)
            {
                throw new GLException(ErrorCode.E10001, nameof(ErrorCode.E10001).GetCode());
            }
            else
                throw new Exception("异常错误测试");
        }

        //测试自动构建
        //测试自动构建

    }
}
