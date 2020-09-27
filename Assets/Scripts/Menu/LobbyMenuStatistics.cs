using UnityEngine;
using UnityEngine.UI;


namespace LastStandingSheep
{
    public sealed class LobbyMenuStatistics : MonoBehaviour
    {
        #region Fields

        private Text _winCount;
        private Text _lostCount;
        #endregion


        #region Properties

        public GameSettingsData GameSettingsData { get; private set; }

        #endregion


        #region UnityMethods

        private void Start()
        {
            _winCount = transform.Find("Image/WinCount").gameObject.GetComponent<Text>();
            _lostCount = transform.Find("Image/LostCount").gameObject.GetComponent<Text>();
            GameSettingsData = Data.GameSettingsData;
            UpdateStatistic();
        }

        #endregion


        #region Methods

        private void UpdateStatistic()
        {
            _winCount.text = GameSettingsData.Win.ToString();
            _lostCount.text = GameSettingsData.Lost.ToString();
        }

        #endregion
    }
}