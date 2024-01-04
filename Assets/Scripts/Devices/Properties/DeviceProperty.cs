namespace Devices.Properties
{    
    public abstract class DeviceProperty
    {
        public abstract string Identifier { get; }
                
        private const string ERROR_UNKNOWN_COMMAND = "UNKNOWN_COMMAND"; // Command does not exist
        private const string ERROR_INVALID_COMMAND = "INVALID_COMMAND"; // Command is invalid (missing '=' or too many '=')
        private const string ERROR_NOT_IMPLEMENTED = "NOT_IMPLEMENTED"; // Command is not yet implemented (lazy dev detected)
        private const string ERROR_NOT_SUPPORTED = "NOT_SUPPORTED"; // Command is not supported (intentionally)
        public const string ERROR_INVALID_VALUE = "INVALID_VALUE"; // Command value is not valid

        public void OK() => Game.Instance.serialPort.SendSerialDataAsLine("OK");

        public static void ERROR(string id) => Game.Instance.serialPort.SendSerialDataAsLine("ERROR=" + id);

        private static void RESPOND(string request, string message) => Game.Instance.serialPort.SendSerialDataAsLine(request + "=" + message);

        private static void INVALID_COMMAND() => ERROR(ERROR_INVALID_COMMAND);

        public static void UNKNOWN_COMMAND() => ERROR(ERROR_UNKNOWN_COMMAND);

        private static void NOT_SUPPORTED() => ERROR(ERROR_NOT_SUPPORTED);

        public static string GetIdentifierFor(string cmd)
        {
            // Split command using '=', no '=' is allowed in value per spec
            var data = cmd.Split("=", System.StringSplitOptions.RemoveEmptyEntries);

            // Check for proper length
            if (data.Length == 0) return null;
            return data[0];
        }

        public void Process(string cmd)
        {
            // Split command using =, no = is allowed in value per spec
            var data = cmd.Split("=", System.StringSplitOptions.RemoveEmptyEntries);       

            // Check for proper length
            if(data.Length != 2)
            {
                INVALID_COMMAND();
                return;
            }

            var commandId = data[0];
            var commandValue = data[1].Trim('<', '>', '=');
            
            //  Check if command is data request
            if (commandValue == "?")
            {
                if (this is IGettableDeviceProperty getObject)
                    RESPOND(commandId, getObject.Get());
                else NOT_SUPPORTED();

            }
            else
            {
                if (this is ISettableDeviceProperty setObject)                
                    setObject.Set(commandId, commandValue);
                else NOT_SUPPORTED();
            }

        }

    }
}
