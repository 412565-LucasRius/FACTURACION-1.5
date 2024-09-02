using ProyectoFacturacion_Practica01_.Domain;

namespace ProyectoFacturacion_Practica01_.Data.Repositories.Contracts
  {
  public interface IInvoiceDetailRepository
    {
    bool CreateInvoiceDetail(InvoiceDetail invoiceDetail);

    List<InvoiceDetail> GetInvoiceDetailsFromInvoice(int id);
    }
  }
