using UnityEngine;


namespace LastStandingSheep
{
    public sealed class SheepBotModel
    {
        #region Properties

        public GameObject SheepBot { get; private set; }
        public SheepBotData SheepBotData { get; private set; }


        #endregion


        #region ClassLifeCycle

        public SheepBotModel(GameObject prefab, SheepBotData sheepBotData)
        {
            SheepBot = prefab;
            SheepBotData = sheepBotData;
            SheepBotData.SheepBotModel = this;
        }

        #endregion


        #region Methods

        public void Execute()
        {
            SheepBotData.Updating();
        }

        #endregion
    }
}