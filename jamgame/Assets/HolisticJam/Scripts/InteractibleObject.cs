using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class InteractibleObject : MonoBehaviour
    {
        // needs "field:" to be actually accessible in inspector
        [field: SerializeField] public InteractionBroker Broker { get; protected set; }

        [SerializeField] string _triggerEnteredString = "Proximity";
        [SerializeField] float _triggerEnteredDelay = 10f;
        [SerializeField] string _triggerLeftString = "";
        [SerializeField] float _triggerLeftDelay = 5f;

        void Start()
        {
            if (Broker == null)
            {
                Broker = FindObjectOfType<InteractionBroker>();
            }

        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{other.name} entered the trigger area of {name}");
            if (other.GetComponent<MonoBehaviour>() is IInteractionRequester)
            {
                Debug.Log($"{name} in proximity to interactor");
                Broker.PerformInteraction += OnPerformInteraction;
                Broker.UISendUpdate(_triggerEnteredString, true);
                if (_triggerEnteredDelay > 0)
                {
                    Invoke(nameof(DelayedUIUpdate), _triggerLeftDelay);
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log($"{other.name} left the trigger area of {name}");
            if (other.GetComponent<MonoBehaviour>() is IInteractionRequester)
            {
                Broker.PerformInteraction -= OnPerformInteraction;
                if (_triggerLeftString.Length == 0)
                {
                    Broker.UISendUpdate("dummy", false);
                }
                else
                {
                    Broker.UISendUpdate(_triggerLeftString, true);
                    if (_triggerLeftDelay > 0)
                    {
                        Invoke(nameof(DelayedUIUpdate), _triggerLeftDelay);
                    }
                }

            }
        }

        void DelayedUIUpdate()
        {
            Broker.UISendUpdate("dummy", false);
        }


        void OnPerformInteraction()
        {
            Debug.Log($"{name} performs interaction");
            Broker.UISendUpdate("Ooomph. You pushed the block upwards.", true);
            Invoke(nameof(DelayedUIUpdate), _triggerLeftDelay);
            // This is just some dummy action to give some feedback in the playground scene...
            Vector3 _pos = transform.position;
            _pos.y++;
            transform.position = _pos;
        }
    }
}
