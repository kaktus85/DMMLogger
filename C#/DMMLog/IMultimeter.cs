using System.Collections.Generic;

namespace DMMLog
{
    /// <summary>
    /// Defines multimeter that has measurement modes and measures a single quantity
    /// </summary>
    public interface IMultimeter
    {        
        void Connect(string address, ConnectionModes connectionMode); // connect to the specified multimeter using specified physical interface
        void Disconnect(); // disconnect the multimeter
        void Reset(); // reset multimeter
        void Identify(); // query identification from multimeter
        void SetMode(Mode mode); // set a setting
        double Measure(); // measure current value

        List<Mode> GetModes { get; } // get list of settings
        bool IsConnected { get; } // get whether the multimeter is currently connected
        string Identification { get; } // returns the response of the identify query
        string Name { get; } // returns the string representation of the class that implements this interface
        string Address { get; } // returns the connectiona address of the multimeter
    }
}