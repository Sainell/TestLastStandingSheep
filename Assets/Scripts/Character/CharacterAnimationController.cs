using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastStandingSheep
{
    public sealed class CharacterAnimationController
    {
        #region Fields

        private int _idle;
        private int _walk;
        private int _jump;
        private int _die;

        #endregion


        #region Properties

        private Animator CharacterAnimator { get; set; }

        #endregion


        #region ClassLifeCycles

        public CharacterAnimationController(Animator characterAnimator)
        {
            CharacterAnimator = characterAnimator;
            Initialize();
        }

        #endregion

        public void Initialize()
        {
            _idle = Animator.StringToHash("SheepIdle");
            _walk = Animator.StringToHash("Sheep|Walk");
            _jump = Animator.StringToHash("");
            _die = Animator.StringToHash("Sheep|Die");
        }

        public void PlayIdleAnimation()
        {
            if (CharacterAnimator != null)
                CharacterAnimator.Play(_idle);
        }

        public void PlayWalkAnimation()
        {
            if (CharacterAnimator != null)
                CharacterAnimator.Play(_walk);
        }

        public void PlayJumpAnimation()
        {
            if (CharacterAnimator != null)
                CharacterAnimator.Play(_jump);
        }

        public void PlayDieAnimation()
        {
            if (CharacterAnimator != null)
                CharacterAnimator.Play(_die);
        }
    }
}