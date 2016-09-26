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
using TesProject.viewModels;

namespace TesProject
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
         
        public MainWindow ( )
            {
            InitializeComponent( );
 
            }

        private async  void button_Click ( object sender , RoutedEventArgs e )
            {

            Substrings binding = MyListBox.DataContext as Substrings;

            binding.FindAllTypeNStrings( );
             
        }

        private void button1_Click ( object sender , RoutedEventArgs e )
            {

            Substrings binding = MyListBox.DataContext as Substrings;

            binding.Cancel = true;

            }
        }
    }
