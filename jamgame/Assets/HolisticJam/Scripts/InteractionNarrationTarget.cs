using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class InteractionNarrationTarget : InteractionTarget
    {
        [SerializeField] private Narration narration;
        [SerializeField] bool isRepeatable;

        public override bool ActivateTargetAction()
        {
            Debug.Log($"{name} starting {narration.name}");
            NarrationManager.PlayNarration(narration);

            if (!isRepeatable)
            {
                gameObject.SetActive(false);
            }
            return true;
        }
    }
}
