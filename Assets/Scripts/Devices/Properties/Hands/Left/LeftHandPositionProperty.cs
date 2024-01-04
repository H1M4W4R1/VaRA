namespace Devices.Properties.Hands.Left
{
    public class LeftHandPositionProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.LEFT_HAND, Identifiers.POSITION);

        public string Get()
        {
            var pos = Game.Instance.leftHandPosition.position;
            return "<" + pos.x.S() + "," + pos.y.S() + "," + pos.z.S() + ">";
        }                    
        
    }
}