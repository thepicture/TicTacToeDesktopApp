using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeDesktopApp.Controls
{
    /// <summary>
    /// Interaction logic for Square.xaml
    /// </summary>
    public partial class Square : UserControl
    {


        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(Square), new PropertyMetadata(default));


        public RelayCommand<int> OnClick
        {
            get { return (RelayCommand<int>)GetValue(OnClickProperty); }
            set { SetValue(OnClickProperty, value); }
        }

        public static readonly DependencyProperty OnClickProperty =
            DependencyProperty.Register("OnClick", typeof(RelayCommand<int>), typeof(Square), new PropertyMetadata(default));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(Square), new PropertyMetadata(default));

        public Square()
        {
            InitializeComponent();
        }
    }
}
