using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EscapingButton
{
    public partial class MainWindow : Window
    {
        private double _distance = 5;
        private Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            button.MouseEnter += Button_MouseEnter;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            int direction = _random.Next(8);
            TranslateTransform translate = new TranslateTransform();
            button.RenderTransform = translate;

            DoubleAnimation animationX = new DoubleAnimation(0, TimeSpan.FromMilliseconds(50));
            DoubleAnimation animationY = new DoubleAnimation(0, TimeSpan.FromMilliseconds(50));

            switch (direction)
            {
                case 0: // вверх
                    animationY.To = mousePosition.Y - _distance;
                    break;
                case 1: // влево
                    animationX.To = mousePosition.X - _distance;
                    break;
                case 2: // вниз
                    animationY.To = mousePosition.Y + _distance;
                    break;
                case 3: // вправо
                    animationX.To = mousePosition.X + _distance;
                    break;
                case 4: // вверх-влево
                    animationX.To = mousePosition.X - _distance;
                    animationY.To = mousePosition.Y - _distance;
                    break;
                case 5: // вверх-вправо
                    animationX.To = mousePosition.X + _distance;
                    animationY.To = mousePosition.Y - _distance;
                    break;
                case 6: // вниз-влево
                    animationX.To = mousePosition.X - _distance;
                    animationY.To = mousePosition.Y + _distance;
                    break;
                case 7: // вниз-вправо
                    animationX.To = mousePosition.X + _distance;
                    animationY.To = mousePosition.Y + _distance;
                    break;
            }
            translate.BeginAnimation(TranslateTransform.XProperty, animationX);
            translate.BeginAnimation(TranslateTransform.YProperty, animationY);
        }
    }
}
