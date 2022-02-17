using REST_Api_feb_2022.Data.Intefases;
using REST_Api_feb_2022.Models;
using REST_Api_feb_2022.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Api_feb_2022.Data
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper = new Mapper();

        public OrderRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(OrderCreateDto input)
        {
            Order orderToAdd = _mapper.Map(input);
            _context.Orders.Add(orderToAdd);
            _context.SaveChanges();

            foreach (int id in input.Products)
            {
                var op = new OrderProducts { 
                    OrderId = orderToAdd.Id,
                    ProductId = id
                };
                _context.OrderProducts.Add(op);
            }
            _context.SaveChanges();
        }

        public IEnumerable<OrderReadDto> GetAll()
        {
            var orders = _context.Orders
                .Select(o => _mapper.Map(o))
                .ToList();
            var products = _context.Products
                .Select(p => _mapper.Map(p, true))
                .ToList();
            var orderProducts = _context.OrderProducts.ToList();

            foreach(var order in orders)
            {
                List<ProductReadDto> productsToAdd = new List<ProductReadDto>();

                foreach (var op in orderProducts)
                {
                    if (op.OrderId == order.Id)
                    {
                        var prod = products.FirstOrDefault(p => p.Id == op.ProductId );

                        if (prod != null)
                        {
                            productsToAdd.Add(prod);
                        }
                    }
                }
                order.Products = productsToAdd;
            }

            return orders;
        }
    }
}
