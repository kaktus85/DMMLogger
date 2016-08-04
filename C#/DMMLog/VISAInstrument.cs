using NationalInstruments.Visa;
using Ivi.Visa;

namespace DMMLog
{    
    /// <summary>
    /// Base class for VISA-compliant instruments
    /// </summary>
    abstract class VISAInstrument
    {
        private IMessageBasedSession dmm; // digital multimeter
        private IMessageBasedRawIO io; // communication interface on a digital multimeter
        private string addressOrAlias; // VISA identifier of the instrument

        // <METHODS>

        /// <summary>
        /// Connects to the instrument via selected connection method (interface)
        /// </summary>
        /// <param name="addressOrAlias">VISA address or alias of the instrument</param>
        /// <param name="connectionMode">Physical interface over which the connection is made</param>
        public virtual void Connect(string addressOrAlias, ConnectionModes connectionMode)
        {
            if (IsConnected) { Disconnect(); } // disconnect first

            this.addressOrAlias = addressOrAlias;
            switch (connectionMode)
            {
                case ConnectionModes.USB:
                    dmm = new UsbSession(addressOrAlias);
                    break;
                case ConnectionModes.TCPIP:
                    dmm = new TcpipSession(addressOrAlias);
                    break;
                case ConnectionModes.Serial:
                    dmm = new SerialSession(addressOrAlias);
                    break;
                case ConnectionModes.VXI:
                    dmm = new VxiSession(addressOrAlias);
                    break;
                default:
                    break;
            }

            io = dmm.RawIO;
            dmm.TimeoutMilliseconds = Global.VISATimeout;                        
        }

        /// <summary>
        /// Disconnect the instrument and free the connection resources
        /// </summary>
        public void Disconnect()
        {
            io = null;         
            if (dmm != null)
            {                
                dmm.Dispose();
            }
            dmm = null;
            addressOrAlias = null;
        }

        /// <summary>
        /// Send a string to the instrument
        /// </summary>
        /// <param name="command">String to be sent to the instrument</param>
        public void Send(string command)
        {
            io.Write(command);
        }

        /// <summary>
        /// Send a string to the instrument and read the response
        /// </summary>
        /// <param name="command">String to be sent to the instrument</param>
        /// <returns>Response of the instrument</returns>
        public string Query(string command)
        {
            io.Write(command);
            return io.ReadString();
        }

        // </METHODS>

        // <PROPERTIES>

        /// <summary>
        /// Gets whether session is active
        /// </summary>
        public bool IsConnected { get { return (dmm != null); } }

        /// <summary>
        /// Gets the current VISA address or alias of the instrument
        /// </summary>
        public string Address { get { return addressOrAlias; } }

        // </PROPERTIES>

        // <EVENT HANDLERS>
        // </EVENT HANDLERS>
    }
}