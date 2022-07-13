using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class InteractionBroadcasterTarget : InteractionTarget
    {
        override public bool ActivateTargetAction()
        {
            SendMessageOptions options = SendMessageOptions.DontRequireReceiver;

            BroadcastMessage(nameof(OnInteractionBroadcast), options);
            return true;
        }

        void OnInteractionBroadcast()
        {
            Debug.Log($"{name} broadcasted interaction, and tickled myself");
        }

    }
}
