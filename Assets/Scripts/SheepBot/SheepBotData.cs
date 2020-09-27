using UnityEngine;


namespace LastStandingSheep
{
    [CreateAssetMenu(fileName = "NewData", menuName = "CreateData/SheepBotData", order = 0)]
    public sealed class SheepBotData : ScriptableObject
    {
        [SerializeField]
        public SheepBotStruct SheepBotStruct;
        public SheepBotModel SheepBotModel;

        public int SheepCount;
        public Vector3[] SpawnPoints;

        public void Updating()
        {
        }
    }
}