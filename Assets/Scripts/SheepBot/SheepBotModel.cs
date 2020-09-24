using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System.Collections;

namespace LastStandingSheep
{
    public sealed class SheepBotModel : MonoBehaviour
    {
        #region Properties

        public GameObject SheepBot { get; private set; }
        public SheepBotData SheepBotData { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }

        #endregion


        #region ClassLifeCycle

        public SheepBotModel(GameObject prefab, SheepBotData sheepBotData)
        {
            SheepBot = prefab;
            SheepBotData = sheepBotData;
            SheepBotData.SheepBotModel = this;
            NavMeshAgent = prefab.GetComponent<NavMeshAgent>();

            PlatformData.PlatformIsMove += MeshAgentSwitch;
        }

        #endregion


        #region Methods

        public void Execute()
        {
            SheepBotData.Updating();
            SetTarget();
        }

        public void MeshAgentSwitch(bool isActive)
        {
            if (NavMeshAgent != null)
            {
                NavMeshAgent.enabled = !isActive;
            }
        }

        public void SetTarget()
        {
            var target = GameObject.FindGameObjectWithTag("Finish");
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player");
            }
            if (target != null)
            {
                if (NavMeshAgent.enabled)
                {
                    if (NavMeshAgent != null)
                    {
                        NavMeshAgent.SetDestination(target.transform.position);
                    }
                }
            }
        }
        #endregion
    }
}