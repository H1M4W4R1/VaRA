namespace Devices.Properties.Hands.Left
{
    public class LeftHandRotationProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.LEFT_HAND, Identifiers.ROTATION);

        public string Get()
        {
            var pos = Game.Instance.leftHandPosition.eulerAngles;
            return "<" + pos.x.S() + "," + pos.y.S() + "," + pos.z.S() + ">";
        }
            
        
    }
}