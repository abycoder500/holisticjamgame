using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HolisticJam
{
    public class UITestHandler : MonoBehaviour
    {

        [field: SerializeField] public InteractionBroker Broker { get; protected set; }
        [SerializeField] TMP_Text _textField;

        void Start()
        {
            if (Broker == null)
            {
                Broker = FindObjectOfType<InteractionBroker>();
            }
            Broker.UpdateUI += OnUpdateUI;
        }


        void OnUpdateUI(string stringVal, bool showText)
        {
            _textField.enabled = showText;
            if (showText)
            {
                _textField.text = stringVal;
            }

        }

    }
}
