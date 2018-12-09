using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfDemo
{
    /// <summary>
    /// MyDependencyProperty.xaml 的交互逻辑
    /// </summary>
    public partial class MyDependencyProperty : UserControl
    {
        public MyDependencyProperty()
        {
            InitializeComponent();
        }
        //1.声明依赖属性变量
        public static readonly DependencyProperty XuxColorProperty;

        //2.在系统属性中注册
        static MyDependencyProperty()
        {
            XuxColorProperty = DependencyProperty.Register("XuxColor", typeof(string), typeof(MyDependencyProperty)
                ,new PropertyMetadata("Red",(s,e) =>
                {
                    var mdp = s as MyDependencyProperty;
                    if (mdp != null)
                    {
                        try
                        {
                            var color = (Color)ColorConverter.ConvertFromString(e.NewValue.ToString());
                            mdp.Foreground = new SolidColorBrush(color);
                        }
                        catch
                        {
                            mdp.Foreground = new SolidColorBrush(Colors.Black);
                        }
                    }
                }
                ));
        }

        //3.使用.NET属性包装依赖属性:属性名称与注册时候的名称必须一致,
        //即属性名XuxColor对应注册时的XuxColor


        public string XuxColor
        {
            get { return (string)GetValue(XuxColorProperty); }
            set { SetValue(XuxColorProperty, value); }
        }
        


    }
}
