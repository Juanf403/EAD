using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicoV2
{
        public static class Conexion
        {
            public static string query, nombreTabla, columna, conexionString;
            public static string estado = "1";
            public static List<int> datos;
            public static DataTable dt;
            //public Conexion() { }
            //public Conexion(string ConexionString,string NombreTabla)
            //{
            //    this.conexionString = ConexionString;
            //    this.nombreTabla = NombreTabla;
            //   // this.NombresColumna = new List<string>(NombresColumna); 
            //    estado = 1;
            //    datos = new List<int>();
            //}

            public static DataTable TraerTodosDatosDeBD()//Manda todos los datos de la tabla a el datagrid
            {
                //aqui esta la conexion a la base de datos
                query = String.Format(query, nombreTabla);
                OleDbConnection conexion = new OleDbConnection(conexionString);
                dt = new DataTable();
                //DataSet ds = new DataSet();
                try//codigo para la conexion
                {
                    conexion.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = conexion;
                    command.CommandText = query;
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    da.Fill(dt);
                    conexion.Close();


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;//regresa la tabla en un data table

            }

            //public static string ConsultarEstado(string columna, string estado2)
            //{
            //    DataRow x = dt.Rows.Find(estado2);
            //    estado = x[columna].ToString();
            //    return estado;

            //}
            //public static string TraerEstadoDeBD(string columna, string estado2)//mandar el dato de un celda especifica 
            //{
            //    string query = String.Format("select [{2}] from [{0}] where(ESTADO='{1}')", nombreTabla, estado2, columna);//trae el nuevo estado de la tabla 
            //    OleDbConnection conexion = new OleDbConnection(conexionString);
            //    try//codigo para la conexion a la BD
            //    {
            //        conexion.Open();
            //        OleDbCommand command = new OleDbCommand();
            //        command.Connection = conexion;
            //        command.CommandText = query;
            //        OleDbDataAdapter da = new OleDbDataAdapter(command);
            //        // DataSet ds = new DataSet();
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);

            //        foreach (DataRow row in dt.Rows)//SE OPTIENE EL ESTADO DE LA TABLA
            //        {
            //            estado = row[0].ToString();//lo pasa el estado obtenido a una variable que se llama estado 
            //        }
            //        conexion.Close(); //cierra la conexion
            //        return "OK";//si todo esta bien manda un ok
            //    }
            //    catch (Exception ex)
            //    {
            //        return ex.Message;
            //    }

            //}


        }
    }

