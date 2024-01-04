namespace Devices.Properties.Hands.Left
{
    public class LeftHandLockTargetDistanceProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier =>
              Identifiers.NewId(Identifiers.LEFT_HAND, Identifiers.LOCK, Identifiers.TARGET, Identifiers.DISTANCE);

        public string Get() => Game.Instance.leftHandLock.GetTargetDistance().S();
            
        public void Set(string cmd, string value)
        {
            try
            {
                var floatValue = value.F();
                Game.Instance.leftHandLock.SetTargetDistance(floatValue);
                OK();
            }
            catch
            {
                ERROR(ERROR_INVALID_VALUE);
            }
        }

    }
}