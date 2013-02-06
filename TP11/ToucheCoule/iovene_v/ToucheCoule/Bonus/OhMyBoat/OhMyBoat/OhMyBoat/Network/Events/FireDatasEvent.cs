using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace OhMyBoat.Network.Events
{
    public class FireDatasEvent : NetworkEvent
    {
        public Point Coordinates { get; set; }

        public FireDatasEvent() : base(2)
        {
        }
    }
}
