using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadingDLLs
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
               try
               {
                    string dll_path = $@"C:\Users\kyle\OneDrive\Misc\Visual_Studio\ReadingDLLs\DLLLoader\ReadingDLLs\ReadingDLLs\DLLs\DLLProject1.dll";
                    Assembly assembly = Assembly.LoadFrom(dll_path);

                    var window_types = assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Window)));

                    //pop out window when instantiating (instead of using .First() you would use a foreach loop to get through all
                         // DLLs in a directory when doing this

                    Window window_instance = (Window)Activator.CreateInstance(window_types.First());
                    //window_instance.Show();
                    TabItem tab_item = new TabItem
                    {
                         Header = window_types.First().Name,
                         Content = new ContentControl
                         {
                              Content = window_instance.Content
                         }

                    };

                    ViewController.Items.Add(tab_item);


               }
               catch
               {
                    MessageBox.Show("Failed to find dll");
               }
          }
     }
}