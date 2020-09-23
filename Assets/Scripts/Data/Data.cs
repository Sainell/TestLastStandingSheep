using System.IO;
using UnityEngine;

namespace LastStandingSheep
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data")]
    public class Data : ScriptableObject
    {
        #region Fields

        // [SerializeField] private string _sphereDataPath; example
        [SerializeField] private string _characterDataPath;

        private static Data _instance;
        // private static SphereData _sphereData;  example
        private static CharacterData _characterData;

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
        // example:
        //public static SphereData SphereData
        //{
        //    get
        //    {
        //        if (_sphereData == null)
        //        {
        //            _sphereData = Load<SphereData>("Data/" + Instance._sphereDataPath);
        //        }
        //        return _sphereData;
        //    }
        //}
        //}
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


            #endregion


            #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

        #endregion
    }
}