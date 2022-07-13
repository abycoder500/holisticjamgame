using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class InteractionSliderDoorTarget : InteractionTarget
    {

        [SerializeField] Vector3 _moveAxisVector = new Vector3(1, 0, 0);
        [SerializeField] float _moveDistance;
        [SerializeField] float _moveSpeed;

        bool isCurrentlyMoving = false;

        Vector3 _startingPosition;
        Vector3 _targetPosition;

        private void Start()
        {
            _startingPosition = transform.position;
            _targetPosition = _moveDistance * _moveAxisVector + _startingPosition;
        }

        override public bool ActivateTargetAction()
        {
            if (isCurrentlyMoving) return false;

            StartCoroutine(CoMoveTheDoor());

            return true;
        }

        private IEnumerator CoMoveTheDoor()
        {

            WaitForEndOfFrame waitFrame = new WaitForEndOfFrame();
            isCurrentlyMoving = true;
            float lerpValue = 0f;

            while (lerpValue < 1f)
            {
                lerpValue += Time.deltaTime * _moveSpeed;
                transform.position = Vector3.Lerp(_startingPosition, _targetPosition, lerpValue);

                yield return waitFrame;
            }

            // Revert direction to go back on next run...
            _targetPosition = _startingPosition;
            _startingPosition = transform.position;
            _moveAxisVector *= -1;

            isCurrentlyMoving = false;
            yield return null;
        }
    }
}
