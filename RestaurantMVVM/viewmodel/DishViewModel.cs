using Microsoft.Practices.Prism.ViewModel;
using RestaurantMVVM.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RestaurantMVVM.viewmodel
{
    class DishViewModel:NotificationObject
    {
        public Dish Dish { get; set; }
        //标记Dish是否被选中
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value;
                this.RaisePropertyChanged(nameof(IsChecked));
            }
        }

    }
}
