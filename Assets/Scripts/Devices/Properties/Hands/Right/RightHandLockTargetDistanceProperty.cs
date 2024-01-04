namespace Devices.Properties.Hands.Right
{
    public class RightHandLockTargetDistanceProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier =>
               Identifiers.NewId(Identifiers.RIGHT_HAND, Identifiers.LOCK, Identifiers.TARGET, Identifiers.DISTANCE);

        public string Get() => Game.Instance.rightHandLock.GetTargetDistance().S();
            
        public void Set(string cmd, string value)
        {
            try
            {
                var floatValue = value.F();
                Game.Instance.rightHandLock.SetTargetDistance(floatValue);
                OK();
            }
            catch
            {
                ERROR(ERROR_INVALID_VALUE);
            }
        }

    }
}