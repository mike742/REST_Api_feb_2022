using REST_Api_feb_2022.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Api_feb_2022.Data.Intefases
{
    public interface IOrderRepo
    {
        IEnumerable<OrderReadDto> GetAll();
        void Create(OrderCreateDto input);
    }
}
