using ModelClassLibrary.area.respond;
using ModelClassLibrary.area.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.service
{
    public interface IAuth
    {
        DataRespond login(Users user);
        Users getUser(Users user);
    }
}
