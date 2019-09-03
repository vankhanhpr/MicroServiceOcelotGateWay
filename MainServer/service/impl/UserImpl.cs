using AuthServer.data;
using MainServer.responsitory.impl;
using ModelClassLibrary.area.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServer.service.impl
{
    public class UserImpl : Responsitory<Users>, IUser
    {
        public UserImpl(DataContext context) : base(context)
        {
        }
        public void deleteUser(int id)
        {
            delete(id);
        }
        public dynamic getAllUser()
        {
            return getAll();
        }
        public Users getUserById(int id)
        {
            return getById(id);
        }
        public void insertUser(Users user)
        {
            insert(user);
        }
        public void updateUser(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
