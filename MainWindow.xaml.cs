using System.Windows;
using System.Windows.Input;

namespace WpfBatteryCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<int> cellsCapacities { get; set; }
        public MainWindow()
        {
            InitializeComponent();            
        }
        private void ParseCellsCapacitiesTB()
        {
            string text = CellCapacitiesTB.Text;
            cellsCapacities = new List<int>();
            int cellCapacity;
            foreach (var cell in text.Split(", "))
            {
                if (int.TryParse(cell, out cellCapacity))
                {
                    cellsCapacities.Add(cellCapacity);
                }
            }            
        }
        private void BTNAddCellsClick(object sender, RoutedEventArgs e)
        {
            ParseCellsCapacitiesTB();
            if (cellsCapacities.Count() == 0)
            {
                CellCapacitiesTB.Text = "Enter cells capacities";
                return;
            }
            //Motherfacker acsesor cellsCapacities(Шоб я так жил!!!)           
            _2SpecifyPackDimensions specifyPackDimensions = new _2SpecifyPackDimensions();
            specifyPackDimensions.cellsCapacities = cellsCapacities;
            specifyPackDimensions.Owner = this;
            specifyPackDimensions.Show();
            Hide();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void CellCapacitiesTB_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.IBeam;
        }

        private void CellCapacitiesTB_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void CellCapacitiesTB_GotFocus(object sender, RoutedEventArgs e)
        {
            CellCapacitiesTB.Text = "";
        }
    }
}