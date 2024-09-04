using ProyectoFacturacion_Practica01_.Data.Repositories.Contracts;
using ProyectoFacturacion_Practica01_.Data.Utils;
using ProyectoFacturacion_Practica01_.Domain;
using System.Data;

namespace ProyectoFacturacion_Practica01_.Data.Repositories.Implementations
  {
  public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
    public List<InvoiceDetail> GetInvoiceDetailsFromInvoice(int id)
      {

      var parameters = new List<ParameterSQL> { new ParameterSQL("@INVOICE_ID", id) };
      string procedure = "SP_SELECT_INVOICE_DETAIL_FROM_INVOICE";
      var invoiceDetails = new List<InvoiceDetail>();

      DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery(procedure, parameters);

      if (dataTable != null)
        {
        foreach (DataRow row in dataTable.Rows)
          {
          InvoiceDetail invoiceDetail = new InvoiceDetail
            {
            Id = (int)row["ID"],
            Quantity = (int)row["QUANTITY"],
            //Product = (int)row,
            };

          invoiceDetails.Add(invoiceDetail);
          }
        }
      return invoiceDetails;

      }
    }
  }
