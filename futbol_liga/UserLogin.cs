using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futbol_liga
{
    internal class UserLogin :ConnectDB
    {

        
        
            public static string Username = String.Empty;
            public static string Password = String.Empty;
            public static string userPhoto = String.Empty;
            public static bool isLogin = false;
            public UserLogin(string username, string password)
            {
                username.Trim();
                password.Trim();
                if (!isLogin)
                {
                    sqlString = "SELECT * FROM referees WHERE username='" + username + "' AND password='" + password + "'";
                    cmd = new SqlCommand(sqlString, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Username = username;
                        Password = password;
                        isLogin = true;
                        userPhoto = reader.GetString(4);
                    }
                }
            }
        }

    }

