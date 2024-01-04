namespace Devices.Properties.Hands.Right
{
    public class RightHandLockDistanceProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.RIGHT_HAND, Identifiers.LOCK, Identifiers.DISTANCE);

        public string Get() => Game.Instance.rightHandLock.GetDistance().S();


    }
}