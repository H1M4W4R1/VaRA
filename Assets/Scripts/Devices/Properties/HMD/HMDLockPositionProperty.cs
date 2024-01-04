using UnityEngine;

namespace Devices.Properties.HMD
{
    public class HMDLockPositionProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => 
            Identifiers.NewId(Identifiers.HMD, Identifiers.LOCK, Identifiers.TARGET, Identifiers.POSITION);

        public string Get()
        {
            var pos = Game.Instance.hmdLock.GetTarget();
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


            Game.Instance.hmdLock.SetTargetPosition(new Vector3(vector[0], vector[1], vector[2]));
            OK();
        }

    }
}