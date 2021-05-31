using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics_Averkin.Business
{
    class Product
    {
        public Product(string product, string сategory, string supplier, string unitprice, string quantityperunit, string unitsinstock, string unitsonorder, string reorderlevel, string discontinued)
        {
            this.product = product;
            this.сategory = сategory;
            this.supplier = supplier;
            this.unitprice = unitprice;
            this.quantityperunit = quantityperunit;
            this.unitsinstock = unitsinstock;
            this.unitsonorder = unitsonorder;
            this.reorderlevel = reorderlevel;
            this.discontinued = discontinued;
        }

        public string product { get; set; }
        public string сategory { get; set; }
        public string supplier { get; set; } 
        public string unitprice { get; set; }
        public string quantityperunit { get; set; }
        public string unitsinstock { get; set; }
        public string unitsonorder { get; set; }
        public string reorderlevel { get; set; }
        public string discontinued { get; set; }

    }
}
