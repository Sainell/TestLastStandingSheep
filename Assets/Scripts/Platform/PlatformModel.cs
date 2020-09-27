using UnityEngine;


namespace LastStandingSheep
{
    public sealed class PlatformModel
    {
        #region Properties

        public GameObject Platform { get; private set; }
        public GameObject Ocean { get; private set; }
        public PlatformData PlatformData { get; private set; }

        #endregion


        #region ClassLifeCycle

        public PlatformModel(GameObject prefab, PlatformData platformData, GameObject ocean)
        {
            Platform = prefab;
            Ocean = ocean;
            PlatformData = platformData;
            PlatformData.PlatformModel = this;
        }

        #endregion


        #region Methods

        public void Execute()
        {
            PlatformData.Updating();
        }

        #endregion
    }
}