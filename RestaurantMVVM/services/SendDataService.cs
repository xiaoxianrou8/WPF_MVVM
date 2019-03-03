using RestaurantMVVM.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMVVM.services
{
    class SendDataService : IOrderService
    {
        //存入列表数据
        public void OrderSender(List<string> dishes)
        {
            File.WriteAllLines(@"D:\order.txt",dishes.ToArray());
        }
    }
}
