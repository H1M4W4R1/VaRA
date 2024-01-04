namespace Devices.Properties.Hands.Right
{
    public class RightHandPositionProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.RIGHT_HAND, Identifiers.POSITION);

        public string Get()
        {
            var pos = Game.Instance.rightHandPosition.position;
            return "<" + pos.x.S() + "," + pos.y.S() + "," + pos.z.S() + ">";
        }
            
        
    }
}