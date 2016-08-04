using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace DMMLog
{        
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        private Connection connectionWindow; // window for connection of multimeter
        private File logFile; // file for logging data        
        private List<IMultimeter> multimeters = new List<IMultimeter>(); // supported multimeters
        private ObservableCollection<Measurement> measurements = new ObservableCollection<Measurement>(); // measurements obtained from multimeter

        // GUI
        private List<ComboBox> modeCombos = new List<ComboBox>(); // combo boxes in list view
        public event GUIDelegate GUIUpdate; // delegate for updating GUI
        private List<BindingExpression> GUIBindingExpressions = new List<BindingExpression>(); // GUI elements that need updating               

        private bool headerChanged = true; // on next measurement, new header will be written to the file

        // <CONSTRUCTORS>

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Supported multimeters
            multimeters.Add(new Agilent34410A());

            // GUI
            DataContext = this;
            GUIUpdate += UpdateGUI;
            // combo boxes in list view
            modeCombos.Add(comboBoxMode1);
            modeCombos.Add(comboBoxMode2);
            modeCombos.Add(comboBoxMode3);
            modeCombos.Add(comboBoxMode4);
                            
            PopulateModes();            

            // list view binding
            listViewMeasurements.ItemsSource = measurements;

            // binding expressions
            GUIBindingExpressions.Add(statusBarConnection.GetBindingExpression(StatusBarItem.ContentProperty));
            GUIBindingExpressions.Add(menuItemInstrumentSettings.GetBindingExpression(MenuItem.IsEnabledProperty));
            GUIBindingExpressions.Add(buttonReset.GetBindingExpression(Button.IsEnabledProperty));
            GUIBindingExpressions.Add(buttonMeasure.GetBindingExpression(Button.IsEnabledProperty));
            GUIBindingExpressions.Add(statusBarLogFilePath.GetBindingExpression(StatusBarItem.ContentProperty));
            foreach (ComboBox cb in modeCombos)
            {
                GUIBindingExpressions.Add(cb.GetBindingExpression(ComboBox.IsEnabledProperty));
            }
        }

        // </CONSTRUCTORS>

        // <METHODS>

        /// <summary>
        /// Perfoms measurement based on selection from comboboxes in listview
        /// Writes new measurement to log file, if the file exists
        /// </summary>
        private void Measure()
        {
            // measure
            Measurement m = new Measurement();
            string value;
            DateTime now = DateTime.Now; // time stamp

            for (int i = 0; i < Global.Columns; i++) // perform measurement for all columns
            {
                value = string.Empty;
                if (modeCombos[i].SelectedIndex > 0)
                {
                    if (modeCombos[i].SelectedIndex == 1) // timestamp
                    {
                        value = now.ToString();
                    }
                    else
                    {
                        ConnectedMultimeter.SetMode(ConnectedMultimeter.GetModes[modeCombos[i].SelectedIndex - 2]); // first two modes are not performed by multimeter
                        value = ConnectedMultimeter.Measure().ToString();
                    }
                }
                m.Values.Add(value);
            }
            measurements.Add(m); // add the new measurement to the list of measurements

            // log file
            if (logFile != null)
            {
                if (headerChanged) // write new header if it has been changed since last write
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (ComboBox cb in modeCombos) // header from combo box items
                    {
                        if (cb.SelectedItem is string)
                        {
                            sb.Append(cb.SelectedItem);
                        }
                        else if (cb.SelectedItem is ComboBoxItem)
                        {
                            sb.Append(((ComboBoxItem)cb.SelectedItem).Content.ToString());
                        }

                        sb.Append(Global.Delimiter);
                    }

                    logFile.WriteLine(sb.ToString());
                    headerChanged = false;
                }

                logFile.WriteLine(m); // write new measurement - writeline accepts any object (all objects implement ToString() method), measurement overrides ToString() and creates a single delimited line from all the values
            }
        }    

        /// <summary>
        /// Safely updates GUI from different threads
        /// </summary>
        private void BeginUpdateGUI()
        {
            Dispatcher?.Invoke(GUIUpdate);
            //if (GUIUpdate != null) { Dispatcher.Invoke(GUIUpdate); }
        }

        /// <summary>
        /// Updates all GUI bindings
        /// </summary>
        private void UpdateGUI()
        {
            foreach (BindingExpression be in GUIBindingExpressions)
            {
                be.UpdateTarget();
            }
        }

        /// <summary>
        /// Fills combo boxes in listview with available measurement modes        
        /// </summary>
        private void PopulateModes()
        {
            // two default modes
            foreach (ComboBox cb in modeCombos)
            {
                cb.Items.Clear();
                cb.Items.Add("Not measured");
                cb.Items.Add("Time stamp");
                cb.SelectedIndex = 0;
            }
            // modeCombos[0].SelectedIndex = 1; // first column is time stamp by default

            // instrument-specific modes
            if (ConnectedMultimeter != null)
            {                
                foreach (Mode m in ConnectedMultimeter.GetModes) // add all modes…
                {
                    foreach (ComboBox cb in modeCombos) // …to every combobox
                    {
                        ComboBoxItem newItem = new ComboBoxItem();
                        newItem.Content = m.ToString() + " [" + m.Unit + "]"; // visible content is mode name with unit
                        cb.Items.Add(newItem);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a menu tree with all available modes with options
        /// </summary>
        private void PopulateSettings()
        {
            menuItemInstrumentSettings.Items.Clear(); // clear the current menu
            
            if (ConnectedMultimeter != null)
            {
                List<Mode> modes = ConnectedMultimeter.GetModes;
                foreach (Mode m in modes) // add all modes
                {
                    MenuItem newMode = new MenuItem();
                    newMode.Header = m.ToString();

                    for (int p = 0; p < m.Parameters.Length; p++) // add all parameters of a single mode
                    {
                        MenuItem newParameter = new MenuItem();
                        newParameter.Header = m.Parameters[p].ToString();
                        for (int kvp = 0; kvp < m.Parameters[p].Options.Count; kvp++) // add all options of a single parameter
                        {
                            MenuItem newOption = new MenuItem();
                            newOption.Header = m.Parameters[p].Options[kvp].Key;
                            newOption.Click += NewOption_Click;
                            newOption.IsCheckable = true;
                            if (m.Parameters[p].SelectedOption == kvp) // display tick if option is already selected
                            {
                                newOption.IsChecked = true;
                            }
                            newParameter.Items.Add(newOption);
                        }
                        newMode.Items.Add(newParameter);
                    }
                    menuItemInstrumentSettings.Items.Add(newMode);
                }
            }
        }

        /// <summary>
        /// Returns StringBuilder that contains the selected measurements in listview
        /// </summary>
        /// <returns>Selected measurements in listview</returns>
        private StringBuilder SelectedMeasurements()
        {
            StringBuilder sb = new StringBuilder();            

            foreach (Measurement m in measurements) // sort the selection by iterating through all existing measurements and evaluating whether they are selected
            {
                if (listViewMeasurements.SelectedItems.Contains(m))
                {
                    foreach (string value in m.Values)
                    {
                        sb.Append(value);
                        sb.Append(Global.Delimiter);
                    }
                    sb.AppendLine();
                }
            }

            return sb;
        }

        /// <summary>
        /// Returns StringBuilder that contains the current header of listview
        /// </summary>
        /// <returns>Listview header</returns>
        private StringBuilder ListViewHeader()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ComboBox cb in modeCombos) // header
            {
                if (cb.SelectedItem is string)
                {
                    sb.Append(cb.SelectedItem);
                }
                else if (cb.SelectedItem is ComboBoxItem)
                {
                    sb.Append(((ComboBoxItem)cb.SelectedItem).Content.ToString());
                }

                sb.Append(Global.Delimiter);
            }
            return sb;
        }

        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// Returns the currently connected multimeter or null if nothing is connected
        /// </summary>
        public IMultimeter ConnectedMultimeter
        {
            get
            {
                foreach (IMultimeter m in multimeters)
                {
                    if (m.IsConnected)
                    {
                        return m;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Gets string representation of currently connected multimeter for the status bar
        /// </summary>
        public string ConnectedMultimeterIdentification
        {
            get
            {
                if (MultimeterConnected)
                {
                    return ConnectedMultimeter.Identification;
                }
                else
                {
                    return "not connected";
                }
            }
        }

        /// <summary>
        /// Gets whether a multimeter is connected - for bindings
        /// </summary>
        public bool MultimeterConnected { get { return ConnectedMultimeter != null; } }

        /// <summary>
        /// Gets string representation of current log file path
        /// </summary>
        public string FilePathString
        {
            get
            {
                if (logFile != null)
                {
                    if (!string.IsNullOrEmpty(logFile.FilePath))
                    {
                        return "Log file: " + logFile.FilePath;
                    }
                }
                return "no file";                             
            }
        }

        // </PROPERTIES>

        // <EVENT HANDLERS>

        /// <summary>
        /// Handles keyboard shortcuts for the main window
        /// </summary>
        /// <param name="sender">Main window</param>
        /// <param name="e">Key identification</param>
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Space) && (buttonMeasure.IsEnabled))
            {
                Measure();
            }
        }

        /// <summary>
        /// Handles the deallocation of resources when window is about to close
        /// Close file
        /// Disconnect multimeter
        /// </summary>
        /// <param name="sender">Main window</param>
        /// <param name="e">Parameter</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            logFile?.Close();
            ConnectedMultimeter?.Disconnect();
        }

        /// <summary>
        /// Create a new file
        /// </summary>
        /// <param name="sender">New in File menu</param>
        /// <param name="e">Parameter</param>
        private void menuItemFileNew_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dialog.Title = "Create New Log";
            dialog.ValidateNames = true;
            dialog.CreatePrompt = false;
            dialog.OverwritePrompt = false; // file will be appended to
            if (dialog.ShowDialog() == true)
            {
                logFile?.Close(); // close the current file

                if (ConnectedMultimeter == null) // write identification if multimeter is connected
                {
                    logFile = new File(dialog.FileName, "");
                }
                else
                {
                    logFile = new File(dialog.FileName, ConnectedMultimeter.Identification);
                }

                GUIUpdate();
            }
        }

        /// <summary>
        /// Close current log file
        /// </summary>
        /// <param name="sender">Close in File menu</param>
        /// <param name="e">Parameter</param>
        private void menuItemFileClose_Click(object sender, RoutedEventArgs e)
        {
            logFile?.Close();
            GUIUpdate();
        }

        /// <summary>
        /// Close the main window, thus quitting the program
        /// </summary>
        /// <param name="sender">Exit in File menu</param>
        /// <param name="e">Parameter</param>
        private void menuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles clicks to options in instrument settings menu
        /// </summary>
        /// <param name="sender">Clicked option</param>
        /// <param name="e">Parameter</param>
        private void NewOption_Click(object sender, RoutedEventArgs e)
        {
            // track the mode, parameter and selected option 
            MenuItem selectedOption = (MenuItem)sender;
            MenuItem parameter = (MenuItem)selectedOption.Parent;
            MenuItem mode = (MenuItem)parameter.Parent;
            int optionIndex = parameter.Items.IndexOf(selectedOption);
            int parameterIndex = mode.Items.IndexOf(parameter);
            int modeIndex = menuItemInstrumentSettings.Items.IndexOf(mode);

            ConnectedMultimeter.GetModes[modeIndex].Parameters[parameterIndex].SelectedOption = optionIndex;
            PopulateSettings(); // redraw settings with the new selection
        }

        /// <summary>
        /// Opens connection dialog window
        /// </summary>
        /// <param name="sender">Menu item Connection -> VISA</param>
        /// <param name="e">Parameter</param>
        private void menuItemConnectionVISA_Click(object sender, RoutedEventArgs e)
        {
            connectionWindow = new Connection(multimeters);
            connectionWindow.ShowDialog();
            PopulateModes();
            PopulateSettings();
            BeginUpdateGUI();               
        }

        /// <summary>
        /// Opens About window as dialog
        /// </summary>
        /// <param name="sender">About in Help menu</param>
        /// <param name="e">Parameter</param>
        private void menuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        /// <summary>
        /// Handles clicks to measure button
        /// </summary>
        /// <param name="sender">Measure button</param>
        /// <param name="e">Parameter</param>
        private void buttonMeasure_Click(object sender, RoutedEventArgs e)
        {
            Measure();
        }

        /// <summary>
        /// Handles clicks to reset button
        /// </summary>
        /// <param name="sender">Reset button</param>
        /// <param name="e">Parameter</param>
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectedMultimeter != null)
            {
                ConnectedMultimeter.Reset();
                PopulateSettings();
            }                        
        }

        /// <summary>
        /// Handles new headers when selected modes change
        /// </summary>
        /// <param name="sender">Any combo box in listview</param>
        /// <param name="e">Parameter</param>
        private void comboBoxMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            measurements.Clear(); // clear all measurements because they are no longer tied to the new header
            headerChanged = true;            
        }

        /// <summary>
        /// Copies selected values from listview to clipboard
        /// </summary>
        /// <param name="sender">Listview</param>
        /// <param name="e">Parameter</param>
        private void CopyValues_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SelectedMeasurements());

            try { Clipboard.SetData(DataFormats.UnicodeText, sb.ToString()); }
            catch (System.Runtime.InteropServices.COMException) { } // clipboard not accessible                        
        }

        /// <summary>
        /// Copies selected values from listview and the header to clipboard
        /// </summary>
        /// <param name="sender">Listview</param>
        /// <param name="e">Parameter</param>
        private void CopyValuesWithHeader_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ListViewHeader());
            sb.AppendLine();
            sb.Append(SelectedMeasurements());

            try { Clipboard.SetData(DataFormats.UnicodeText, sb.ToString()); }
            catch (System.Runtime.InteropServices.COMException) { } // clipboard not accessible        
        }  

        /// <summary>
        /// Removes the selected lines in listview from measurements
        /// </summary>
        /// <param name="sender">Listview</param>
        /// <param name="e">Parameter</param>
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            while (listViewMeasurements.SelectedItems.Count > 0)
            {
                measurements.RemoveAt(listViewMeasurements.SelectedIndex);
            }            
        }

        // </EVENT HANDLERS>
    }
}
