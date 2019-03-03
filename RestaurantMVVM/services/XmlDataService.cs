using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RestaurantMVVM.models;

namespace RestaurantMVVM.services
{
    class XmlDataService : IDataService
    {
        public List<Dish> GetDishes()
        {
            List<Dish> dishes = new List<Dish>();
            //生成文件路径
            string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, path2: @"Data/DataDishs.xml");
            XDocument xDoc = XDocument.Load(xmlFileName);
            //返回Dish的列表
            var dishesL = xDoc.Descendants("Dish");
            //将数据填入list中
            foreach (var item in dishesL)
            {
                Dish dish = new Dish();
                dish.Name = item.Element("DishName").Value;
                dish.Categroy = item.Element("Categroy").Value;
                dish.Evaluate = item.Element("Evaluate").Value;
                dish.Score = double.Parse(item.Element("Score").Value);
                dishes.Add(dish);
            }
            return dishes;
        } 
    }
}
