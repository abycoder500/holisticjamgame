using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class InteractionBroadcasterTarget : InteractionTarget
    {
        [SerializeField] float _broadcastDelay = 0f;

        override public bool ActivateTargetAction()
        {
            Invoke(nameof(PerformBroadcast), _broadcastDelay);
            return true;
        }

        private void PerformBroadcast()
        {
            SendMessageOptions options = SendMessageOptions.DontRequireReceiver;
            BroadcastMessage(nameof(OnInteractionBroadcast), options);
        }

        void OnInteractionBroadcast()
        {
            Debug.Log($"{name} broadcasted interaction, and tickled myself");
        }

    }
}
