using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Api_feb_2022.ModelsDto
{
    public class OrderCreateDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<int> Products { set; get; }
    }
}
