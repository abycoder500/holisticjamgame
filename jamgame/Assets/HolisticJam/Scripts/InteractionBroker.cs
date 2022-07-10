using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{

    public class InteractionBroker : MonoBehaviour
    {

        [SerializeField] public event Action PerformInteraction;
        private List<IInteractionRequester> requesterList;


        void Awake()
        {
            requesterList = new List<IInteractionRequester>();
        }

        public void ConnectInteractionRequester(IInteractionRequester requester)
        {
            requesterList.Add(requester);
            requester.InteractionRequest += OnRequestInteraction;
        }

        public void DisconnectInteractionRequester(IInteractionRequester requester)
        {
            requesterList.Remove(requester);
            requester.InteractionRequest -= OnRequestInteraction;
        }

        public void OnRequestInteraction()
        {
            Debug.Log($"Interaction was requested, event received in broker");
            PerformInteraction?.Invoke();
        }

    }

}
