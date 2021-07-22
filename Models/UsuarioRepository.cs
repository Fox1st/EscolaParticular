using System;
using System.Collections.Generic;
using MySqlConnector;

namespace EscolaParticular.Models
{
    public class UsuarioRepository
    {
        public const string strConexao = "Database=EscolaParticular;Data Source=localhost;User ID=root;";
        public Usuario QueryLogin(Usuario ur)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();
            string sql = "SELECT * FROM Usuario WHERE Login = @Login AND Senha = @Senha";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@Login", ur.Login);
            comandoQuery.Parameters.AddWithValue("@Senha", ur.Senha);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Usuario usr = null;

            if(reader.Read())
            {
                usr = new Usuario();
                usr.Id = reader.GetInt32("Id");
                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    usr.Nome = reader.GetString("Nome");
                if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                    usr.Login = reader.GetString("Login");
                if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    usr.Senha = reader.GetString("Senha");
                if (!reader.IsDBNull(reader.GetOrdinal("TipoUsuario")))
                    usr.TipoUsuario = reader.GetString("TipoUsuario");
            }

            conexao.Close();
            return usr;
        } 

        public void Insert(Usuario novoUsuario)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();
            string sql = "INSERT INTO Usuario(Nome, Login, Senha, TipoUsuario) VALUES (@Nome, @Login, @Senha, @TipoUsuario)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", novoUsuario.Nome);
            comando.Parameters.AddWithValue("@Login", novoUsuario.Login);
            comando.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
            comando.Parameters.AddWithValue("@TipoUsuario", novoUsuario.TipoUsuario);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Usuario> Query(string tipo)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();
            string sql = "SELECT * FROM Usuario WHERE TipoUsuario= @TipoUsuario";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@TipoUsuario", tipo);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
            while (reader.Read())
            {
                Usuario usr = new Usuario();
                usr.Id = reader.GetInt32("Id");
                if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    usr.Nome = reader.GetString("Nome");
                if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                    usr.Login = reader.GetString("Login");
                if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    usr.Senha = reader.GetString("Senha");
                if (!reader.IsDBNull(reader.GetOrdinal("TipoUsuario")))
                    usr.TipoUsuario = reader.GetString("TipoUsuario");

                lista.Add(usr);
            }
            conexao.Close();
            return lista;
        }

        public void Update(Usuario upusr)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();

            string sqlUpdate =
              "UPDATE Usuario SET Nome = @Nome, Login = @Login, Senha = @Senha, TipoUsuario = @TipoUsuario WHERE id= @Id";

            MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);
            comando.Parameters.AddWithValue("@Nome", upusr.Nome);
            comando.Parameters.AddWithValue("@Login", upusr.Login);
            comando.Parameters.AddWithValue("@Senha", upusr.Senha);
            comando.Parameters.AddWithValue("@TipoUsuario", upusr.TipoUsuario);
            comando.Parameters.AddWithValue("@Id", upusr.Id);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strConexao);
            conexao.Open();

            string sqlDelete =
                "DELETE FROM Usuario WHERE id= @Id";

            MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteNonQuery();

            conexao.Close();
        }   
    }
}