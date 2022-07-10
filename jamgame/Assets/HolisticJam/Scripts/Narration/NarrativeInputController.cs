using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class NarrativeInputController : MonoBehaviour
{
    public void OnNarrationSkip(CallbackContext context)
    {
        if (context.performed) return;

        //Do dome stuff
    }
}
