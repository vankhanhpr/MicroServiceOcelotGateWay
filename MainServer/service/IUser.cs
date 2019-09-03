using ModelClassLibrary.area.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServer.service
{
    public interface IUser
    {
        dynamic getAllUser();
        Users getUserById(int id);
        void insertUser(Users user);
        void updateUser(Users user);
        void deleteUser(int id);
    }
}
