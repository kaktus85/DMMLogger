using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Diagnostics;

namespace DMMLog
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        // <CONSTRUCTORS>

        /// <summary>
        /// Constructor
        /// </summary>
        public About()
        {
            InitializeComponent();
            DataContext = this; // for bindings
        }

        // </CONSTRUCTORS>

        // <METHODS>
        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// Gets the version number as defined in assembly information
        /// </summary>
        public string Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        // </PROPERTIES>

        // <EVENT HANDLERS>

        /// <summary>
        /// Handles clickable URLs
        /// </summary>
        /// <param name="sender">Clickable URL</param>
        /// <param name="e">Event arguments</param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        /// <summary>
        /// Handles ESC key to close the window
        /// </summary>
        /// <param name="sender">About window</param>
        /// <param name="e">Event arguments, identify the key that has been pressed</param>
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// Handles clicks to logo and opens GitHub repository
        /// </summary>
        /// <param name="sender">Logo</param>
        /// <param name="e">Event arguments</param>
        private void logo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo(Global.GitHubURL));
        }

        // </EVENT HANDLERS>
    }
}
