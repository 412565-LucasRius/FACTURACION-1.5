using ProyectoFacturacion_Practica01_.Data.Repositories.Contracts;
using ProyectoFacturacion_Practica01_.Data.Repositories.Implementations;
using ProyectoFacturacion_Practica01_.Domain;

namespace ProyectoFacturacion_Practica01_.Services
  {
  public class SellingServices
    {
    private IInvoiceRepository _invoiceRepository;

    public SellingServices()
      {
      _invoiceRepository = new InvoiceRepository();
      }

    public List<Invoice> GetAll()
      {
      return _invoiceRepository.GetAll();
      }

    public bool CreateInvoice(Invoice invoice)
      {
      return _invoiceRepository.CreateInvoice(invoice);
      }

    public List<Invoice> GetInvoicesByDate(int day)
      {
      return _invoiceRepository.GetInvoiceByDate(day);
      }
    }
  }
