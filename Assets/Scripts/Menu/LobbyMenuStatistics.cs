using UnityEngine;
using UnityEngine.UI;

namespace LastStandingSheep
{
    public sealed class LobbyMenuStatistics : MonoBehaviour
    {
        private Text _winCount;
        private Text _lostCount;
        private Toggle _isMusic;
        private Toggle _isSounds;
        private Toggle _isVibro;

        #region Properties

        public GameSettingsData GameSettingsData { get; private set; }

        #endregion

        private void OnLevelWasLoaded(int level)
        {
            Start();
        }

        private void Start()
        {
            _winCount = GameObject.Find("LobbyMenu").transform.Find("Image/WinCount").gameObject.GetComponent<Text>();
            _lostCount = GameObject.Find("LobbyMenu").transform.Find("Image/LostCount").gameObject.GetComponent<Text>();
            _isMusic = GameObject.Find("LobbySettings").transform.Find("Image/Music/MusicToggle").GetComponent<Toggle>();
            _isSounds = GameObject.Find("LobbySettings").transform.Find("Image/Sounds/SoundsToggle").GetComponent<Toggle>();
            _isVibro = GameObject.Find("LobbySettings").transform.Find("Image/Vibro/VibroToggle").GetComponent<Toggle>();
            GameSettingsData = Data.GameSettingsData;
            GameEventController.WinEvent += OnWinCounter;
            CharacterData.PlayerDie += OnLostCounter;
            MusicToggleButton.SwitchMusicEvent += OnSwitchMusic;
            SoundsToggleButton.SwitchSoundsEvent += OnSwitchSounds;
            VibroToggleButton.SwitchVibroEvent += OnSwitchVibro;
            UpdateStatistic();
            DontDestroyOnLoad(gameObject);
        }

        private void UpdateStatistic()
        {
            _winCount.text = GameSettingsData.Win.ToString();
            _lostCount.text = GameSettingsData.Lost.ToString();
            _isMusic.isOn = GameSettingsData.isMusic;
            _isSounds.isOn = GameSettingsData.isSound;
            _isVibro.isOn = GameSettingsData.isVibro;

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

        private void OnSwitchSounds(bool isActive)
        {
            GameSettingsData.isSound = isActive;
            UpdateStatistic();
        }

        private void OnSwitchMusic(bool isActive)
        {
            GameSettingsData.isMusic = isActive;
            UpdateStatistic();
        }

        private void OnSwitchVibro(bool isActive)
        {
            GameSettingsData.isVibro = isActive;
            UpdateStatistic();
        }
    }
}