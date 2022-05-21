using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace POS_APP {
    static class dbConfig {
        private static string server = "WIN-HKB7QARTSJ1\\KMUTNBMC";
        private static string database = "ElectronicsDB";
        private static string user = "user1";
        private static string password = "mypass1";

        private static string strConnString = 
            $"server={server};" +
            $"database={database};" +
            $"user id={user};" +
            $"password={password};";

        public static SqlConnection connection = new SqlConnection(strConnString);
    }
}
