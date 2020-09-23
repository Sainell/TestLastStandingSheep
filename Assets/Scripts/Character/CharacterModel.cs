using UnityEngine;
using Cinemachine;

namespace LastStandingSheep
{
    public sealed class CharacterModel
    {
        #region Properties

        public GameObject Character { get; private set; }
        public CharacterData CharacterData { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public GameObject MainCamera { get; private set; }
        public CinemachineVirtualCamera VirtualCamera {get; private set;}
        public Animator Animator { get; private set; }
        
        
        
        #endregion


        #region ClassLifeCycle

        public CharacterModel(GameObject prefab, CharacterData characterData, GameObject mainCamera, CinemachineVirtualCamera virtualCamera)
        {
            Character = prefab;
            CharacterData = characterData;
            Rigidbody = prefab.GetComponent<Rigidbody>();
            characterData.CharacterModel = this;
            MainCamera = mainCamera;
            VirtualCamera = virtualCamera;
            Animator = prefab.GetComponent<Animator>();
        }

        #endregion

        #region Metods

        public void Execute()
        {
            CharacterData.Updating();
        }

        #endregion
    }
}