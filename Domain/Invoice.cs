namespace ProyectoFacturacion_Practica01_.Domain
  {
  public class Invoice
    {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int PaymentMethod { get; set; }

    public string ClientName { get; set; }

    public List<InvoiceDetail> Details { get; set; }

    public Invoice()
      {
      Details = new List<InvoiceDetail>();
      }

    public void AddDetail(InvoiceDetail detail)
      {
      Details.Add(detail);
      }

    public void DeleteDetail(int index)
      {
      Details.RemoveAt(index);
      }



    }
  }
