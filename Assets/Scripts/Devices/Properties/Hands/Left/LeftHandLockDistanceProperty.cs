namespace Devices.Properties.Hands.Left
{
    public class LeftHandLockDistanceProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.LEFT_HAND, Identifiers.LOCK, Identifiers.DISTANCE);

        public string Get() => Game.Instance.leftHandLock.GetDistance().S();


    }
}