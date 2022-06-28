using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeDesktopApp.Controls
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {


        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(string), typeof(Board), new PropertyMetadata("Next player: X"));

        private string GetStatus()
        {
            return "Next player: " + (IsXIsNext ? "X" : "O");
        }

        public bool IsXIsNext
        {
            get { return (bool)GetValue(IsXIsNextProperty); }
            set { SetValue(IsXIsNextProperty, value); }
        }

        public static readonly DependencyProperty IsXIsNextProperty =
            DependencyProperty.Register("IsXIsNext", typeof(bool), typeof(Board), new PropertyMetadata(true));


        private RelayCommand<int> handleClick;

        public RelayCommand<int> HandleClick
        {
            get
            {
                if (handleClick == null)
                {
                    handleClick = new RelayCommand<int>(OnHandleClick);
                }
                return handleClick;
            }

            set => handleClick = value;
        }
        public void OnHandleClick(int index)
        {
            ObservableCollection<string> squares = new ObservableCollection<string>(Squares);

            if (!string.IsNullOrEmpty(Squares[index]))
            {
                return;
            }
            squares[index] = IsXIsNext ? "X" : "O";
            Squares = squares;


            if (!string.IsNullOrEmpty(CalculateWinner()))
            {
                Status = "Winner is " + CalculateWinner();
                return;
            }

            IsXIsNext = !IsXIsNext;
            Status = GetStatus();
        }

        public ObservableCollection<string> Squares
        {
            get { return (ObservableCollection<string>)GetValue(SquaresProperty); }
            set { SetValue(SquaresProperty, value); }
        }

        public static readonly DependencyProperty SquaresProperty =
            DependencyProperty.Register("Squares",
                                        typeof(ObservableCollection<string>),
                                        typeof(Board),
                                        new PropertyMetadata(new ObservableCollection<string>(new string[9].ToList().Select(e => e = ""))));

        public Board()
        {
            InitializeComponent();
        }

        private string CalculateWinner()
        {
            int[][] lines = new int[][]
            {
                new int[3] {0,1,2},
                new int[3] {3,4,5},
                new int[3] {6,7,8},

                new int[3] {0,3,6},
                new int[3] {1,4,7},
                new int[3] {2,5,8},

                new int[3] {0,4,8},
                new int[3] {2,4,6},
            };

            foreach (int[] line in lines)
            {
                int a = line[0];
                int b = line[1];
                int c = line[2];

                if (Squares[a] != null && Squares[a] == Squares[b] && Squares[a] == Squares[c])
                {
                    return Squares[a];
                }
            }
            return string.Empty;
        }
    }
}