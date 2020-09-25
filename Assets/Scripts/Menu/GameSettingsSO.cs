using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LastStandingSheep
{
    [CreateAssetMenu(fileName = "NewData", menuName = "CreateData/SettingsData", order = 0)]
    public sealed class GameSettingsSO : ScriptableObject
    {
        public int Win;
        public int Lost;
        public bool isSound;
        public bool isMusic;
        public bool isVibro;
    }
}