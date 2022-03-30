using Models.Framework;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineShop.Models
{

    public class AccountModel
    {
        private OnlineShopDbContext context = null;
        public AccountModel()
        {
            context = new OnlineShopDbContext();
        }
        public bool Login(string userName, string password)
        {
            object[] sqlParams = 
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Password",password)
            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login", sqlParams).SingleOrDefault();
            return res;
        }
    }
}