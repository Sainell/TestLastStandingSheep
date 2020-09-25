using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastStandingSheep
{
    public class GameEventController : IAwake, IUpdate
    {
        public static Action WinEvent;

        public int DieCount;
        public int WinCount;
        public bool isWin;

        public void OnAwake()
        {
            CharacterData.PlayerDie += OnPlayerDie;
        }

        public void Updating()
        {
            SheepCounter();
        }

        private void SheepCounter()
        {
            if (!isWin)
            {
                var count = GameObject.FindGameObjectsWithTag("Sheep");
                if (count.Length == 0)
                {
                    isWin = true;
                    WinEvent?.Invoke();
                    WinCount++;
                    PlayerPrefs.SetInt("Win Count", WinCount);
                }
            }
        }

        private void OnPlayerDie()
        {
            DieCount++;
            PlayerPrefs.SetInt("Die Count", DieCount);
        }

    }
}