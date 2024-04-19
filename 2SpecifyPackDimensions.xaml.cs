
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfBatteryCalculator
{
    /// <summary>
    /// Логика взаимодействия для _2SpecifyPackDimensions.xaml
    /// </summary>
    public partial class _2SpecifyPackDimensions : Window
    {
        public List<int> cellsCapacities { get; set; }
        
        public _2SpecifyPackDimensions()
        {
            InitializeComponent();            
        }         
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _mainWindow = new MainWindow();
            _mainWindow.Owner = this;
            _mainWindow.Show();
            Hide();
        }
        private bool ValidateIntValue(TextBox textBox, out int intValue)
        {
            int.TryParse(textBox.Text.ToString(), out intValue);
            bool isOk = true;
            if (intValue <= 0)
            {
                textBox.Text = "Enter value";
                isOk = false;
            }            
            return isOk;


        }
        private void btnGeneratePacks_Click(object sender, RoutedEventArgs e)
        {            
            int numberOfCellsInSeries=1;            
            bool validateIsOk = ValidateIntValue(NumberOfCellsInSeries, out numberOfCellsInSeries);

            int numberOfCellsInParallel=1;
            //int.TryParse(NumberOfCellsInParallel.Text.ToString(), out numberOfCellsInParallel);
            validateIsOk = validateIsOk && ValidateIntValue(NumberOfCellsInParallel, out numberOfCellsInParallel);
            if (cellsCapacities.Count() < numberOfCellsInSeries * numberOfCellsInParallel)
            {
                NumberOfCellsInSeries.Text = "Wrong battery parameters";
                NumberOfCellsInParallel.Text = "Wrong battery parameters";
                return;
            }
            if (!validateIsOk)
                return;

            _3GeneratedPack generatedPack = new _3GeneratedPack();
            //specifyPackDimensions.CellsCapacities = cellsCapacities;
            generatedPack.cellsCapacities = cellsCapacities;
            generatedPack.numberOfCellsInSeries = numberOfCellsInSeries;
            generatedPack.numberOfCellsInParallel = numberOfCellsInParallel;                   
            generatedPack.Owner = this;
            generatedPack.Show();
            Hide();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void NumberOfCellsInSeries_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.IBeam;
        }
        private void NumberOfCellsInSeries_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }        
        private void NumberOfCellsInSeries_GotFocus(object sender, RoutedEventArgs e)
        {
            NumberOfCellsInSeries.Text = "";
        }
        private void numberOfCellsInParallel_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.IBeam;
        }
        private void numberOfCellsInParallel_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void numberOfCellsInParallel_GotFocus(object sender, RoutedEventArgs e)
        {
            NumberOfCellsInParallel.Text = "";
        }        
        private void tbNominalCellVoltage_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.IBeam;
        }
        private void tbNominalCellVoltage_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }                
    }
}
