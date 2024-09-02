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

Product product3 = new Product
  {
  Id = 4,
  };

InvoiceDetail invoiceDetail3 = new InvoiceDetail
  {
  Product = product3,
  Quantity = 10,
  };

Product product4 = new Product
  {
  Id = 3,
  };

InvoiceDetail invoiceDetail4 = new InvoiceDetail
  {
  Product = product4,
  Quantity = 2,
  };

Invoice invoice = new Invoice
  {
  ClientName = "Lucas",
  };

Console.WriteLine(@"
METODO DE PAGO:
- 1: EFECTIVO
- 2: TARJETA DE CREDITO
- 3: TARJETA DE DEBITO
");

string paymentMethodReadLine = Console.ReadLine();
PaymentMethod paymentMethod;

while (paymentMethodReadLine == string.Empty)
  {
  Console.WriteLine(@"
Ingrese un metodo de pago valido: 
- 1: EFECTIVO
- 2: TARJETA DE CREDITO
- 3: TARJETA DE DEBITO
");
  paymentMethodReadLine = Console.ReadLine();

  }
switch (paymentMethodReadLine)
  {
  case "1":
    paymentMethod = PaymentMethod.Cash;
    break;
  case "2":
    paymentMethod = PaymentMethod.Credit;
    break;
  case "3":
    paymentMethod = PaymentMethod.Debit;
    break;
  default:
    paymentMethod = PaymentMethod.Cash;
    break;
  }


invoice.PaymentMethod = paymentMethod;
invoice.AddDetail(invoiceDetail1);
invoice.AddDetail(invoiceDetail2);
invoice.AddDetail(invoiceDetail3);
invoice.AddDetail(invoiceDetail4);

InvoiceRepository ir = new InvoiceRepository();

Console.WriteLine(ir.CreateInvoice(invoice));
int day = 0;
while (day < 1 || day > 31)
  {
  Console.WriteLine("Ingrese el dia de las facturas");
  day = Convert.ToInt32(Console.ReadLine());
  }

List<Invoice> invoicesByDate = ir.GetInvoiceByDate(day);

foreach (var i in invoicesByDate)
  {
  Console.WriteLine($"ID: {i.Id} -----------------");
  Console.WriteLine(i.Date);
  Console.WriteLine(i.ClientName);
  Console.WriteLine(i.PaymentMethod);
  }
