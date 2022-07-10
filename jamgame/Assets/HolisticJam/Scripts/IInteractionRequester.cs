using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public interface IInteractionRequester
    {
        public event Action InteractionRequest;

        InteractionBroker Broker { get; }
    }
}
