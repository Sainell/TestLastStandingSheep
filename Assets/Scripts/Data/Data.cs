using System.IO;
using UnityEngine;

namespace LastStandingSheep
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data")]
    public class Data : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _characterDataPath;
        [SerializeField] private string _platformDataPath;

        private static Data _instance;
        private static CharacterData _characterData;
        private static PlatformData _platformData;

        #endregion


        #region Properties

        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<Data>("Data/" + typeof(Data).Name);
                }
                return _instance;
            }
        }

        public static CharacterData CharacterData
        {
            get
            {
                if (_characterData == null)
                {
                    _characterData = Load<CharacterData>("Data/" + Instance._characterDataPath);
                }
                return _characterData;
            }
        }

        public static PlatformData PlatformData
        {
            get
            {
                if (_platformData == null)
                {
                    _platformData = Load<PlatformData>("Data/" + Instance._platformDataPath);
                }
                return _platformData;
            }
        }


        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

        #endregion
    }
}