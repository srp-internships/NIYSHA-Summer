using System.Threading;
using WarehouseProject;
using WarehouseProject.Data;

var context = new DataContext();

//Insert data into Receipt
//var receipt = new Receipt
// {
//      ProductId = 1,
//      ProviderId = 2,
//      Price = 300,
//      Quantity = 5
//  };
//context.Receipts.Add(receipt);


//Insert data into Sale;
//var sales = new Sale
//{
//    ProductId = 1,
//    StoreId = 1,
//    Price = 80,
//    Quantity = 10
//};
//context.Sales.Add(sales);


//Updating price from Sales:
//var sale = context.Sales.Find(1);
//sale.Price = 70;

//Deleting date from Store
//var store = context.Stores.Find(4);
//context.Stores.Remove(store);


//context.SaveChanges();


//TotalPriceOfProducts
//int list = context.Receipts.Sum(e => e.Price);
//Console.WriteLine($"Sum of receipt products are: {list}");


static void UpdateQuantityAfterReceipt()
{
    using (var context = new DataContext())
    {

        var receipts = context.Receipts.ToList();
        var products = context.Products.ToList();


        var updatedProducts = from receipt in receipts
                              join product in products on receipt.ProductId equals product.Id

                              select new Product
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  Quantity = product.Quantity + receipt.Quantity,

                              };
        foreach (var updatedProduct in updatedProducts)
        {
            Console.WriteLine($"After Receipt Total Quantity of {updatedProduct.Name} is {updatedProduct.Quantity}");

            var q = context.Products.Find(updatedProduct.Id);
            q.Quantity = updatedProduct.Quantity;
            context.SaveChanges();
        }

    }

}

//UpdateQuantityAfterReceipt();

static void UpdateQuantityAfterSale()
{
    using (var context = new DataContext())
    {

        var products = context.Products.ToList();
        var sales = context.Sales.ToList();
        var quantityaproduct = from sale in sales

                               join product in products on sale.ProductId equals product.Id

                               select new Product
                               {
                                   Id = product.Id,
                                   Name = product.Name,
                                   Quantity = product.Quantity - sale.Quantity,

                               };
        foreach (var updatedProduct in quantityaproduct)
        {
            Console.WriteLine($"After Sale Total Quantity of {updatedProduct.Name} is {updatedProduct.Quantity}");
            var q = context.Products.Find(updatedProduct.Id);
            q.Quantity = updatedProduct.Quantity;
            context.SaveChanges();
        }
        context.SaveChanges();
    }
}

//UpdateQuantityAfterSale();


static void ReceiptsOfProviders()
{
    using (var context = new DataContext())
    {

        var query =
            from r in context.Providers
            join rc in context.Receipts on r.Id equals rc.ProviderId into p
            select new { ProviderName = r.Name, Receipts = p.Count() };

        foreach (var rc in query)
        {
            Console.WriteLine("{0} ({1})", rc.ProviderName, rc.Receipts);
        }
    }
}

//  ReceiptsOfProviders();


static void SumOfProvidersPrice()
{
    using (var context = new DataContext())
    {
        var query = context.Receipts
       .GroupBy(p => p.ProviderId)
       .Select(g => new { ProviderId = g.Key, TotalSumOfProducts = g.Sum(p => p.Price) });

        foreach (var rc in query)
        {
            Console.WriteLine("{0} ({1})", rc.ProviderId, rc.TotalSumOfProducts);
        }
    }

}
//SumOfProviderPrice();



Console.ReadKey();