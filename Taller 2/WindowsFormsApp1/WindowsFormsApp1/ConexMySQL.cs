using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class ConexMySQL
    {
        private MySqlConnection conexion;

        public ConexMySQL()
        {
            try
            {
                var fileStream = new FileStream("config_file.txt",
                FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream,
                    System.Text.Encoding.UTF8))
                {

                    string line = streamReader.ReadLine();

                    this.conexion = new MySqlConnection(line);

                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Archivo de configuracion no encontrado. \n\n Exception del tipo " + ex.GetType());
            }
        }

        /*
         * Abre el Connector para poder hacerles consultas
         */
        public void open()
        {
            try
            {
                this.conexion.Open();
            }
            catch (MySqlException sqlex)
            {
                MessageBox.Show("Exception del tipo " +sqlex.GetType() + "\n\nError al intentar entrar en la base de datos, revise que los datos esten bien escritos");
            }
        }
        /*
         * Cieran el MySQLConnection
         */
        public void close()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                else
                {
                    MessageBox.Show("Error al intentar desconectar base de datos. \nNo habia nada que cerrar");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error. Base de datos no encontrada. \n\nError del tipo " + e.GetType());
            }
        }

        public MySqlConnection getConexion()
        {
            return this.conexion;
        }

        /*
         * Funcion que devuelve el numero de filas que son afectadas por la query llegada por parametro.
         * Es decir que para que haya sido realizada con exito debe retornar un valor mayor a 0. si devuelve -1 es porque 
         * hubo un error durante la transaccion.
         */
        public int executeNonQuery(string query, params string[] values)
        {

            MySqlTransaction transaccion = null;
            int resultado = 0;

            try
            {
                transaccion = conexion.BeginTransaction();

                using (MySqlCommand comando = new MySqlCommand())
                {
                    comando.Connection = this.conexion;
                    comando.Transaction = transaccion;
                    comando.CommandText = query;

                    //Agregamos los parametros no definidos a la query
                    for (int pos = 0; pos < values.Length; pos += 2)
                    {
                        comando.Parameters.AddWithValue(values[pos], values[pos + 1]);
                    }

                    //Ejecutamos la query                    
                    resultado = comando.ExecuteNonQuery();
                    
                }
                //Finalizamos la transaccion exitosa
                transaccion.Commit();

                //Devolvemos el numero de filas afectadas por la query
                return resultado;
            }
            catch (Exception ex)
            {
                //Rollback de la transacion:
                try
                {
                    transaccion.Rollback();
                    MessageBox.Show("Rollback. " +
                        "\nPosibles causas: \n-Ya existe dicho dato en la BD. \n-Escribio mal los datos de la BD. " +
                        "\n\n Exception del tipo " + ex.GetType());
                }
                catch (Exception e_sql)
                {
                    if (transaccion != null)
                    {
                        MessageBox.Show("Una excepcion del tipo " + e_sql.GetType() + " fue decubierta" +
                            " mientras se ejecutaba el rollback.");

                    }
                }

                MessageBox.Show("Una excepcion del tipo " + ex.GetType() + " fue encontrada durante la ejecucion de la query." +
                    "\nRevise que esten todos los datos, y bien escritos.");
            }

            //No se ejecutó bien
            return -1;

        }

        public string selectQueryScalar(string query, params string[] values)
        {

            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.Connection = this.conexion;
                cmd.CommandText = query;

                for (int pos = 0; pos < values.Length; pos += 2)
                {
                    cmd.Parameters.AddWithValue(values[pos], values[pos + 1]);
                }

                /**
                 * No se necesita cerrar ni cláusula using,
                 * por que una vez que rescata valor, se cierra automáticamente
                 */
                return cmd.ExecuteScalar().ToString();
            }
        }

        public DataTable selectQuery(string query, params string[] values)
        {

            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.Connection = this.conexion;
                cmd.CommandText = query;

                for (int pos = 0; pos < values.Length; pos += 2)
                {
                    cmd.Parameters.AddWithValue(values[pos], values[pos + 1]);
                }

                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                return dt;

            }

        }
    }
}
