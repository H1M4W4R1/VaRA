namespace Devices.Properties.HMD
{
    public class HMDLockActiveProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.HMD, Identifiers.LOCK, Identifiers.ACTIVE);

        public string Get() => Game.Instance.hmdLock.IsLocked.ToString().ToUpper();


        public void Set(string cmd, string value)
        {
            Game.Instance.hmdLock.SetActive(value.ToLower() == "true");
            OK();
        }

    }
}