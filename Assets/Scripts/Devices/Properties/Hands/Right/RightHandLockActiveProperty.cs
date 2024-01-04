namespace Devices.Properties.Hands.Right
{
    public class RightHandLockActiveProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.RIGHT_HAND, Identifiers.LOCK, Identifiers.ACTIVE);

        public string Get() => Game.Instance.rightHandLock.IsLocked.ToString().ToUpper();


        public void Set(string cmd, string value)
        {
            value = value.Trim('<', '>', '=');
            Game.Instance.rightHandLock.SetActive(value.ToLower() == "true");
            OK();
        }

    }
}