using System;
using System.Collections.Generic;
using System.Globalization;

namespace DMMLog
{
    /// <summary>
    /// Agilent/Keysight 34410A digital multimeter
    /// </summary>
    class Agilent34410A : SCPIInstrument, IMultimeter
    {
        private const string name = "Agilent/Keysight 34410A";

        // <CONSTRUCTORS>
        // </CONSTRUCTORS>

        // <METHODS>

        /// <summary>
        /// Assigns modes and their parameters
        /// </summary>
        private void Setup()
        {
            Parameter param;
            modes = new List<Mode>();

            // AC voltage
            Mode ACVoltage = new Mode("CONF:VOLT:AC", "AC voltage", "Vrms");
            ACVoltage.Parameters = new Parameter[2]; // two parameters
            param = new Parameter("Range");            
            param.Add("Auto", "AUTO");
            param.Add("Minimum", "MIN");
            param.Add("Maximum", "MAX");
            param.Add("100 mV", "0.1");
            param.Add("1 V", "1");
            param.Add("10 V", "10");
            param.Add("100 V", "100");
            param.Add("1000 V", "1000");
            ACVoltage.Parameters[0] = param;

            param = new Parameter("Bandwidth", "VOLT:AC:BAND");                      
            param.Add("Minimum", "MIN");
            param.Add("Maximum", "MAX");
            param.Add("Default", "DEF");
            param.Add("3 Hz (slow)", "3");
            param.Add("20 Hz (medium)", "20");
            param.Add("200 Hz (fast)", "200");
            ACVoltage.Parameters[1] = param;

            modes.Add(ACVoltage);

            // DC voltage
            Mode DCVoltage = new Mode("CONF:VOLT:DC", "DC voltage", "V");
            DCVoltage.Parameters = new Parameter[1]; // one parameter
            param = new Parameter("Range");            
            param.Add("Auto", "AUTO");
            param.Add("Minimum", "MIN");
            param.Add("Maximum", "MAX");
            param.Add("100 mV", "0.1");
            param.Add("1 V", "1");
            param.Add("10 V", "10");
            param.Add("100 V", "100");
            param.Add("1000 V", "1000");
            DCVoltage.Parameters[0] = param;
            modes.Add(DCVoltage);

            // Frequency
            Mode Frequency = new Mode("CONF:FREQ", "Frequency", "Hz");
            Frequency.Parameters = new Parameter[1]; // one parameter
            param = new Parameter("Range");            
            param.Add("3 Hz", "MIN");
            param.Add("20 Hz", "DEF");
            param.Add("300 kHz", "MAX");
            Frequency.Parameters[0] = param;
            modes.Add(Frequency);
        }

        /// <summary>
        /// Performs a single measurement using the current mode
        /// </summary>
        /// <returns>Value from the device</returns>
        public double Measure()
        {
            Send("TRIG:SOUR BUS"); // bus trigger
            Send("INIT"); // set wait-for-trigger state
            Send("*TRG"); // trigger measurement
            Send("*WAI"); // wait for complete measurement
            string response = Query("FETC?");
            return Convert.ToDouble(response, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Overrides default connection method and augments it with setting a bus trigger
        /// </summary>
        /// <param name="addressOrAlias">See base method</param>
        /// <param name="connectionMode">See base method</param>
        public override void Connect(string addressOrAlias, ConnectionModes connectionMode)
        {
            base.Connect(addressOrAlias, connectionMode);
            Setup();
        }

        /// <summary>
        /// Overrides default connection method and augments it with selected option reset
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            Setup();
        }

        /// <summary>
        /// Overrides ToString with the response from the identification query, does not perform the query
        /// </summary>
        /// <returns>Response from identification query</returns>
        public override string ToString()
        {
            return IDN;
        }

        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// String identification of this class
        /// </summary>
        public string Name { get { return name; } }

        // </PROPERTIES>

        // <EVENT HANDLERS>
        // </EVENT HANDLERS>
    }
}
