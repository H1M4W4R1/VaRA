using Devices.Communication;
using Devices.Properties;
using Devices.Properties.Blindfold;
using Devices.Properties.Hands.Left;
using Devices.Properties.Hands.Right;
using Devices.Properties.HMD;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Devices
{
    public class DeviceObject : MonoBehaviour
    {
        [Header("Links")]
        public UnitySerialPort serialPort;

        [Header("Debug")]
        public bool debugMode = false;

        private List<DeviceProperty> _properties = new List<DeviceProperty>();

        private void Register(DeviceProperty command)
        {
            if (!_properties.Contains(command)) {
                _properties.Add(command);

                // Process debug message ;)
                if (debugMode) 
                {
                    var isGet = command is IGettableDeviceProperty;
                    var isSet = command is ISettableDeviceProperty;

                    var getSetString = "";
                    if (isGet && isSet)
                        getSetString = "GET, SET";
                    else if (isGet)
                        getSetString = "GET";
                    else if (isSet)
                        getSetString = "SET";

                    Debug.Log("[VaRA] Registered property " + command.Identifier + " with [" + getSetString + "]");
                }
            }
        }
        

        private void Start()
        {
            // Create serial Port
            serialPort.OpenSerialPort();
            UnitySerialPort.SerialDataParseEvent += DataParsedEvent;

            // Load all properties
            Register(new BlindfoldActiveProperty());
            Register(new BlindfoldColorProperty());

            Register(new LeftHandPositionProperty());
            Register(new RightHandPositionProperty());

            Register(new LeftHandRotationProperty());
            Register(new RightHandRotationProperty());

            Register(new HMDPositionProperty());    
            Register(new HMDRotationProperty());

            Register(new LeftHandLockActiveProperty());
            Register(new RightHandLockActiveProperty());
            Register(new HMDLockActiveProperty());

            Register(new LeftHandLockTargetDistanceProperty());
            Register(new RightHandLockTargetDistanceProperty());
            Register(new HMDLockTargetDistanceProperty());

            Register(new LeftHandLockInRangeProperty());
            Register(new RightHandLockInRangeProperty());
            Register(new HMDLockInRangeProperty());

            Register(new LeftHandLockPositionProperty());
            Register(new RightHandLockPositionProperty());
            Register(new HMDLockPositionProperty());

            Register(new LeftHandLockDistanceProperty());
            Register(new RightHandLockDistanceProperty());
            Register(new HMDLockDistanceProperty());

        }

        public DeviceObject Get() => FindFirstObjectByType<DeviceObject>();

        private void DataParsedEvent(string[] data, string rawData)
        {
            foreach (var d in data)
            {
                // Prepare command to be parsed
                var dmesg = d.Trim('\r', '\n', ' ', '\t');
                var propertyId = DeviceProperty.GetIdentifierFor(dmesg);

                // Ignore empty lines
                if (propertyId == null) return;

                // Get property and execute it
                var property = _properties.FirstOrDefault(p => p.Identifier == propertyId);

                // If command does not exist respond as null command
                if (property == null)
                {
                    DeviceProperty.UNKNOWN_COMMAND();
                    return;
                }

                property.Process(dmesg);
            }
        }
    }

}