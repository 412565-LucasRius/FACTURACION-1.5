using ProyectoFacturacion_Practica01_.Properties;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFacturacion_Practica01_.Data.Utils
  {
  public class DataHelper
    {
    private static DataHelper _instance;
    private SqlConnection _connection;
    private SqlTransaction _transaction;

    private DataHelper()
      {
      _connection = new SqlConnection(Resources.CnnString);
      }

    public static DataHelper GetInstance()
      {
      if (_instance == null)
        _instance = new DataHelper();

      return _instance;

      }

    public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parameters)
      {
      DataTable dt = new DataTable();
      SqlCommand cmd = null;

      try
        {
        _connection.Open();
        cmd = new SqlCommand(sp, _connection);
        cmd.CommandType = CommandType.StoredProcedure;

        if (parameters != null)
          {
          foreach (var param in parameters)
            {
            cmd.Parameters.AddWithValue(param.Name, param.Value);
            }
          }
        dt.Load(cmd.ExecuteReader());
        }
      catch (SqlException ex)
        {
        dt = null;
        }
      finally
        {
        if (_connection.State == ConnectionState.Open)
          {
          _connection.Close();
          }
        }

      return dt;
      }

    public int ExecuteSPDML(string sp, List<ParameterSQL>? parameters)
      {
      int rows;
      try
        {
        _connection.Open();
        var cmd = new SqlCommand(sp, _connection);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        if (parameters != null)
          {
          foreach (var param in parameters)
            cmd.Parameters.AddWithValue(param.Name, param.Value);
          }

        rows = cmd.ExecuteNonQuery();
        _connection.Close();
        }
      catch (SqlException)
        {
        rows = 0;
        }
      finally
        {
        if (_connection.State == System.Data.ConnectionState.Open)
          {
          _connection.Close();
          }
        }

      return rows;
      }

    public int ExecuteSPDMLTransaction(string sp1, string sp2, List<ParameterSQL> parameters, List<ParameterSQL> detailParameters)
      {
      int rows = 0;

      try
        {

        _connection.Open();
        _transaction = _connection.BeginTransaction();

        var command = new SqlCommand(sp1, _connection, _transaction);
        command.CommandType = CommandType.StoredProcedure;
        if (parameters != null)
          {
          foreach (var p in parameters)
            {
            command.Parameters.AddWithValue(p.Name, p.Value);
            }
          SqlParameter parameter = new SqlParameter("@ID", SqlDbType.Int);
          parameter.Direction = ParameterDirection.Output;
          command.Parameters.Add(parameter);
          }
        rows = command.ExecuteNonQuery();

        int invoiceId = (int)command.Parameters[2].Value;

        var detailCmd = new SqlCommand(sp2, _connection, _transaction);


        detailCmd.Parameters.AddWithValue("@INVOICE_ID", invoiceId);
        foreach (var dp in detailParameters)
          {

          Console.WriteLine(dp.Name, dp.Value);
          detailCmd.CommandType = CommandType.StoredProcedure;
          detailCmd.Parameters.AddWithValue(dp.Name, dp.Value);

          }
        rows += detailCmd.ExecuteNonQuery();
        Console.WriteLine("");

        _transaction.Commit();
        }
      catch (SqlException ex)
        {
        _transaction.Rollback();
        rows = 0;
        Console.WriteLine(ex.Message);
        }
      finally
        {
        if (_connection != null && _connection.State == ConnectionState.Open)
          {
          _connection.Close();
          }
        }

      return rows;
      }

    }
  }
