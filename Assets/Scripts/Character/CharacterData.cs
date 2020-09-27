using System;
using UnityEngine;

namespace LastStandingSheep
{
    [CreateAssetMenu(fileName = "NewData", menuName = "CreateData/CharacterData", order = 0)]
    public sealed class CharacterData : ScriptableObject
    {
        #region Fields

        public static Action PlayerDie;

        private const float CAMERA_ANGLE = 90f;
        private const float GROUND_CHECK_DISTANCE = 0.2f;

        public float MoveSpeed;
        public float JumpForce;
        public float RotationSpeed;

        public CharacterModel CharacterModel;
        public InputModel InputModel;
        [SerializeField]
        public CharacterStruct CharacterStruct;

        private Animator _animator;
        private float _totalHorizontal;
        private float _totalVertical;
        private float _jump;
        private float _addDirection;
        private float _currentAngleValue;
        private Vector3 _groundHit;
        private bool _isWin;
        private bool _isDie;

        #endregion


        #region Properties

        public bool IsMove { get; private set; }
        public bool IsGrounded { get; private set; }

        #endregion


        #region Methods

        public void Updating()
        {
            _totalHorizontal = InputModel.InputHorizontal;
            _totalVertical = InputModel.InputVertical;
            _jump = InputModel.InputJump;
            IsMove = InputModel.IsInputMove;
            InputCheck(CheckMoves());
            Jump();
            IsGrounded = CheckGround(CharacterModel.Character.transform.position, GROUND_CHECK_DISTANCE, out _groundHit);
        }

        private void InputCheck(float moveAxis)
        {
            Movement(moveAxis);
            TurnAngleByCamera();
        }
        private float CheckMoves()
        {
            if (_totalHorizontal != 0 || _totalVertical != 0)
            {
                return 1f;
            }

            else
            {
                return 0f;
            }
        }

        private void Movement(float input)
        {     
           CharacterModel.Rigidbody.AddForce(CharacterModel.Character.transform.forward * input * MoveSpeed, ForceMode.Impulse);
        }

        private void TurnAngleByCamera()
        {
            if (_totalVertical > 0)
            {
                _addDirection = _totalHorizontal * CAMERA_ANGLE;
            }
            if (_totalVertical < 0)
            {
                _addDirection = _totalHorizontal * -CAMERA_ANGLE - (CAMERA_ANGLE * 2);
            }

            var CurrentDirecton = CharacterModel.Character.transform.localEulerAngles.y;
            var TargetDirection = CharacterModel.MainCamera.transform.localEulerAngles.y + _addDirection;
            var CurrentAngle = Mathf.SmoothDampAngle(CurrentDirecton, TargetDirection, ref _currentAngleValue, RotationSpeed);
            if (IsMove)
            {
                CharacterModel.Character.transform.localRotation = Quaternion.Euler(0, CurrentAngle, 0);
            }
        }

        private void Jump()
        {
            if (_jump > 0)
            {
                if (IsGrounded)
                {
                    CharacterModel.Rigidbody.AddForce(Vector3.up * JumpForce);
                }
            }
        }

        public void ResetDieState()
        {
            _isDie = false;
            _isWin = false;
        }

        public bool CheckGround(Vector3 position, float distanceRay, out Vector3 hitPoint)
        {
            hitPoint = Vector3.zero;
            bool isHit = Physics.Raycast(position, Vector3.down, out RaycastHit hit, distanceRay);
            if (isHit)
            {
                hitPoint = hit.point;
            }
            return isHit;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!_isWin)
            {
                if (!_isDie)
                {
                    if (other.CompareTag("Player"))
                    {
                        _isDie = true;
                        PlayerDie?.Invoke();
                    }
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
        }

        public void OnPlayerWin()
        {
            _isWin = true;
        }

        #endregion
    }
}