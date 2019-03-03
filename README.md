# WPF_MVVM
刘铁猛——深入浅出WPF之mvvm
---
## Prism实现mvvm
### 1. 引入Nuget包：PrismMVVMLibrary
### 2. 实现ViewModel的属性界面更新引入：
```csharp
 using Microsoft.Practices.Prism.ViewModel;
 //实现属性的界面更新
 this.RaisePropertyChanged(nameof(Count));
  ```
  ### 3. 实现委托命令
  ```csharp
  using Microsoft.Practices.Prism.Commands;
  //声明命令属性
  public DelegateCommand SelectCMD{get;set;}
  //命令处理方法
  private void IsCheckedExcute()
  {..... }
  //指定委托方法，在构造函数中
  this.SelectCMD=new DelegateCommand(new Action(IsCheckedExcute));
