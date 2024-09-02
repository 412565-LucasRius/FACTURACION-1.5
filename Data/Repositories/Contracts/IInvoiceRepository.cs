using ProyectoFacturacion_Practica01_.Domain;

namespace ProyectoFacturacion_Practica01_.Data.Repositories.Contracts
  {
  public interface IInvoiceRepository
    {
    List<Invoice> GetAll();

    bool CreateInvoice(Invoice invoice);

    List<Invoice> GetInvoiceByDate(DateTime dateTime);

    int GetLastInvoiceId();

    }
  }
