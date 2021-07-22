using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;

namespace EscolaParticular.Models
{
    public class NotaAlunoRepository
    {
        public const string strConexao = "Database=EscolaParticular;Data Source=localhost;User ID=root;";
        public void Insert(NotaAluno notaAtual)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();
            string sql = "INSERT INTO NotaAluno(Materia, Nota, IdAluno) VALUES (@Materia, @Nota, @IdAluno)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Materia", notaAtual.Materia);
            comando.Parameters.AddWithValue("@Nota", notaAtual.Nota);
            comando.Parameters.AddWithValue("@IdAluno", notaAtual.IdAluno);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<NotaAluno> Query(int? id)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();
            string sql = "SELECT * FROM NotaAluno WHERE idAluno= @Id";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<NotaAluno> lista = new List<NotaAluno>();
            while (reader.Read())
            {
                NotaAluno na = new NotaAluno();
                na.Id = reader.GetInt32("Id");

                if (!reader.IsDBNull(reader.GetOrdinal("Materia")))
                    na.Materia = reader.GetString("Materia");

                if (!reader.IsDBNull(reader.GetOrdinal("Nota")))
                    na.Nota = reader.GetDouble("Nota");

                lista.Add(na);
            }
            conexao.Close();
            return lista;
        }

        public void Update(NotaAluno una)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();

            string sqlUpdate =
              "UPDATE NotaAluno SET Materia = @Materia, Nota = @Nota, IdAluno = @IdAluno WHERE id= @Id";

            MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);
            comando.Parameters.AddWithValue("@Materia", una.Materia);
            comando.Parameters.AddWithValue("@Nota", una.Nota);
            comando.Parameters.AddWithValue("@IdAluno", una.IdAluno);
            comando.Parameters.AddWithValue("@Id", una.Id);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();

            string sqlDelete =
                "DELETE FROM NotaAluno WHERE id= @Id";

            MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}