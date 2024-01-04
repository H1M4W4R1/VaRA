namespace Devices.Properties.Hands.Left
{
    public class LeftHandLockInRangeProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.LEFT_HAND, Identifiers.LOCK, Identifiers.IS_OK);

        public string Get() => Game.Instance.leftHandLock.IsWithinDistance().ToString().ToUpper();

    }
}