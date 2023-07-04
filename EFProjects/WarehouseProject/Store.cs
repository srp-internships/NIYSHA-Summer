using System;
using System.Collections.ObjectModel;
namespace WarehouseProject
{
	public class Store
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public ICollection<Sale> Sales { get; set; }

		public Store()
		{
			Sales = new Collection<Sale>();
		}
	}
}

