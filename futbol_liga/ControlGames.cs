using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using static futbol_liga.ControlRefere;

namespace futbol_liga
{
    internal class ControlGames : ConnectDB
    {
        public bool insertGame(Games game)
        {
            int e = 0;
            sqlString = "INSERT INTO games (game_time, stadium, refere_id, team1, team2) VALUES('"+game.game_time+"', '"+game.stadium+"', "+game.refere_id+", '"+game.team1+"', '"+game.team2+"');";
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
        public DataTable getDataGames()
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT * FROM games;";
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

        public bool deleteData(int id)
        {
            int e = 0;
            sqlString = "DELETE games WHERE id=" + id;
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
        public bool update(Games game)
        {
            int e = 0;
            sqlString = "UPDATE games SET game_time='" + game.game_time + "', stadium='" + game.stadium + "', refere_id=" + game.refere_id + ", team1='" + game.team1 + "', team2='" + game.team2 + "' WHERE id=" + game.id + ";";
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
    }
    public class Games
    {
        public int id;
        public string game_time;
        public string stadium;
        public int refere_id;
        public string team1;
        public string team2;
        public Games(int id, string game_time, string stadium, int refere_id, string team1, string team2)
        {
            this.id = id;
            this.game_time = game_time;
            this.stadium = stadium;
            this.refere_id = refere_id;
            this.team1 = team1;
            this.team2 = team2;
        }
        public Games(string game_time, string stadium, int refere_id, string team1, string team2)
        {
            this.game_time = game_time;
            this.stadium = stadium;
            this.refere_id = refere_id;
            this.team1 = team1;
            this.team2 = team2;
        }
    }
}
        

