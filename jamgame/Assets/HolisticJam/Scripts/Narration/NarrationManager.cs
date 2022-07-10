using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HolisticJam
{

    public class NarrationManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        
        public static NarrationManager instance;

        public NarrationSubtitleEvent onNarrationPlayed;
        public UnityEvent onNarrationPlayEnded;
        public UnityEvent onNarrationStarted;

        [SerializeField] private DisplayModule _displayer;
        [SerializeField] private ActionEvent _messageDelegator;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void StartNarrationRoutine(Narration narration)
        {
            StartCoroutine(NarrationRoutine(narration));
        }

        private IEnumerator NarrationRoutine(Narration narration)
        {
            onNarrationStarted?.Invoke();
            _source.clip = narration._clip;
            _source.Play(); 
            StartCoroutine(SubtitleRoutine(narration._subtitles));
            yield return new WaitUntil(() => !_source.isPlaying);

            onNarrationPlayEnded?.Invoke();
            narration.onNarrationCompleted?.Invoke();
            
            if(narration.continuation != null)
                StartCoroutine(NarrationRoutine(narration.continuation));
        }

        private IEnumerator SubtitleRoutine(Subtitle[] subs, int subIndex = 0)
        {
            _displayer.Display(subs[subIndex]._text);
            if (subIndex + 1 < subs.Length)
            {
                yield return new WaitUntil(() => _source.time >= subs[subIndex + 1]._time);
                StartCoroutine(SubtitleRoutine(subs, subIndex + 1));
            }
        }

        private IEnumerator ActionRoutine(ActionPoint[] actions, int current)
        {
            yield return new WaitUntil(() => _source.time >= actions[current]._point);
            _messageDelegator.Raise(actions[current]._action);
        }

        public static void PlayNarration(Narration narration)
        {
            instance.StartNarrationRoutine(narration);
        }
    }

    [System.Serializable]
    public class NarrationSubtitleEvent: UnityEvent<string> { }
}


