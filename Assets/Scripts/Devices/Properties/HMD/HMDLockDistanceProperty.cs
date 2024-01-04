namespace Devices.Properties.HMD
{
    public class HMDLockDistanceProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.HMD, Identifiers.LOCK, Identifiers.DISTANCE);


        public string Get() => Game.Instance.hmdLock.GetDistance().S();


    }
}