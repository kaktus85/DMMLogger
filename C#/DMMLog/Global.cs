namespace DMMLog
{
    // Global definitions, delegates and enums with their extension methods

    // delegates
    public delegate void GUIDelegate();

    // enums
    public enum ConnectionModes { USB, TCPIP, Serial, VXI };

    /// <summary>
    /// Extends ConnectionModes with their human-friendly name
    /// </summary>
    static class EnumExtension
    {
        public static string Name(this ConnectionModes connectionMode)
        {
            string[] connectionModesNames = new string[] { "USB", "TCP/IP", "Serial port", "VXI" };
            return connectionModesNames[(int)connectionMode];
        }
    }

    /// <summary>
    /// Global definitions
    /// </summary>
    class Global
    {
        public const char Delimiter = '\t'; // tab-delimited values
        public const int Columns = 4; // number of columns in listview
        public const string GitHubURL = "https://github.com/kaktus85/DMMLogger"; // URL of GitHub repository of this project
        public const int VISATimeout = 5000; // timeout in milliseconds for communication with multimeters
    }
}
