using System.Collections.Generic;

namespace DMMLog
{
    /// <summary>
    /// Base class for SCPI instruments derived from VISA instruments
    /// </summary>
    abstract class SCPIInstrument : VISAInstrument
    {
        protected List<Mode> modes; // instrument measurement modes
        protected string IDN; // response to identification query

        // <METHODS>        

        /// <summary>
        /// Queries standard identification
        /// </summary>
        /// <returns>Unique string identifier for the instrument</returns>
        public void Identify()
        {
            IDN = Query("*IDN?");            
        }

        /// <summary>
        /// Resets the instrument
        /// </summary>
        public virtual void Reset()
        {
            Send("*RST");
        }       

        /// <summary>
        /// Sets instrument mode with parameters
        /// </summary>
        /// <param name="mode">Mode to set</param>
        public void SetMode(Mode mode)
        {                        
            if (mode.Parameters != null)
            {
                // first send the main configure command with parameters\
                string command = mode.Command;
                bool firstParameter = true; // for managing white space and commas

                foreach (Parameter p in mode.Parameters)
                {
                    if ((p.Command == null) && (p.SelectedOption != null)) // the parameter must not have its own command; an option must be selected
                    {
                        if (firstParameter)
                        {
                            command += " ";
                            firstParameter = false;
                        }
                        else
                        {
                            command += ",";
                        }
                        command += p.Options[(int)(p.SelectedOption)].Value;
                    }
                }                           
                Send(command); // send the complete command

                // then send all parameters that have their own specific commands
                foreach (Parameter p in mode.Parameters)
                {
                    if ((p.Command != null) && (p.SelectedOption != null))  // the parameter must have its own command; an option must be selected
                    {
                        Send(p.Command + " " + p.Options[(int)(p.SelectedOption)].Value);
                    }
                }
            }
        }      

        // </METHODS>        

        // <PROPERTIES>

        /// <summary>
        /// Gets the list of modes
        /// </summary>
        public List<Mode> GetModes { get { return modes; } }

        /// <summary>
        /// Gets the response to identification query
        /// </summary>
        public string Identification { get { return IDN; } }

        // </PROPERTIES>

        // <EVENT HANDLERS>
        // </EVENT HANDLERS>
    }
}