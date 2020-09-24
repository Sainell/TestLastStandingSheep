using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LastStandingSheep
{
    public class SheepBotController : IAwake, IUpdate
    {
        #region Fields

        private readonly GameContext _context;

        #endregion


        #region Properties



        #endregion


        #region ClassLifeCycle

        public SheepBotController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region Methods

        public void OnAwake()
        {
            var SheepBotData = Data.SheepBotData;
            for (int i = 0; i < SheepBotData.SheepCount; i++)
            {
                GameObject instance = GameObject.Instantiate(SheepBotData.SheepBotStruct.Prefab, SheepBotData.SpawnPoints[i], Quaternion.identity);
                SheepBotModel sheepBot = new SheepBotModel(instance, SheepBotData);
                _context.SheepBotModelList.Add(sheepBot);
            }
        }

        public void Updating()
        {
           foreach (var sheepBot in _context.SheepBotModelList)
            {
                sheepBot.Execute();
            }
        }

        #endregion
    }
}