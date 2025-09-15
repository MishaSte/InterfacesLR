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

namespace Lab2_Interfaces_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputText.Text.Trim().Length > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }
        void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText("B:\\myFile.txt",inputText.Text);
            MessageBox.Show("Your file was saved!");
        }

        void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if(openFileDialog.ShowDialog() == true)
            {
                string fileContent = System.IO.File.ReadAllText(openFileDialog.FileName);
                inputText.Text = fileContent;
            }
        }

        void canExecute_Erase(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputText.Text.Trim().Length > 0)
                e.CanExecute = true;
            else
                e.CanExecute= false;
        }

        void execute_Erase(object sender, ExecutedRoutedEventArgs e)
        {
            inputText.Clear();
        }
        public MainWindow()
        {
            InitializeComponent();

            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBindings.Add(saveCommand);

            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open);
            CommandBindings.Add(openCommand);

            CommandBinding eraseCommand = new CommandBinding(ApplicationCommands.Delete, execute_Erase, canExecute_Erase);
            CommandBindings.Add(eraseCommand); 
        }
    }
}
