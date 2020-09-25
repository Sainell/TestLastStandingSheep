using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastStandingSheep
{
    public sealed class PlatformModel
    {
        #region Properties

        public GameObject Platform { get; private set; }
        public GameObject Ocean { get; private set; }
        public PlatformData PlatformData { get; private set; }
        public Animator Animator { get; private set; } // need?

        #endregion


        #region ClassLifeCycle

        public PlatformModel(GameObject prefab, PlatformData platformData, GameObject ocean)
        {
            Platform = prefab;
            Ocean = ocean;
            PlatformData = platformData;
            PlatformData.PlatformModel = this;
            Animator = prefab.GetComponent<Animator>();
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