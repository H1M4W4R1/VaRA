using System.Numerics;
using UnityEngine;

namespace Devices.Properties.Blindfold
{
    public class BlindfoldColorProperty : DeviceProperty, IGettableDeviceProperty, ISettableDeviceProperty
    {

        public override string Identifier => Identifiers.NewId(Identifiers.BLINDFOLD, Identifiers.COLOR);

        public void Set(string cmd, string value)
        {
            var rgba = value.V();
            if (rgba == null)
            {
                ERROR(ERROR_INVALID_VALUE);
                return;
            }

            if (rgba.Count != 4)
            {
                ERROR(ERROR_INVALID_VALUE);
                return;
            }


            Game.Instance.blindfold.SetColor(new Color(rgba[0], rgba[1], rgba[2], rgba[3]));
            OK();
        }

        public string Get()
        {
            var c = Game.Instance.blindfold.GetColor();
            return "<" + c.r.S() + "," + c.g.S() + "," + c.b.S() + "," + c.a.S() + ">";
        }
    }
}