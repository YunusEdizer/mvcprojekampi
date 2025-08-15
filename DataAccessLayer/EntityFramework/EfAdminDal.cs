using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{

    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public Admin GetByUserNameAndPassword(string userName, string password)
        {

            using (var c = new Context())
            {
                return c.Admins.FirstOrDefault(x => x.AdminUserName == userName && x.AdminPassword == password);
            }
        }
    }
}
