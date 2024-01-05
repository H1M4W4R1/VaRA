using UnityEngine;

namespace Devices.Properties.Configuration
{
    public class UserHeightProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => 
            Identifiers.NewId(Identifiers.CONFIG, Identifiers.USER, Identifiers.HEIGHT);

        public string Get()
        {
            var pos = Room.Get().transform.position;
            return "<" + pos.x.S() + "," + pos.y.S() + "," + pos.z.S() + ">";
        }


        public void Set(string cmd, string value)
        {
            var height = value.F();
 
            // Validate if room exists in current scene
            var usr = User.Get();
            if(usr == null)
            {
                ERROR(ERROR_NOT_SUPPORTED);
                return;
            }

            usr.SetHeight(height);
            OK();
        }

    }
}