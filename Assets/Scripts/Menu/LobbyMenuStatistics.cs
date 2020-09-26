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


        private void Awake()
        {
            _winCount = gameObject.transform.Find("Image/WinCount").gameObject.GetComponent<Text>();
            _lostCount = gameObject.transform.Find("Image/LostCount").gameObject.GetComponent<Text>();
            GameSettingsData = Data.GameSettingsData;
            GameEventController.WinEvent += OnWinCounter;
            CharacterData.PlayerDie += OnLostCounter;
            UpdateStatistic();
            DontDestroyOnLoad(gameObject);
        }

        private void UpdateStatistic()
        {
            _winCount.text = GameSettingsData.Win.ToString();
            _lostCount.text = GameSettingsData.Lost.ToString();
        }

        private void OnWinCounter()
        {
            GameSettingsData.Win++;
            UpdateStatistic();
        }

        private void OnLostCounter()
        {
            GameSettingsData.Lost++;
            UpdateStatistic();
        }

        private void OnSwitchSound(bool isActive)
        {
            GameSettingsData.isMusic = isActive;
        }

        private void OnSwitchMusic(bool isActive)
        {
            GameSettingsData.isSound = isActive;
        }

        private void OnSwitchVibro(bool isActive)
        {
            GameSettingsData.isVibro = isActive;
        }
    }
}