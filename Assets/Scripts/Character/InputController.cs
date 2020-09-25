using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastStandingSheep
{
    public sealed class InputController : IAwake, IUpdate
    {


        #region Fields

        private readonly GameContext _context;

        #endregion


        #region Properties

        public InputModel _inputModel { get; private set; }
        public CharacterModel _characterModel { get; private set; }


        #endregion


        #region ClassLifeCycle

        public InputController(GameContext context)
        {
            _context = context;
            _inputModel = new InputModel();
            _context.InputModel = _inputModel;
        }

        #endregion


        #region Methods

        public void OnAwake()
        {
            _characterModel = _context.CharacterModel;
            _inputModel.InputHorizontal = 0;
            _inputModel.InputVertical = 0;
            _inputModel.InputTotalHorizontal = 0;
            _inputModel.InputTotalVertical = 0;
            _inputModel.InputJump = 0;
            _inputModel.IsInputJump = false;
            _inputModel.IsInputMove = false;
            CharacterData.PlayerDie += _inputModel.OnDie;

        }

        public void Updating()
        {
            if (!_context.InputModel.IsDie)
            {
                _inputModel.InputHorizontal = Input.GetAxis("Horizontal");
                _inputModel.InputVertical = Input.GetAxis("Vertical");
                _inputModel.InputJump = Input.GetAxis("Jump");
                _inputModel.InputTotalHorizontal = GetTotalValue(_inputModel.InputHorizontal);
                _inputModel.InputTotalVertical = GetTotalValue(_inputModel.InputVertical);
                _inputModel.IsInputMove = (_inputModel.InputHorizontal != 0 || _inputModel.InputVertical != 0) ? true : false;
                _inputModel.IsInputJump = !_characterModel.CharacterData.IsGrounded;
            }
        }

        private float GetTotalValue(float value)
        {
            var totalValue = value > 0 ? 1 : value < 0 ? -1 : 0;
            return totalValue;
        }

        #endregion
    }

}