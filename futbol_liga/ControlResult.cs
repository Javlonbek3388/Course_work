using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static futbol_liga.ControlRefere;

namespace futbol_liga
{
    internal class ControlResult : ConnectDB
    {
        public static DataTable dt = new DataTable();
        public bool insert(Result res)
        {
            int e = 0;
            sqlString = "INSERT INTO result VALUES( " + res.team_id + " , " + res.points + ", " + res.game_count + "," + res.win + " , " + res.lose + ");";
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
        public bool InsertSc(top_scorer topsc)
        {
            int e = 0;
            sqlString = "INSERT INTO top_scorer VALUES( '" + topsc.name + "' , " + topsc.team_id + ", " + topsc.goal_count + ",'" + topsc.postion + "' , '" + topsc.picture + "');";
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
        public bool InsertAS(top_asist topsc)
        {
            int e = 0;
            sqlString = "INSERT INTO top_asist VALUES( '" + topsc.name + "' , " + topsc.team_id + ", " + topsc.asist_count + ",'" + topsc.postion + "' , '" + topsc.picture + "');";
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
        public bool deleteSC(int id)
        {
            int e = 0;
            sqlString = "DELETE top_scorer WHERE id=" + id;
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
        public bool deleteAS(int id)
        {
            int e = 0;
            sqlString = "DELETE top_asist WHERE id=" + id;
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
        public bool delete(int id)
        {
            int e = 0;
            sqlString = "DELETE result WHERE id=" + id;
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
        public bool updateSC(top_scorer score)
        {
            int e = 0;
            sqlString = "UPDATE top_scorer SET name='" + score.name + "', team_id=" + score.team_id + ", goal_count=" + score.goal_count + ", position='" + score.postion + "', picture='" + score.picture + "' WHERE id=" + score.id + ";";

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
        public bool updateAS(top_asist score)
        {
            int e = 0;
            sqlString = "UPDATE top_asist SET name='" + score.name + "', team_id=" + score.team_id + ", asist_count=" + score.asist_count + ", position='" + score.postion + "', picture='" + score.picture + "' WHERE id=" + score.id + ";";

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
        public bool update(Result obj)
        {
            int e = 0;
            sqlString = "UPDATE result SET team_id=" + obj.team_id + ", points=" + obj.points + ", game_count=" + obj.game_count + ", win=" + obj.win + ", lose=" + obj.lose + " WHERE id=" + obj.id + ";";

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
        public DataTable getDataResult()
         {
            DataTable dt = new DataTable();
            sqlString = "SELECT * FROM result;";
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
            foreach (DataRow row in dt.Rows)
            {
                if (row["name"].ToString() == name)
                {
                    id = int.Parse(row["id"].ToString());
                }
            }
            return id;
        }
        public DataTable getDataScorer()
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT * FROM top_scorer;";
            try
            {
                adapter = new SqlDataAdapter(sqlString, conn);
                adapter.Fill(dt);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
        public DataTable getDataAsist()
        {
            DataTable dt = new DataTable();
            sqlString = "SELECT * FROM top_asist;";
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
    public class Result
    {
        public int id;
        public int team_id;
        public int points;
        public int game_count;
        public int win;
        public int lose;
        public Result(int id, int team_id, int points, int game_count, int win, int lose)
        {
            this.id = id;
            this.team_id = team_id;
            this.points = points;
            this.game_count = game_count;
            this.win = win;
            this.lose = lose;
        }
        public Result(int team_id, int points, int game_count, int win, int lose)
        {
            this.team_id = team_id;
            this.points = points;
            this.game_count = game_count;
            this.win = win;
            this.lose = lose;
        }

    }
    public class top_scorer
    {
        public int id;
        public string name;
        public int team_id;
        public int goal_count;
        public string postion;
        public string picture;
        public top_scorer(int id, string name, int team_id, int goal_count, string postion, string picture)
        {
            this.id = id;
            this.name = name;
            this.team_id = team_id;
            this.goal_count = goal_count;
            this.postion = postion;
            this.picture = picture;
        }
        public top_scorer(string name, int team_id, int goal_count, string postion, string picture)
        {
            this.name = name;
            this.team_id = team_id;
            this.goal_count = goal_count;
            this.postion = postion;
            this.picture = picture;
        }

    }
    public class top_asist
    {
        public int id;
        public string name;
        public int team_id;
        public int asist_count;
        public string postion;
        public string picture;
        public top_asist(int id, string name, int team_id, int asist_count, string postion, string picture)
        {
            this.id = id;
            this.name = name;
            this.team_id = team_id;
            this.asist_count = asist_count;
            this.postion = postion;
            this.picture = picture;
        }
        public top_asist(string name, int team_id, int asist_count, string postion, string picture)
        {
            this.name = name;
            this.team_id = team_id;
            this.asist_count = asist_count;
            this.postion = postion;
            this.picture = picture;
        }

    }
}
