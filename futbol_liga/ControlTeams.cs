using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlTypes;
using static futbol_liga.ControlRefere;
namespace futbol_liga
{
    internal class ControlTeams : ConnectDB
    {
        public bool InsertTeam(Teams team)
        {

            int e = 0;
            sqlString = "INSERT INTO team values('" + team.name + "' , '" + team.country + "', '" + team.coach + "','" + team.president + "', '" + team.picture + "');";
            try
            {
                cmd = new SqlCommand(sqlString, conn);
                e = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool updateTeams(Teams team)
        {
            int e = 0;
            sqlString = "UPDATE team SET name='" + team.name + "', country='" + team.country + "', coach='" + team.coach + "', president='" + team.president + "', picture='" + team.picture + "' WHERE id=" + team.id + ";";
            try
            {
                cmd = new SqlCommand(sqlString, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteData(int id)
        {
            int e = 0;
            sqlString = "DELETE team WHERE id=" + id;
            try
            {
                cmd = new SqlCommand(sqlString, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getData()
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT*FROM team";
            try
            {
                adapter = new SqlDataAdapter(sqlString, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }

    }
    public class Teams
    {
        public int id;
        public string name;
        public string country;
        public string coach;
        public string president;
        public string picture;
        public Teams(int id, string name, string country, string coach, string president, string picture)
        {
            this.id = id;
            this.name = name;
            this.country = country;
            this.coach = coach;
            this.president = president;
            this.picture = picture;
        }
        public Teams(string name, string country, string coach, string president, string picture)
        {
            this.name = name;
            this.country = country;
            this.coach = coach;
            this.president = president;
            this.picture = picture;
        }
    }
}
