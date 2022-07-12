using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class InteractionMessageTarget : InteractionTarget
    {
        [SerializeField] string _message = "Boom!";
        [SerializeField] float _messageDelay = 5f;


        override public bool ActivateTargetAction()
        {
            if (_broker == null) return false;

            _broker?.UISendUpdate(_message, true);
            Invoke(nameof(ClearMessage), _messageDelay);
            return true;
        }

        void ClearMessage()
        {
            _broker?.UISendUpdate(_message, false);
        }

    }
}
