using UnityEngine;

namespace Devices.Properties.Configuration
{
    public class RoomOffsetProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => 
            Identifiers.NewId(Identifiers.CONFIG, Identifiers.ROOM, Identifiers.OFFSET);

        public string Get()
        {
            var pos = Room.Get().transform.position;
            return "<" + pos.x.S() + "," + pos.y.S() + "," + pos.z.S() + ">";
        }


        public void Set(string cmd, string value)
        {
            var vector = value.V();
            if (vector == null)
            {
                ERROR(ERROR_INVALID_VALUE);
                return;
            }

            if (vector.Count != 3)
            {
                ERROR(ERROR_INVALID_VALUE);
                return;
            }

            // Validate if room exists in current scene
            var room = Room.Get();
            if(room == null)
            {
                ERROR(ERROR_NOT_SUPPORTED);
                return;
            }

            room.SetOffset(new Vector3(vector[0], vector[1], vector[2]));
            OK();
        }

    }
}