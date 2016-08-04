using System;
using System.Text;
using System.IO;

namespace DMMLog
{
    /// <summary>
    /// Manages log file
    /// </summary>
    class File
    {
        private StreamWriter file;
        private string filePath;        
                
        // <CONSTRUCTORS>

        /// <summary>
        /// Create new file and write header
        /// </summary>
        /// <param name="filePath">Path to the file in filesystem</param>
        /// <param name="deviceInfo">Device identification info (should be from *IDN? query)</param>
        public File(string filePath, string deviceInfo)
        {
            this.filePath = filePath;
            file = new StreamWriter(filePath, true, new UTF8Encoding()); // append if file exists
            file.AutoFlush = true; // write data immediately to file to prevent data loss       
            if (deviceInfo != null)
            {
                file.WriteLine(deviceInfo); // first line - device identification     
            }            
        }

        // </CONSTRUCTORS>

        // <METHODS>

        /// <summary>
        /// Closes the file
        /// </summary>
        public void Close()
        {
            try
            {
                file.Close();
            }
            catch (Exception) { }
            finally
            {
                filePath = null;
            }
        }

        /// <summary>
        /// Writes a single line to the file
        /// </summary>
        /// <param name="line"></param>
        public void WriteLine(object line)
        {
            if ((line != null) && (filePath != null))
            {
                file.WriteLine(line.ToString());
            }            
        }

        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// Gets the file path
        /// </summary>
        public string FilePath { get { return filePath; } }

        // </PROPERTIES>

        // <EVENT HANDLERS>
        // </EVENT HANDLERS>
    }
}
