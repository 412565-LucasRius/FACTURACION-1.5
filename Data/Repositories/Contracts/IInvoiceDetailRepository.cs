using ProyectoFacturacion_Practica01_.Domain;

namespace ProyectoFacturacion_Practica01_.Data.Repositories.Contracts
  {
  public interface IInvoiceDetailRepository
    {

    List<InvoiceDetail> GetInvoiceDetailsFromInvoice(int id);
    }
  }
