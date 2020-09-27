using UnityEngine;


namespace LastStandingSheep
{
    [CreateAssetMenu(fileName = "NewData", menuName = "CreateData/SettingsData", order = 0)]
    public sealed class GameSettingsData : ScriptableObject
    {
        #region Fields

        public int Win;
        public int Lost;
        public bool isSound;
        public bool isMusic;
        public bool isVibro;

        #endregion
    }
}