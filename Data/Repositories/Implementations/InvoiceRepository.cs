using ProyectoFacturacion_Practica01_.Data.Repositories.Contracts;
using ProyectoFacturacion_Practica01_.Data.Utils;
using ProyectoFacturacion_Practica01_.Domain;
using System.Data;

namespace ProyectoFacturacion_Practica01_.Data.Repositories.Implementations
  {
  public class InvoiceRepository : IInvoiceRepository
    {
    private string procedure = String.Empty;
    private string procedure2 = string.Empty;
    public bool CreateInvoice(Invoice invoice)
      {
      int rowsAffected;
      procedure = "SP_INSERT_INVOICE";
      procedure2 = "SP_INSERT_INVOICE_DETAIL";

      var parameters = new List<ParameterSQL>
          {
            new ParameterSQL("@CLIENT", invoice.ClientName),
            new ParameterSQL("@PAYMENT_METHOD", 1)
          };

      Dictionary<InvoiceDetail, List<ParameterSQL>> map = new Dictionary<InvoiceDetail, List<ParameterSQL>>();
      var detailParameters = new List<ParameterSQL>();
      foreach (InvoiceDetail invoiceDetail in invoice.Details)
        {
        detailParameters = new List<ParameterSQL>
          {
          new ParameterSQL("@PRODUCT_ID", invoiceDetail.Product.Id),
          new ParameterSQL("@QUANTITY", invoiceDetail.Quantity)
          };

        map.Add(invoiceDetail, detailParameters);

        }

      rowsAffected = DataHelper.GetInstance()
        .ExecuteSPDMLTransaction(procedure, procedure2, parameters, map);

      return rowsAffected > 0;
      }

    public List<Invoice> GetAll()
      {
      List<Invoice> invoices = new List<Invoice>();
      procedure = "SP_SELECT_ALL_INVOICES";
      DataTable dataTable = DataHelper
        .GetInstance()
        .ExecuteSPQuery(procedure, null);

      foreach (DataRow row in dataTable.Rows)
        {
        Invoice invoice = new Invoice
          {
          Id = (int)row["ID"],
          Date = (DateTime)row["PAYDAY"],
          PaymentMethod = (PaymentMethod)row["PAYMENT_METHOD"],
          ClientName = (string)row["CLIENT"]
          };
        }

      return invoices;
      }

    public List<Invoice> GetInvoiceByDate(int day)
      {
      List<Invoice> invoices = new List<Invoice>();
      var parameters = new List<ParameterSQL> { new ParameterSQL("@DAY", day) };
      procedure = "SP_SELECT_INVOICE_BY_DATE";

      DataTable dataTable = DataHelper
        .GetInstance()
        .ExecuteSPQuery(procedure, parameters);

      if (dataTable.Rows.Count > 0)
        {

        foreach (DataRow row in dataTable.Rows)
          {
          Invoice invoice = new Invoice
            {
            Id = (int)row["ID"],
            Date = (DateTime)row["PAYDAY"],
            PaymentMethod = (PaymentMethod)row["PAYMENT_METHOD"],
            ClientName = (string)row["CLIENT"]
            };

          invoices.Add(invoice);
          }
        }
      return invoices;
      }
    }
  }
