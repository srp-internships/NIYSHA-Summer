using System;
using System.Collections.ObjectModel;

namespace WarehouseProject
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
        public ICollection<Sale> Sales { get; set; }
		public ICollection<Receipt> Receipts { get; set; }

		public Product()
		{
			Receipts = new Collection<Receipt>();
            Sales = new Collection<Sale>();

        }
    }
}

