using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iRSDKSharp;

namespace iRacingSdkWrapper
{
    public interface IiRacingSdkWrapper
    {
        /// <summary>
        /// Gets the underlying iRacingSDK object.
        /// </summary>
        iRacingSDK Sdk { get; }

        /// <summary>
        /// Gets or sets how events are raised. Choose 'CurrentThread' to raise the events on the thread you created this object on (typically the UI thread), 
        /// or choose 'BackgroundThread' to raise the events on a background thread, in which case you have to delegate any UI code to your UI thread to avoid cross-thread exceptions.
        /// </summary>
        SdkWrapper.EventRaiseTypes EventRaiseType { get; set; }

        /// <summary>
        /// Is the main loop running?
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Is the SDK connected to iRacing?
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets or sets the number of times the telemetry info is updated per second. The default and maximum is 60 times per second.
        /// </summary>
        double TelemetryUpdateFrequency { get; set; }

        /// <summary>
        /// The time in milliseconds between each check if iRacing is running. Use a low value (hundreds of milliseconds) to respond quickly to iRacing startup.
        /// Use a high value (several seconds) to conserve resources if an immediate response to startup is not required.
        /// </summary>
        int ConnectSleepTime { get; set; }

        /// <summary>
        /// Gets the Id (CarIdx) of yourself (the driver running this application).
        /// </summary>
        int DriverId { get; }

        void Start();
        void Stop();
        object GetData(string headerName);
        TelemetryValue<T> GetTelemetryValue<T>(string name);
        void RequestSessionInfoUpdate();

        /// <summary>
        /// Event raised when the sim outputs telemetry information (60 times per second).
        /// </summary>
        event EventHandler<SdkWrapper.TelemetryUpdatedEventArgs> TelemetryUpdated;

        /// <summary>
        /// Event raised when the sim refreshes the session info (few times per minute).
        /// </summary>
        event EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> SessionInfoUpdated;

        /// <summary>
        /// Event raised when the SDK detects the sim for the first time.
        /// </summary>
        event EventHandler Connected;

        /// <summary>
        /// Event raised when the SDK no longer detects the sim (sim closed).
        /// </summary>
        event EventHandler Disconnected;

    }
}
