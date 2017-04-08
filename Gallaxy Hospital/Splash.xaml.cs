using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace Gallaxy_Hospital
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        DispatcherTimer dt =new DispatcherTimer();
        public Splash()
        {
            InitializeComponent();

            dt.Tick += new EventHandler(run_main);
            dt.Interval = new TimeSpan(0,0,10);
            dt.Start();
         }

          private void run_main(object sender, EventArgs e )
          {
              MainWindow w = new MainWindow();
              w.Show();

              dt.Stop();
              this.Close();
          }

        //SplashScreen splash = new SplashScreen("DSCF2282.JPG"); 
        //    splash.Show(true);

        //    MainWindow main = new MainWindow();


        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(i);
        //    }

        //    splash.Close(1000);

        //    main.Show();  
        
    }
}
