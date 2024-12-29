using GoodCharmePerfume.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GoodCharmePerfume.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get => instance == null ? instance = new AccountDAO() : instance;
            private set => instance = value;
        }

        private AccountDAO() { }

        public List<AccountDTO> Login(string userName, string passWord)
        {
            List<AccountDTO> list = new List<AccountDTO>();
            string query = "SELECT * FROM TaiKhoan WHERE Username = @userName AND Password = @passWord";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                list.Add(account);
            }
            return list;
        }
    }
}
