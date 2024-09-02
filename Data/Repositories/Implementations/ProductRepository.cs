using ProyectoFacturacion_Practica01_.Data.Repositories.Contracts;
using ProyectoFacturacion_Practica01_.Data.Utils;
using ProyectoFacturacion_Practica01_.Domain;
using System.Data;

namespace ProyectoFacturacion_Practica01_.Data.Repositories.Implementations
  {
  public class ProductRepository : IProductRepository
    {

    private string procedure = string.Empty;
    public bool AddOrUpdateProduct(Product product)
      {
      List<Product> products = GetAll();

      if (products.Contains(product))
        {
        procedure = "SP_UPDATE_PRODUCT";
        var parameters = new List<ParameterSQL>
          {
            new ParameterSQL("@ID", product.Id),
            new ParameterSQL("@NAME", product.Name),
            new ParameterSQL("@PRICE", product.Price),
            new ParameterSQL("@AVAILABLE", product.Available)
          };
        int affectedRows = DataHelper
          .GetInstance()
          .ExecuteSPDML(procedure, parameters);

        return affectedRows > 0;
        }
      else
        {
        procedure = "SP_INSERT_PRODUCT";
        var parameters = new List<ParameterSQL>
            {
            new ParameterSQL("@NAME", product.Name),
            new ParameterSQL("@PRICE", product.Price),
            new ParameterSQL("@AVAILABLE", product.Available),
            };
        int affectedRows = DataHelper
          .GetInstance()
          .ExecuteSPDML(procedure, parameters);

        return affectedRows > 0;
        }

      }

    public bool DeleteProduct(int id)
      {
      var parameters = new List<ParameterSQL> { new ParameterSQL("@ID", id) };
      procedure = "SP_DELETE_PRODUCT";

      int affectedRows = DataHelper
        .GetInstance()
        .ExecuteSPDML(procedure, parameters);

      return affectedRows > 0;
      }

    public List<Product> GetAll()
      {
      List<Product> products = new List<Product>();
      procedure = "SP_SELECT_ALL_PRODUCTS";
      DataTable dt = DataHelper
        .GetInstance()
        .ExecuteSPQuery(procedure, null);

      if (dt != null)
        {
        foreach (DataRow row in dt.Rows)
          {
          Product product = new Product
            {
            Id = (int)row["ID"],
            Name = (string)row["PNAME"],
            Price = (double)row["PRICE"],
            Available = (bool)row["AVAILABLE"]
            };

          products.Add(product);
          }
        }
      return products;
      }

    public List<Product> GetByName(string name)
      {
      var parameters = new List<ParameterSQL> { new ParameterSQL("@NAME", name) };
      procedure = "SP_SELECT_PRODUCT_BY_NAME";
      var products = new List<Product>();

      DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery(procedure, parameters);

      if (dataTable != null)
        {
        foreach (DataRow row in dataTable.Rows)
          {
          Product product = new Product
            {
            Id = (int)row["ID"],
            Name = (string)row["PNAME"],
            Price = (double)row["PRICE"],
            Available = (bool)row["AVAILABLE"]
            };

          products.Add(product);
          }
        }
      return products;
      }
    }
  }
