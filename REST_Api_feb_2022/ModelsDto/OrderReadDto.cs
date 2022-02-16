using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Api_feb_2022.ModelsDto
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<ProductReadDto> Products { set; get; }
    }
}
