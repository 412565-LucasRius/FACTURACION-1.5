using ProyectoFacturacion_Practica01_.Domain;

namespace ProyectoFacturacion_Practica01_.Data.Repositories.Contracts
  {
  public interface IProductRepository
    {
    List<Product> GetAll();

    List<Product> GetByName(string name);

    bool AddOrUpdateProduct(Product product);

    bool DeleteProduct(Product product);
    }
  }
