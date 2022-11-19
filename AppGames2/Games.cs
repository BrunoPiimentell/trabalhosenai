using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppGames2
{
    class Games
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string desenvolvedora { get; set; }
        public string ano { get; set; }
        public int nota { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\source\repos\AppGames2\DbGames.mdf;Integrated Security=True");

        public List<Games> listagames()
        {
            List<Games> li = new List<Games>();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Jogos", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Games g = new Games();
                g.Id = (int)dr["Id"];
                g.nome = dr["nome"].ToString();
                g.desenvolvedora = dr["desenvolvedora"].ToString();
                g.ano = dr["ano"].ToString();
                g.nota = (int)dr["nota"];
                li.Add(g);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string desenvolvedora, string ano, int nota)
        {
            string sql = "INSERT INTO Jogos(nome,desenvolvedora,ano,nota) VALUES ('" + nome + "','"+ desenvolvedora +"','"+ ano +"','"+ nota +"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Atualizar(int Id,string nome, string desenvolvedora, string ano, int nota)
        {
            string sql = "UPDATE Jogos SET nome='"+ nome +"', desenvolvedora='"+ desenvolvedora +"', ano='"+ ano +"', nota='"+ nota +"' WHERE Id= '"+ Id +"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Jogos Where Id='"+ Id +"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int Id)
        {
            string sql = "SELECT * FROM Jogos WHERE Id='"+ Id +"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                desenvolvedora = dr["desenvolvedora"].ToString();
                ano = dr["ano"].ToString();
                nota = (int)dr["nota"];
            }
            dr.Close();
            con.Close();
        }

        public bool RegistroRepetido(string nome)
        {
            string sql = "SELECT * FROM Jogos Where nome='"+ nome +"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return (int)result > 0;
            }
            con.Close();
            return false;
        }
    }
}
