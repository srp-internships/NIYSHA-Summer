using System;
namespace WarehouseProject
{
	public class Receipt
	{
		public int Id { get; set; }
        public int ProviderId { get; set; }
        public int ProductId  { get; set; }             
        public int Quantity { get; set; }
		public int Price { get; set; }

        public Product Product { get; set; }
        public Provider Provider { get; set; }

    }
}

