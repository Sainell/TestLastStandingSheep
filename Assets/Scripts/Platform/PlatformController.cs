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
            GameObject instance = GameObject.Instantiate(PlatformData.PlatformStruct.Prefab, PlatformData.PlatformStruct.SpawnPoint, Quaternion.identity);
            PlatformModel platform = new PlatformModel(instance, PlatformData);
            _context.PlatformModel = platform;
        }

        public void Updating()
        {
            _context.PlatformModel.Execute();
        }

        #endregion

    }
}