namespace Devices.Properties.Hands.Left
{
    public class LeftHandLockActiveProperty : DeviceProperty, ISettableDeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.LEFT_HAND, Identifiers.LOCK, Identifiers.ACTIVE);

        public string Get() => Game.Instance.leftHandLock.IsLocked.ToString().ToUpper();


        public void Set(string cmd, string value)
        {
            value = value.Trim('<', '>', '=');
            Game.Instance.leftHandLock.SetActive(value.ToLower() == "true");
            OK();
        }

    }
}