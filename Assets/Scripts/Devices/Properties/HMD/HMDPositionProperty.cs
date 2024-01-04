namespace Devices.Properties.HMD
{
    public class HMDPositionProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.HMD, Identifiers.POSITION);

        public string Get()
        {
            var pos = Game.Instance.hmd.position;
            return "<" + pos.x.S() + "," + pos.y.S() + "," + pos.z.S() + ">";
        }
            
        
    }
}