using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastStandingSheep
{
    public class PlatformController : IAwake, IUpdate
    {
        #region Fields

        private readonly GameContext _context;

        #endregion


        #region Properties

        public bool isPlayerDie { get; private set; }

        #endregion


        #region ClassLifeCycle

        public PlatformController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region Methods

        public void OnAwake()
        {
            var PlatformData = Data.PlatformData;
            // GameObject instance = GameObject.Find("Platform");
            GameObject ocean = GameObject.Find("Ocean");
            GameObject instance = GameObject.Instantiate(PlatformData.PlatformStruct.Prefab, PlatformData.PlatformStruct.SpawnPoint, Quaternion.identity);
            PlatformModel platform = new PlatformModel(instance, PlatformData, ocean);
            _context.PlatformModel = platform;
            CharacterData.PlayerDie += OnCheckPlayer;
        }

        public void Updating()
        {
            if (!isPlayerDie)
            {
                _context.PlatformModel.Execute();
            }
        }

        private void OnCheckPlayer()
        {
            isPlayerDie = true;
        }

        #endregion

    }
}