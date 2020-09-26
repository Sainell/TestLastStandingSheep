using UnityEngine;
using UnityEngine.UI;

namespace LastStandingSheep
{
    public sealed class LobbyMenuStatistics : MonoBehaviour
    {
        private Text _winCount;
        private Text _lostCount;

        #region Properties

        public GameSettingsData GameSettingsData { get; private set; }

        #endregion

        private void Start()
        {
            _winCount = transform.Find("Image/WinCount").gameObject.GetComponent<Text>();
            _lostCount = transform.Find("Image/LostCount").gameObject.GetComponent<Text>();
            GameSettingsData = Data.GameSettingsData;
            UpdateStatistic();
        }

        private void UpdateStatistic()
        {
            _winCount.text = GameSettingsData.Win.ToString();
            _lostCount.text = GameSettingsData.Lost.ToString();
        }
    }
}