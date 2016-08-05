using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DMMLog
{
    /// <summary>
    /// Interaction logic for Connection.xaml
    /// </summary>
    public partial class Connection : Window
    {
        private List<IMultimeter> multimeters; // list of supported multimeters
        private List<BindingExpression> GUIBindingExpressions = new List<BindingExpression>();

        // <CONSTRUCTORS>

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="multimeters">List of supported multimeters</param>
        public Connection(List<IMultimeter> multimeters)
        {
            InitializeComponent();
            this.multimeters = multimeters;
            DataContext = this; // for bindings

            // fill combo box with multimeter names
            foreach (IMultimeter m in this.multimeters)
            {
                comboBoxInstrument.Items.Add(m.Name);
                if (m.IsConnected)
                {
                    comboBoxInstrument.SelectedItem = m; // select the currently connected multimeter
                    textBoxVISA.Text = m.Address; // fill the address 
                }
            }
            if ((comboBoxInstrument.SelectedIndex == -1) && (comboBoxInstrument.Items.Count > 0)) // select first multimeter by default, if there is at least one multimeter to choose from and no multimeter is connected
            {
                comboBoxInstrument.SelectedIndex = 0;
            }

            // fill combo box with connection options
            foreach (int i in Enum.GetValues(typeof(ConnectionModes)))
            {
                comboBoxInstrumentConnectionType.Items.Add(((ConnectionModes)i).Name());                
            }
            if (comboBoxInstrumentConnectionType.Items.Count > 0) // select first connection option by default, if there is at least one option to choose from
            {
                comboBoxInstrumentConnectionType.SelectedIndex = 0;
            }

            // binding expressions
            GUIBindingExpressions.Add(buttonConnect.GetBindingExpression(Button.ContentProperty));

            UpdateGUI();
            textBoxVISA.Focus(); // set cursor to address or alias text box
        }

        // </CONSTRUCTORS>

        // <METHODS>

        /// <summary>
        /// Updates GUI elements
        /// </summary>
        private void UpdateGUI()
        {          
            foreach (BindingExpression be in GUIBindingExpressions)
            {
                be.UpdateTarget();
            }
        }

        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// Gets the caption of connect button based on whether a multimeter is connected
        /// </summary>
        /// <returns>Button caption</returns>
        public string Connected
        {
            get
            { 
                if (multimeters[comboBoxInstrument.SelectedIndex].IsConnected)
                {
                    return "Disconnect";
                }
                else
                {
                    return "Connect";
                }
            }
        }

        // </PROPERTIES>

        // <EVENT HANDLERS>

        /// <summary>
        /// Connects to or disconnects from the selected multimeter
        /// </summary>
        /// <param name="sender">Button Connect</param>
        /// <param name="e">Parameter</param>
        private void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            textBlockIdentify.Text = string.Empty;

            // disconnect
            if (multimeters[comboBoxInstrument.SelectedIndex].IsConnected)
            {
                multimeters[comboBoxInstrument.SelectedIndex].Disconnect();                
                UpdateGUI();
                return;
            }
            
            // connect
            foreach (IMultimeter m in multimeters) // first disconnect from all multimeters
            {
                if (m.IsConnected)
                {
                    m.Disconnect();
                }
            }
            
            try
            { 
                // try connecting to selected multimeter using address in text box
                multimeters[comboBoxInstrument.SelectedIndex].Connect(textBoxVISA.Text, (ConnectionModes)(comboBoxInstrumentConnectionType.SelectedIndex));                
                multimeters[comboBoxInstrument.SelectedIndex].Identify(); // query identify
                textBlockIdentify.Text = multimeters[comboBoxInstrument.SelectedIndex].Identification; // show identification response in text block
                multimeters[comboBoxInstrument.SelectedIndex].Reset(); // reset instrument to start from known configuration                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                UpdateGUI();
            }            
        }

        /// <summary>
        /// Manages connect button caption to connect or disconnect based on whether the selected multimeter is connected or not
        /// </summary>
        /// <param name="sender">Combo box instrument</param>
        /// <param name="e">Parameter</param>
        private void comboBoxInstrument_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGUI();
        }

        /// <summary>
        /// Closes this window
        /// </summary>
        /// <param name="sender">Button Close (OK)</param>
        /// <param name="e">Parameter</param>
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        { 
            Close(); // close this window
        }

        /// <summary>
        /// Iff any multimeter is connected, then the dialog result is true
        /// </summary>
        /// <param name="sender">Window closing event</param>
        /// <param name="e">Parameter</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = false;
            foreach (IMultimeter m in multimeters) // see if any multimeter is connected
            {
                if (m.IsConnected)
                {
                    DialogResult = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Manages keyboard shortcuts
        /// </summary>
        /// <param name="sender">Window</param>
        /// <param name="e">Key pressed details</param>
        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) // close window
            {
                Close();
            }
            else if (e.Key == System.Windows.Input.Key.Enter) // attempt connect or disconnect
            {
                buttonConnect_Click(null, null);
            }
        }

        // </EVENT HANDLERS>
    }
}
