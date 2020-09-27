using UnityEngine;


namespace LastStandingSheep
{
    public sealed class InputController : IAwake, IUpdate
    {
        #region Fields

        private readonly GameContext _context;

        #endregion


        #region Properties

        public InputModel InputModel { get; private set; }
        public CharacterModel CharacterModel { get; private set; }
        public FixedJoystick Joystick { get; private set; }

        #endregion


        #region ClassLifeCycle

        public InputController(GameContext context)
        {
            _context = context;
            InputModel = new InputModel();
            _context.InputModel = InputModel;
        }

        #endregion


        #region Methods

        public void OnAwake()
        {
            CharacterModel = _context.CharacterModel;
            InputModel.InputHorizontal = 0;
            InputModel.InputVertical = 0;
            InputModel.InputTotalHorizontal = 0;
            InputModel.InputTotalVertical = 0;
            InputModel.InputJump = 0;
            InputModel.IsInputJump = false;
            InputModel.IsInputMove = false;
            Joystick = GameObject.FindObjectOfType<FixedJoystick>();
            CharacterData.PlayerDie += InputModel.OnDie;
            JumpButton.JumpButtonEvent += InputModel.Jump;

        }

        public void Updating()
        {
            if (!_context.InputModel.IsDie)
            {
//#if UNITY_EDITOR
//#endif
//#if UNITY_ANDROID
//#endif
                //InputModel.InputHorizontal = Input.GetAxis("Horizontal");
                //InputModel.InputVertical = Input.GetAxis("Vertical");
                // InputModel.InputJump = Input.GetAxis("Jump");
                InputModel.InputHorizontal = Joystick.Horizontal;
                InputModel.InputVertical = Joystick.Vertical;

                InputModel.IsInputMove = (InputModel.InputHorizontal != 0 || InputModel.InputVertical != 0) ? true : false;
                InputModel.IsInputJump = !CharacterModel.CharacterData.IsGrounded;
            }
        }

        #endregion
    }
}