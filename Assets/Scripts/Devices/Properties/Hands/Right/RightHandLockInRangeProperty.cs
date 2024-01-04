namespace Devices.Properties.Hands.Right
{
    public class RightHandLockInRangeProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.RIGHT_HAND, Identifiers.LOCK, Identifiers.IS_OK);

        public string Get() => Game.Instance.rightHandLock.IsWithinDistance().ToString().ToUpper();

    }
}