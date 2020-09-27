using UnityEngine;
using UnityEngine.UI;

namespace LastStandingSheep
{
    public sealed class LobbyMenuSettings : MonoBehaviour
    {
        private Toggle _isMusic;
        private Toggle _isSounds;
        private Toggle _isVibro;

        #region Properties

        public GameSettingsData GameSettingsData { get; private set; }

        #endregion

        private void Start()
        {
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
        }

        private void UpdateStatistic()
        {
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

        private void OnDestroy()
        {
            GameEventController.WinEvent -= OnWinCounter;
            CharacterData.PlayerDie -= OnLostCounter;
            MusicToggleButton.SwitchMusicEvent -= OnSwitchMusic;
            SoundsToggleButton.SwitchSoundsEvent -= OnSwitchSounds;
            VibroToggleButton.SwitchVibroEvent -= OnSwitchVibro;
        }
    }
}