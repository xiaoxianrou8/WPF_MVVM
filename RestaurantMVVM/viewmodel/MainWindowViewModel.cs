using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using RestaurantMVVM.models;
using RestaurantMVVM.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantMVVM.viewmodel
{
    class MainWindowViewModel:NotificationObject
    {
        /// <summary>
        /// 创建Command用于执行方法
        /// </summary>
        public DelegateCommand SelectItemCMD { get; set; }
        public DelegateCommand OrderCMD { get; set; }
        //统计订单数
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value;
                this.RaisePropertyChanged(nameof(Count));
            }
        }
        //餐馆信息
        private Restaurant  restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set { restaurant = value;
                this.RaisePropertyChanged(nameof(Restaurant));
            }
        }
        //菜单列表包含DishViewModel
        private List<DishViewModel> dishMenu;

        public List<DishViewModel> DishMenu
        {
            get { return dishMenu; }
            set { dishMenu = value;
                this.RaisePropertyChanged(nameof(DishMenu));
            }
        }
        public MainWindowViewModel()
        {
            LoadMenu();
            LoadRestaurant();
            SelectItemCMD = new DelegateCommand(new Action(SelectMenuItemExcute));
            OrderCMD = new DelegateCommand(new Action(PlaceOrderCommandExcute));
        }
        //设置餐馆的属性
        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "重庆小面";
            this.Restaurant.Address = "辽中医食堂二楼";
            this.Restaurant.Tel = "1234567890";
        }
        //加载菜单列表
        private void LoadMenu()
        {
            XmlDataService xmlDataService = new XmlDataService();
            //获取Xml中Dish列表
            List<Dish> dishes = xmlDataService.GetDishes();
            this.DishMenu = new List<DishViewModel>();
            foreach (var item in dishes)
            {
                DishViewModel dish = new DishViewModel();
                //添加Dish属性
                dish.Dish = item;
                this.DishMenu.Add(dish);
            }
        }
        //点击预定按钮时
        private void PlaceOrderCommandExcute()
        {
            var selectedDishes = this.DishMenu.Where(i => i.IsChecked == true).Select(i => i.Dish.Name).ToList();
            IOrderService orderService = new SendDataService();
            orderService.OrderSender(selectedDishes);
            MessageBox.Show("订餐成功");
        }
        //checkbox被选中时
        private void SelectMenuItemExcute()
        {
            this.Count = this.DishMenu.Count(i => i.IsChecked == true);
        }

    }
}
