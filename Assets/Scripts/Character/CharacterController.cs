using Cinemachine;
using UnityEngine;

namespace LastStandingSheep
{

    public class CharacterController: IUpdate, IAwake
    {
        #region Fields

        private readonly GameContext _context;

        #endregion


        #region ClassLifeCycle

        public CharacterController(GameContext context)
        {
            _context = context;
           
        }

        #endregion

        public void OnAwake()
        {
            var CharacterData = Data.CharacterData;
            
            GameObject instance = GameObject.Instantiate(CharacterData.CharacterStruct.Prefab, CharacterData.CharacterStruct.SpawnPosition, Quaternion.identity);
            var mainCamera = GameObject.Find("Camera");//
            var virtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>(); //
            virtualCamera.Follow = instance.transform;
            virtualCamera.LookAt = instance.transform;
            CharacterModel character = new CharacterModel(instance, CharacterData, mainCamera, virtualCamera);
            _context.CharacterModel = character;
            CharacterData.InputModel = _context.InputModel;

        }

        public void Updating()
        {
            _context.CharacterModel.Execute();
        }
    }
}