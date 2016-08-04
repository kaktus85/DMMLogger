namespace DMMLog
{
    /// <summary>
    /// Class containing a single measurement mode of the instrument
    /// </summary>
    public class Mode
    {
        private string command; // command to send to the instrument to set this mode
        private string name; // string representation of this mode
        private string unit; // symbol of the physical unit of the value      
        public Parameter[] Parameters; // array of configurable parameters

        // <CONSTRUCTORS>

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Command to send to the instrument to set this mode</param>
        /// <param name="name">String representation of this mode</param>
        /// <param name="unit">Symbol of the physical unit of the value if measureable</param>        
        public Mode(string command, string name, string unit)
        {
            this.command = command;
            this.name = name;
            this.unit = unit;     
        }

        // </CONSTRUCTORS>

        // <METHODS>

        /// <summary>
        /// Name of this mode
        /// </summary>
        /// <returns>String representation of this mode</returns>
        public override string ToString()
        {
            return name;
        }

        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// Gets the command associated with this mode
        /// </summary>
        public string Command { get { return command; } }

        /// <summary>
        /// Gets the physical unit associated with this mode
        /// </summary>
        public string Unit { get { return unit; } }

        // </PROPERTIES>

        // <EVENT HANDLERS>
        // </EVENT HANDLERS>
    }
}
