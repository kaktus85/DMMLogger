using System.Text;
using System.Collections.Generic;

namespace DMMLog
{
    /// <summary>
    /// Single measurement comprising of several text-based values (no parsing)
    /// </summary>
    class Measurement
    {  
        public List<string> Values = new List<string>();

        // <CONSTRUCTORS>
        // </CONSTRUCTORS>

        // <METHODS>        

        /// <summary>
        /// Creates a delimited string from all values
        /// </summary>
        /// <returns>All values</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in Values)
            {
                sb.Append(s);
                sb.Append(Global.Delimiter);
            }
            return sb.ToString();
        }

        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// Gets the values as an array
        /// </summary>
        public string[] Value { get { return Values.ToArray(); } }

        // </PROPERTIES>   

        // <EVENT HANDLERS>
        // </EVENT HANDLERS>
    }
}
