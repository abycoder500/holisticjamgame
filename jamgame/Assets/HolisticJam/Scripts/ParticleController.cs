using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{

    // Just a very simple sample script to put on a particle system object
    // that will used to broadcast the interaction to that is received on the
    // InteractionBroadcastTarget script.

    public class ParticleController : MonoBehaviour
    {
        ParticleSystem _ps;

        private void Awake()
        {
            _ps = GetComponent<ParticleSystem>();
        }

        void OnInteractionBroadcast()
        {
            if (!_ps.isPlaying)
            {
                _ps.Play();
            }
        }

    }
}
