using REST_Api_feb_2022.Models;
using REST_Api_feb_2022.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Api_feb_2022.Data
{
    public class Mapper
    {
        public Order Map(OrderCreateDto input)
        {
            return new Order { 
                Name = input.Name,
                Date = input.Date
            };
        }
        public OrderReadDto Map(Order input)
        {
            return new OrderReadDto { 
                Id = input.Id,
                Name = input.Name,
                Date = input.Date
            };
        }

        public ProductReadDto Map(Product input, bool flag)
        {
            return new ProductReadDto
            {
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }
        public ProductCreateDto Map(Product input)
        {
            return new ProductCreateDto
            {
                Name = input.Name,
                Price = input.Price
            };
        }

        public Product Map(ProductCreateDto input)
        {
            return new Product
            {
                Name = input.Name,
                Price = input.Price
            };
        }
    }
}
