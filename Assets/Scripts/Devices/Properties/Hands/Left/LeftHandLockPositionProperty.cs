using UnityEngine;

namespace Devices.Properties.Hands.Left
{
    public class LeftHandLockPositionProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => 
            Identifiers.NewId(Identifiers.LEFT_HAND, Identifiers.LOCK, Identifiers.TARGET, Identifiers.POSITION);

        public string Get()
        {
            var pos = Game.Instance.leftHandLock.GetTarget();
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


            Game.Instance.leftHandLock.SetTargetPosition(new Vector3(vector[0], vector[1], vector[2]));
            OK();
        }

    }
}