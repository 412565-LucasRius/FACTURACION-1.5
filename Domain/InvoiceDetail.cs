namespace ProyectoFacturacion_Practica01_.Domain
  {
  public class InvoiceDetail
    {
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public Product Product { get; set; }

    public int Quantity { get; set; }

    public double SubTotal()
      {
      return Quantity * Product.Price;
      }

    }
  }
