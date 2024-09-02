using ProyectoFacturacion_Practica01_.Data.Repositories.Implementations;
using ProyectoFacturacion_Practica01_.Domain;


Product product1 = new Product
  {
  Id = 1,
  };

InvoiceDetail invoiceDetail1 = new InvoiceDetail
  {
  Product = product1,
  Quantity = 1,
  };

Product product2 = new Product
  {
  Id = 2,
  };

InvoiceDetail invoiceDetail2 = new InvoiceDetail
  {
  Product = product2,
  Quantity = 3,
  };

Invoice invoice = new Invoice
  {
  ClientName = "Lucas",
  Details =
    {
    invoiceDetail1, invoiceDetail2
    },
  PaymentMethod = PaymentMethod.Cash
  };

InvoiceRepository ir = new InvoiceRepository();


Console.WriteLine(ir.CreateInvoice(invoice));
