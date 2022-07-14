using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class InteractionBroadcastNarrationInvoker : MonoBehaviour
    {
        [SerializeField] private Narration narration;
        [SerializeField] bool isRepeatable;

        void OnInteractionBroadcast()
        {
            Debug.Log($"Broadcast to {name} is starting {narration.name}");
            NarrationManager.PlayNarration(narration);

            if (!isRepeatable)
            {
                gameObject.SetActive(false);
            }

        }

    }
}
