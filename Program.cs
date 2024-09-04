using ProyectoFacturacion_Practica01_.Domain;
using ProyectoFacturacion_Practica01_.Services;

#region Invoice Management
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

Console.WriteLine($"CLIENT: {invoice.ClientName}");

Console.WriteLine($"PRODUCTS: ");
foreach (var detail in invoice.Details)
  {
  Console.WriteLine($"ID: {detail.Id}");
  Console.WriteLine($"DATE: {detail.Product.Name}");
  Console.WriteLine($"CLIENT: {detail.Quantity}");
  Console.WriteLine($"PAYMENT METHOD: {detail.Product.Price}");
  Console.WriteLine($"SUBTOTAL: {detail.SubTotal()}");
  }


Console.WriteLine(@"
METODO DE PAGO:
- 1: EFECTIVO
- 2: TARJETA DE CREDITO
- 3: TARJETA DE DEBITO
");

int paymentMethodReadLine = Convert.ToInt32(Console.ReadLine());
int paymentMethod;

while (paymentMethodReadLine == 0)
  {
  Console.WriteLine(@"
Ingrese un metodo de pago valido: 
- 1: EFECTIVO
- 2: TARJETA DE CREDITO
- 3: TARJETA DE DEBITO
");
  paymentMethodReadLine = Convert.ToInt32(Console.ReadLine());

  }
switch (paymentMethodReadLine)
  {
  case 1:
    paymentMethod = 1;
    break;
  case 2:
    paymentMethod = 2;
    break;
  case 3:
    paymentMethod = 3;
    break;
  default:
    paymentMethod = 1;
    break;
  }

invoice.PaymentMethod = paymentMethod;
if (paymentMethod == 1)
  {
  Console.WriteLine("METODO DE PAGO ELEGIDO: EFECTIVO");
  }
else if (paymentMethod == 2)
  {
  Console.WriteLine("METODO DE PAGO ELEGIDO: TARJETA DE CREDITO");
  }
else
  {
  Console.WriteLine("METODO DE PAGO ELEGIDO: TARJETA DE DEBITO");
  }



invoice.AddDetail(invoiceDetail1);
invoice.AddDetail(invoiceDetail2);
invoice.AddDetail(invoiceDetail3);
invoice.AddDetail(invoiceDetail4);

SellingServices sellManager = new SellingServices();

bool result = sellManager.CreateInvoice(invoice);

if (result)
  {
  Console.WriteLine("Factura agregada correctamente.");
  }
else
  {
  Console.WriteLine("Hubo un error al agregar la factura. Transaccion cancelada.");
  }

Console.ReadKey();

int day = 0;
while (day < 1 || day > 31)
  {
  Console.WriteLine("Ingrese el dia de las facturas");
  day = Convert.ToInt32(Console.ReadLine());
  }

List<Invoice> invoicesByDate = sellManager.GetInvoicesByDate(day);

foreach (var i in invoicesByDate)
  {
  Console.WriteLine($"ID: {i.Id} -----------------");
  Console.WriteLine($"DATE: {i.Date}");
  Console.WriteLine($"CLIENT: {i.ClientName}");
  Console.WriteLine($"PAYMENT METHOD: {i.PaymentMethod}");
  }
#endregion

#region Product Management

//ProductManager pm = new ProductManager();

//List<Product> allProducts = pm.GetProducts();
//Console.WriteLine("Lista de productos: ");
//foreach (Product product in allProducts)
//  {
//  Console.WriteLine("----------------------------");
//  Console.WriteLine($"ID: {product.Id}");
//  Console.WriteLine($"PRODUCT: {product.Name}");
//  Console.WriteLine($"PRICE: {product.Price}");
//  Console.WriteLine($"AVAILABLE: {product.Available}");
//  Console.WriteLine("----------------------------");
//  }

//Console.WriteLine("Inserte el nombre del producto que quiere buscar.");

//string productName = Console.ReadLine();

//while (productName == string.Empty)
//  {
//  Console.WriteLine("Nombre invalido, por favor inserte un producto valido.");
//  productName = Console.ReadLine();
//  }
//if (productName != null)
//  {
//  List<Product> productByName = pm.GetProductsByName(productName);
//  foreach (Product product in productByName)
//    {
//    Console.WriteLine("----------------------------");
//    Console.WriteLine($"ID: {product.Id}");
//    Console.WriteLine($"PRODUCT: {product.Name}");
//    Console.WriteLine($"PRICE: {product.Price}");
//    Console.WriteLine($"AVAILABLE: {product.Available}");
//    Console.WriteLine("----------------------------");
//    }
//  }


#endregion