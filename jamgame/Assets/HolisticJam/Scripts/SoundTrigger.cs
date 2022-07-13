using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class SoundTrigger : MonoBehaviour
    {

        [SerializeField] AudioClip _clip;
        [SerializeField] AudioSource _source;

        void OnInteractionBroadcast()
        {
            if (_source == null || _clip == null) return; //Safeguard bail out

            _source.clip = _clip;

            if (!_source.isPlaying)
            {
                _source?.Play();
            }

        }
    }
}
