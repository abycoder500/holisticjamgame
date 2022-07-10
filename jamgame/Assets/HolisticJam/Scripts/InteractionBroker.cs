using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{

    public class InteractionBroker : MonoBehaviour
    {

        [SerializeField] public event Action PerformInteraction;
        [SerializeField] public event Action<string, bool> UpdateUI;
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

        // if `showText` is false the UI is supposed to hide the element and will
        // ignore the `stringValue`.
        public void UISendUpdate(string stringValue, bool showText)
        {
            Debug.Log($"Broker.UISendUpdate for '{stringValue}' [{showText}]");
            UpdateUI?.Invoke(stringValue, showText);
        }

    }

}
