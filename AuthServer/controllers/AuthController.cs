using System;
using AuthServer.service;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.area.respond;
using ModelClassLibrary.area.user;

namespace AuthServer.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuth m_auth;

        public AuthController(IAuth auth)
        {
            m_auth = auth;
        }

        [HttpPost("login")]
        public DataRespond login([FromBody]Users user)
        {
            DataRespond data = new DataRespond();
            try
            {
                data = m_auth.login(user);
            }
            catch(Exception e)
            {
                data.success = false;
                data.message = e.Message;
                data.error = e;
            }
            return data;
        }
    }
}