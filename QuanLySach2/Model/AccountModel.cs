using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AccountModel
    {
        LoginABCD context = null;
        public AccountModel()
        {
            context = new LoginABCD();
        }

        public bool Login(string userName, string Password)
        {
            object[] sqlParas = {
                new SqlParameter("@MaNV", userName),
                new SqlParameter("@MatKhauNV", Password),
            };

            //Gọi thủ tục đã tạo có tên "Sp_Account_Login" sử dụng SingleOrDefault() để trả về giá trị duy nhất, 
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login4 @MaNV, @MatKhauNV", sqlParas).SingleOrDefault();
            return res;
        }

    }
}
