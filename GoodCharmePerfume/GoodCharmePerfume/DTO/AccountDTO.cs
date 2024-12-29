using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCharmePerfume.DTO
{
    public class AccountDTO
    {
        private string maTK;
        private string username;
        private string password;
        private string phanQuyen;

        public string MaTK { get => maTK; set => maTK = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string PhanQuyen { get => phanQuyen; set => phanQuyen = value; }

        public AccountDTO(string maTK, string username, string password, string phanQuyen)
        {
            this.maTK = maTK;
            this.username = username;
            this.password = password;
            this.phanQuyen = phanQuyen;
        }

        public AccountDTO(DataRow row)
        {
            this.maTK = row["maTK"].ToString();
            this.username = row["username"] != DBNull.Value ? row["username"].ToString() : null;
            this.password = row["password"] != DBNull.Value ? row["password"].ToString() : null;
            this.phanQuyen = row["phanQuyen"].ToString();
        }
    }
}
