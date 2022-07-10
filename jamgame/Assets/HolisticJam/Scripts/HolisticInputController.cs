using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using StarterAssets;
#endif

namespace HolisticJam
{
    public class HolisticInputController : StarterAssetsInputs
    {
        [Header("Holistic Input Settings")]
        public bool interaction;


#if ENABLE_INPUT_SYSTEM //&& STARTER_ASSETS_PACKAGES_CHECKED
        public void OnInteract(InputValue value)
        {
            InteractInput(value.isPressed);
        }

        public void OnQuit(InputValue value)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }


#endif
        public void InteractInput(bool newInteractionState)
        {
            interaction = newInteractionState;
        }

    }
}
