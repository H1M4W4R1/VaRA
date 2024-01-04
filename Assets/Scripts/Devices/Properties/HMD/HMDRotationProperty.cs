namespace Devices.Properties.HMD
{
    public class HMDRotationProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.HMD, Identifiers.ROTATION);

        public string Get()
        {
            var pos = Game.Instance.hmd.eulerAngles;
            return "<" + pos.x.S() + "," + pos.y.S() + "," + pos.z.S() + ">";
        }
            
        
    }
}