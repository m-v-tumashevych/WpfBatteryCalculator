using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfBatteryCalculator
{
    /// <summary>
    /// Логика взаимодействия для _3GeneratedPack.xaml
    /// </summary>
    public partial class _3GeneratedPack : Window
    {
        public List<int> cellsCapacities { get; set; }
        public int numberOfCellsInSeries { get; set; }
        public int numberOfCellsInParallel { get; set; }        
        public int nominalCellVoltage { get; set; }        
        public _3GeneratedPack()
        {
            InitializeComponent();
        }
        private List<List<int>> CombineCells(List<int> numbers, int s, int p)
        {                                            //numbers, n, p            
            numbers.Sort();
            numbers.Reverse(); // Sort the numbers in descending order            
            numbers = numbers.Slice(0, s * p);
            List<List<int>> groups = new List<List<int>>();
            for (int i = 0; i < s; i++)
            {
                groups.Add(new List<int>());
            }
            foreach (int num in numbers)
            {
                int minGroupIndex = MinGroupIndex(groups);
                groups[minGroupIndex].Add(num);
            }
            return groups;
        }
        static int MinGroupIndex(List<List<int>> groups)
        {
            int minIndex = 0;
            int minSum = int.MaxValue;
            for (int i = 0; i < groups.Count; i++)
            {
                int sum = groups[i].Sum();
                if (sum < minSum)
                {
                    minSum = sum;
                    minIndex = i;
                }
            }
            return minIndex;
        }
        private void btnStartAgain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _mainWindow = new MainWindow();
            _mainWindow.Owner = this;
            _mainWindow.Show();
            Hide();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void Form_Loaded(object sender, EventArgs e)
        {
            List<int> numbers = cellsCapacities;// { 2000, 1980, 2158, 1899, 2200, 2036, 1899, 1999, 2189, 2048, 2036, 1899, 1999, 2189, 2048 };
            int s = numberOfCellsInSeries; // Number of groups
            int p = numberOfCellsInParallel; // Number of items in each group
            List<List<int>> result = CombineCells(numbers, s, p);                       
            string str = "";
            for (int i = 0; i < result.Count; i++)
            {
                //str = str + $"Group {i + 1}: {string.Join(", ", result[i])} {result[i].Sum()}\n";
                str = str + "Parallel Pack" + i+ "-" + string.Join(", ", result[i]) +"\t" + "Total Capacity"+ result[i].Sum()+"\n";
            }
            tbGeneratedPack.Text = str;
        }
    }
}

