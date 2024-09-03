using ProyectoFacturacion_Practica01_.Data.Repositories.Contracts;
using ProyectoFacturacion_Practica01_.Data.Repositories.Implementations;
using ProyectoFacturacion_Practica01_.Domain;

namespace ProyectoFacturacion_Practica01_.Services
  {
  public class ProductManager
    {
    private IProductRepository _repository;

    public ProductManager()
      {
      _repository = new ProductRepository();
      }

    public List<Product> GetProducts()
      {
      return _repository.GetAll();
      }

    public List<Product> GetProductsByName(string name)
      {
      return _repository.GetByName(name);
      }

    public bool CreateOrUpdateProduct(Product product)
      {
      return _repository.AddOrUpdateProduct(product);
      }

    public bool DeleteProduct(Product product)
      {
      return _repository.DeleteProduct(product);
      }
    }
  }
