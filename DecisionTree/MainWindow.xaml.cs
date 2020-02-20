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

namespace DecisionTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TheListBox.Items.Clear();
            Calculator calculator = new Calculator();
            ListGenerator listGenerator = new ListGenerator();
            // 1: Outlook
            // 2: Temperature
            // 3: Humidity
            // 4: Wind
            int columnIndex;
            string columnName = "";
            List<string> columnTypesListPairedWithPlay, classList;
            for (columnIndex = 1; columnIndex <= 4; columnIndex++)
            {
                columnTypesListPairedWithPlay = listGenerator.getClassAndPlayPair(columnIndex);
                classList = listGenerator.getListOfClass(columnIndex);
                columnName = listGenerator.getColumnName(columnIndex);
                TheListBox.Items.Add($"{columnName} Gini index: {calculator.calculateClassGI_By_Pairs(columnTypesListPairedWithPlay, classList)}");
                for (int i = 0; i < classList.Count; i++)
                {
                    TheListBox.Items.Add($"{listGenerator.getTypeName(classList, i)} Gini index: {calculator.calculateClassTypeGI_Class_Play_pairs(columnTypesListPairedWithPlay, classList[i])}");
                }
                TheListBox.Items.Add("");
            }
        }
    }
}
