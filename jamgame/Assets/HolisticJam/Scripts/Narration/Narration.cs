using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HolisticJam
{
    [CreateAssetMenu(menuName = "NarrationSystem/Narration")]
    public class Narration : ScriptableObject
    {
        public AudioClip _clip;
        public Subtitle[] _subtitles;
        public Narration continuation;
        public ActionPoint[] actionPoints;

        public delegate void NarrationEvents();
        public NarrationEvents onNarrationCompleted;

        
    }

    [System.Serializable]
    public struct Subtitle
    {
        public string _text;
        public float _time;
    }

    [System.Serializable]
    public struct ActionPoint
    {
        public float _point;
        public string _action;
    }
}