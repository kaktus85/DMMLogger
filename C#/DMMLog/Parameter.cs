using System.Collections.Generic;

namespace DMMLog
{
    /// <summary>
    /// Parameter that belongs to a single measuring mode
    /// </summary>
    public class Parameter
    {
        private string name; // name of this parameter
        private string command = null; // command to send to the instrument to set this parameter
        private List<KeyValuePair<string, string>> options = new List<KeyValuePair<string, string>>(); // possible values of the parameter
                                                                                                       // Key = human-friendly name, Value = SCPI command
        public int? SelectedOption = null; // number of the selected option

        // <CONSTRUCTORS>

        /// <summary>
        /// Constructor
        /// </summary>
        public Parameter(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Overloaded constructor with command
        /// </summary>
        public Parameter(string name, string command)
        {
            this.name = name;
            this.command = command;
        }

        // </CONSTRUCTORS>

        // <METHODS>

        /// <summary>
        /// Add an option
        /// </summary>
        /// <param name="optionName">Option name</param>
        /// <param name="optionCommand">Command associated with this option</param>
        public void Add(string optionName, string optionCommand)
        {
            options.Add(new KeyValuePair<string, string>(optionName, optionCommand));
        }

        /// <summary>
        /// Overrides ToString method
        /// </summary>
        /// <returns>Name of this parameter</returns>
        public override string ToString()
        {
            return name;
        }

        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// Gets the list of options for this parameter
        /// </summary>
        public List<KeyValuePair<string, string>> Options { get { return options; } }

        /// <summary>
        /// Gets the command associated with this parameter
        /// </summary>
        public string Command { get { return command; } }

        // </PROPERTIES>

        // <EVENT HANDLERS>
        // </EVENT HANDLERS>
    }
}
