using System;
using UnityEngine;

namespace LastStandingSheep
{
    public class GameEventController : IUpdate
    {
        public static Action WinEvent;

        public bool isWin;

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
                }
            }
        }
    }
}