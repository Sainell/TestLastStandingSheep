using System;


namespace LastStandingSheep
{
    public sealed class InputModel
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


        #region Properties

        public bool IsDie { get; private set; }

        #endregion


        #region Events

        public static Action OnJump;
        public static Action OnWalk;
        public static Action OnIdle;

        #endregion


        #region Methods

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
                        if (!IsDie)
                        {
                            OnWalk?.Invoke();
                        }
                    }
                    else
                    {
                        if (!IsDie)
                        {
                            OnIdle?.Invoke();
                        }
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
                        if (!IsDie)
                        {
                            OnJump?.Invoke();
                        }
                    }
                    else
                    {
                        if (!IsDie)
                        {
                            OnIdle?.Invoke();
                        }
                    }
                }
            }
        }

        public void OnDie()
        {
            IsDie = true;
        }

        public void Jump(float jump)
        {
            InputJump = jump;
        }

        #endregion

    }
}