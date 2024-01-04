namespace Devices.Properties.Hands.Right
{
    public class RightHandRotationProperty : DeviceProperty, IGettableDeviceProperty
    {
        public override string Identifier => Identifiers.NewId(Identifiers.RIGHT_HAND, Identifiers.ROTATION);

        public string Get()
        {
            var pos = Game.Instance.rightHandPosition.eulerAngles;
            return "<" + pos.x.S() + "," + pos.y.S() + "," + pos.z.S() + ">";
        }
            
        
    }
}