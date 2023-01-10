using API_BARBEARIA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DAL.DAO
{
    public class UserDAO : BaseDAO<User>
    {
        public override User Create(User user)
        {


            return base.Create(user);
        }
    }
}
