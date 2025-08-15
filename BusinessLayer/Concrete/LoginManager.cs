using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        private readonly IAdminDal _adminDal;

        public LoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin Login(string userName, string password)
        {
            return _adminDal.GetByUserNameAndPassword(userName, password);
        }
    }
}
