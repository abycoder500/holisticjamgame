using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{

    public class NarrationInvoker : MonoBehaviour
    {
        [SerializeField] private Narration narration;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            NarrationManager.PlayNarration(narration);
            gameObject.SetActive(false);
        }
    }
}