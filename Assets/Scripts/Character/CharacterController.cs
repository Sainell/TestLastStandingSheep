using Cinemachine;
using UnityEngine;

namespace LastStandingSheep
{

    public class CharacterController : IUpdate, IAwake
    {
        #region Fields

        private readonly GameContext _context;
        private CharacterAnimationController _animationController;

        #endregion


        #region Properties

        public InputModel InputModel { get; private set; }

        #endregion


        #region ClassLifeCycle

        public CharacterController(GameContext context)
        {
            _context = context;
        }

        #endregion

        public void OnAwake()
        {
            var mainCamera = GameObject.Find("Camera");//
            var virtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>(); //

            var CharacterData = Data.CharacterData;
            GameObject instance = GameObject.Instantiate(CharacterData.CharacterStruct.Prefab, CharacterData.CharacterStruct.SpawnPosition, Quaternion.identity);
            virtualCamera.Follow = instance.transform;
            virtualCamera.LookAt = instance.transform;

            CharacterModel character = new CharacterModel(instance, CharacterData, mainCamera, virtualCamera);
            _context.CharacterModel = character;
            InputModel = _context.InputModel;
            CharacterData.InputModel = InputModel;
            _animationController = new CharacterAnimationController(character.Animator);

            InputModel.OnIdle += _animationController.PlayIdleAnimation;
            InputModel.OnWalk += _animationController.PlayWalkAnimation;
            InputModel.OnJump += _animationController.PlayDieAnimation;
            CharacterData.PlayerDie += _animationController.PlayDieAnimation;

        }

        public void Updating()
        {
            _context.CharacterModel.Execute();
        }
    }
}