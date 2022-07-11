using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public abstract class InteractionTarget : MonoBehaviour
    {

        [SerializeField] protected InteractionBroker _broker;

        void Start()
        {
            if (_broker == null)
            {
                _broker = FindObjectOfType<InteractionBroker>();
            }
        }

        public abstract bool ActivateTargetAction();
    }
}
