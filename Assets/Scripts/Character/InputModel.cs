using System;
using UnityEngine;

namespace LastStandingSheep
{
    public class InputModel
    {
        #region Fields

        public float InputHorizontal;
        public float InputVertical;
        public float InputTotalHorizontal;
        public float InputTotalVertical;
        public float InputJump;

        private bool _isInputMove;
        private bool _isInputJump;

        #endregion


        #region Events

        public static Action OnJump;
        public static Action OnWalk;
        public static Action OnDie;
        public static Action OnIdle;


        public bool IsInputMove
        {
            get
            {
                return _isInputMove;
            }
            set
            {
                if (_isInputMove != value)
                {
                    _isInputMove = value;

                    if (_isInputMove)
                    {
                        // event move start
                        OnWalk?.Invoke();
                    }
                    else
                    {
                        OnIdle?.Invoke();
                    }
                }
            }
        }

        public bool IsInputJump
        {
            get
            {
                return _isInputJump;
            }
            set
            {
                if (_isInputJump != value)
                {
                    _isInputJump = value;

                    if (_isInputJump)
                    {
                        //event start jump
                        OnJump?.Invoke();
                    }
                    else
                    {
                        //event stop jump
                        OnIdle?.Invoke();
                    }
                }
            }
        }

        #endregion

    }
}