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

namespace _30_WPF_UserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(UserControl1));
        public static readonly RoutedEvent ChangeValueEvent = EventManager.RegisterRoutedEvent("ChangeValueEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserControl1));
        public event RoutedEventHandler ChangeValue
        {
            add { AddHandler(ChangeValueEvent, value); }
            remove { RemoveHandler(ChangeValueEvent, value); }
        }
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public UserControl1()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void textChange(object sender, TextChangedEventArgs e)
        {
            RoutedEventArgs arg = new RoutedEventArgs(ChangeValueEvent);
            RaiseEvent(arg);
        }
    }
}
