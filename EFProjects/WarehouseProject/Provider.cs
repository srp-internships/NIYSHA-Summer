using System;
using System.Collections.ObjectModel;

namespace WarehouseProject
{
	public class Provider
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Receipt> Receipts { get; set; }

        public Provider()
        {
            Receipts = new Collection<Receipt>();
        }   
    }
}

