namespace Devices.Properties.HMD
{
    public class HMDLockTargetDistanceProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier =>
          Identifiers.NewId(Identifiers.HMD, Identifiers.LOCK, Identifiers.TARGET, Identifiers.DISTANCE);

        public string Get() => Game.Instance.hmdLock.GetTargetDistance().S();
            
        public void Set(string cmd, string value)
        {
            try
            {
                var floatValue = value.F();
                Game.Instance.hmdLock.SetTargetDistance(floatValue);
                OK();
            }
            catch
            {
                ERROR(ERROR_INVALID_VALUE);
            }
        }

    }
}