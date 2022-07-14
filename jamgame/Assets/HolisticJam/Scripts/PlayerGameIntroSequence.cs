using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class PlayerGameIntroSequence : MonoBehaviour
    {
        [Tooltip("How long to wait until the intro sequence starts")]
        [SerializeField] float _introDelay = 5f;


        [Tooltip("Drop global background light here")]
        [SerializeField] Light _light;

        [Tooltip("Lightlevels at the start of the game and at the end of the intro sequence")]

        [SerializeField] [Range(0, 1)] float _startLightLevel;
        [SerializeField] [Range(0, 10)] float _introFinishedLightLevel;
        [SerializeField] float _lightingDuration;

        float _dimmingLerp = 0f;
        float _delayTimer = 0f;

        void Start()
        {
            _light.intensity = _startLightLevel;
        }

        void Update()
        {
            if (_delayTimer < _introDelay)
            {
                _delayTimer += Time.deltaTime;
                return;
            }

            if (_dimmingLerp <= 1f)
            {
                _dimmingLerp += Time.deltaTime;
                _light.intensity = Mathf.Lerp(_startLightLevel, _introFinishedLightLevel, _dimmingLerp);
            }
        }
    }
}
