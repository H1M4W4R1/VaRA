namespace Devices.Properties.HMD
{
    public class HMDLockInRangeProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.HMD, Identifiers.LOCK, Identifiers.IS_OK);

        public string Get() => Game.Instance.hmdLock.IsWithinDistance().ToString().ToUpper();

    }
}