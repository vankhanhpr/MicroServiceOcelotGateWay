using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainServer.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.area.auth;
using ModelClassLibrary.area.respond;
using ModelClassLibrary.area.user;

namespace MainServer.controllers
{
    [Authorize(Roles = Roles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUser m_user;
        public UserController(IUser user)
        {
            m_user = user;
        }

        [HttpGet("getAllUser")]
        public DataRespond getAllUser()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_user.getAllUser();
                data.message = "success";
            }
            catch(Exception e)
            {
                data.message = e.Message;
                data.success = false;
                data.error = e;
            }
            return data;
        }

        [HttpGet("getUserById")]
        public DataRespond getUserById(int id)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.message = "success";
                data.data = m_user.getUserById(id);
            }
            catch(Exception e)
            {
                data.message = e.Message;
                data.error = e;
                data.success = false;
            }
            return data;
        }

        [HttpPost("insertUser")]
        public DataRespond insertUser(Users user)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.message = "insert success";
                m_user.insertUser(user);
            }
            catch(Exception e)
            {
                data.message = e.Message;
                data.error = e;
                data.success = false;
            }
            return data;
        }
    }
}