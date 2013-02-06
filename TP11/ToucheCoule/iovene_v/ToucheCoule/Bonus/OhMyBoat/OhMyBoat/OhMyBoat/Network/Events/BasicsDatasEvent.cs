using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OhMyBoat.Network.Events
{
    public class BasicsDatasEvent : NetworkEvent
    {
        public string Enemy { get; set; }
        public Maps.Map EnemyMap { get; set; }

        public BasicsDatasEvent() : base(1)
        {
        }
    }
}
