using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using static futbol_liga.ControlRefere;
using System.Xml;

namespace futbol_liga
{
    internal class ControlGames : ConnectDB
    {
        public static DataTable dtable = new DataTable();
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
        public DataTable searchData(string keyText)
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT games.team1, games.team2, games.stadium, referees.name AS refere_name , referees.last_name as refere_last_name FROM games  " +
                "JOIN referees  ON games.refere_id = referees.id WHERE games.stadium LIKE '%"+keyText+"%' OR games.team1 " +
                "LIKE '%"+keyText+"%' OR games.team2 LIKE '%"+keyText+"%' OR referees.name LIKE '%"+keyText+"%' OR referees.last_name LIKE '%"+keyText+ "%' ;";
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
        public DataTable filtrData(string belgi1,string min,string belgi2,string max)
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT team.name,  result.points, team.coach, team.president,   top_scorer.name AS top_scorer_name, team.country " +
                "FROM  team LEFT JOIN  top_scorer ON team.id = top_scorer.team_id LEFT JOIN result ON team.id = result.team_id WHERE result.points "+belgi1+" "+min+" and result.points"+belgi2+""+max+";";
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
        public DataTable filtrData1(string belgi1, string min)
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT team.name, result.points,team.coach, team.president, " +
                "top_scorer.name AS top_scorer_name, team.country FROM team LEFT JOIN top_scorer ON team.id = top_scorer.team_id LEFT JOIN result ON team.id = result.team_id " +
                "WHERE result.points " + belgi1 + " " + min + ";";
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
        public DataTable filtrData2(string belgi2, string max)
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT team.name, result.points,team.coach, team.president, " +
                "top_scorer.name AS top_scorer_name, team.country FROM team LEFT JOIN top_scorer ON team.id = top_scorer.team_id LEFT JOIN result ON team.id = result.team_id " +
                "WHERE result.points " + belgi2 + " " + max + ";";
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
        public DataTable filtr(string team, string country, string tsname,string president)
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT team.name,team.country,team.coach,team.president,top_scorer.name AS top_scorer_name FROM " +
                "team INNER JOIN  top_scorer ON team.id = top_scorer.team_id WHERE team.name LIKE '%"+team+"%' AND" +
                " team.country LIKE '%"+country+"%'" +
                " AND top_scorer.name LIKE '%"+tsname+"%' AND team.president LIKE '%"+president+"%';";
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
        public int getIdByName(string name)
        {
            int id = 0;
            foreach (DataRow row in dtable.Rows)
            {
                if (row["name"].ToString() == name)
                {
                    id = int.Parse(row["id"].ToString());
                }
            }
            return id;
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
        

