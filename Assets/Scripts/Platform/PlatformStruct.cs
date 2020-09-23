using System;
using UnityEngine;


namespace LastStandingSheep
{
    [Serializable]
    public struct PlatformStruct
    {
        public GameObject Prefab;
        public Vector3 SpawnPoint;
        public Vector3[] SpawnPoints;
    }
}