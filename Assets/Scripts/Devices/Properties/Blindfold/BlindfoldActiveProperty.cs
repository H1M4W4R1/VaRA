namespace Devices.Properties.Blindfold
{
    public class BlindfoldActiveProperty : DeviceProperty, IGettableDeviceProperty, ISettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.BLINDFOLD, Identifiers.ACTIVE);

        public void Set(string cmd, string value)
        {
            value = value.Trim('<', '>', '=');
            Game.Instance.blindfold.SetActive(value.ToLower() == "true");
            OK();
        }

        public string Get() => Game.Instance.blindfold.IsActive.ToString().ToUpper();
            
        
    }
}