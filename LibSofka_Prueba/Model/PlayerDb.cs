using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSofka_Prueba.Clases;
using System.Data.SqlClient;
using System.Data;
namespace LibSofka_Prueba.Model
{
    public class PlayerDb
    {
        public Player Login(User user)
        {

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-ARB9P2N;Initial Catalog=sofka_juego"))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT pl.id,pl.nombre,pl.fecha_nacimiento, pl.max_points FROM usuario AS us " +
                    " INNER JOIN player AS pl " +
                    " ON pl.usuario_id = us.id " +
                    " WHERE us.user_text = @user AND us.password_name = @password";
                command.Parameters.Add("@user", SqlDbType.NVarChar);
                command.Parameters["@user"].Value = user.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar);
                command.Parameters["@password"].Value = user.Password;
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine(reader["id"].ToString());
                if (reader.NextResult())
                {
                    return new Player(int.Parse(reader["id"].ToString()), reader["nombre"].ToString(), DateTime.Parse(reader["fecha_nacimiento"].ToString()), int.Parse(reader["max_points"].ToString()));
                }
                connection.Close();
            }
            
            return null;
        }
    }
}
