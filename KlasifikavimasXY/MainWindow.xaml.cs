using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;

namespace KlasifikavimasXY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObjectTrainer ot;
        List<ObjectTrainer> mokAibe = new List<ObjectTrainer>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mokAibe.Clear();
            listBox.Items.Clear();

            // form a list of existing objects 

            int choice=0;
            if (fileButton.IsChecked == true) choice = 1;
            if (dbButton.IsChecked == true) choice = 2;
            switch (choice)
            {
                case 1:
                    {
                        string path = @"C:\Users\Tomas\OneDrive - Vilniaus kolegija\3_Kursas\Intelektika\Klasifikavimas_GC\k-NN_classification\k-NN_classification\data\data.txt";
                        string[] lines = File.ReadAllLines(path);

                        int amountOfObjects = int.Parse(lines[0]);
                        for (int i = 1; i <= amountOfObjects; i++)
                        {
                            string[] tempArr = lines[i].Split(';');
                            ot = new ObjectTrainer(int.Parse(tempArr[0]), int.Parse(tempArr[1]), tempArr[2]);
                            mokAibe.Add(ot);
                        }
                        for (int i = 0; i < mokAibe.Count; i++)
                            listBox.Items.Add($"{i}) {mokAibe[i].X1} {mokAibe[i].X2} {mokAibe[i].ClassName}");
                        break;
                    }
                case 2:
                    {
                        LINQtoSQLClassDataContext dc = new LINQtoSQLClassDataContext(Properties.Settings.Default.KlasifikavimasConnectionString);

                        // jei naudociau DataGrid:
                        // if (dc.DatabaseExists()) myDataGrid.ItemsSource = dc.myObjects; 

                        if (dc.DatabaseExists())
                            foreach (var item in dc.myObjects)
                            {
                                ot = new ObjectTrainer(item.X, item.Y, item.className.ToString());
                                mokAibe.Add(ot);
                                listBox.Items.Add($"{item.X} {item.Y} {item.className}");
                            }
                        // Insert statement pavyzdys
                        // dc.ExecuteQuery<myObject>("insert into myObject (ID,X,Y,className) values (7,7,7,'-')");
                        break;
                    }
                default: { MessageBox.Show("Please select data source."); break; }
            }

            // assign a class to new objects depending on the distance by formulas 1 and / or 2

            Calculator calc = new Calculator();
            int k;
            List<double> distance1;
            if (kSelectMenu.SelectedItem == null) { MessageBox.Show("Please choose k value from drop-down menu."); return; }
            else { k = int.Parse(kSelectMenu.Text); }

            ot = new ObjectTrainer();
            ot.X1 = 5;ot.X2 = 3;

            if (F1Button.IsChecked == true) { distance1 = calc.Formula1(ot, mokAibe); }
            else if (F2Button.IsChecked == true) { distance1 = calc.Formula2(ot, mokAibe); }
            else { MessageBox.Show("Please choose which formula to use for calculations."); return; }

            listBox.Items.Add($"\nVisi atstumai: \n{calc.getDistArrayString(distance1)}");

            listBox.Items.Add($"Nepriskirta klase: {ot.fullInfo}");

            calc.assignClass(ot, distance1, mokAibe, k);
            listBox.Items.Add($"Priskirta klase: {ot.fullInfo}");

            List<double> sortedDistances = distance1;
            calc.sortMyList(sortedDistances);
            listBox.Items.Add($"Surikiuoti atstumai: \n{calc.getDistArrayString(sortedDistances)}");

            listBox.Items.Add($"Mokomoji aibe su atstumais: \n{calc.getMokAibeWithDistances(mokAibe)}");
        }
    }
}