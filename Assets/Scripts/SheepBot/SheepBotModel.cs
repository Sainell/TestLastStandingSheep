using UnityEngine;
using UnityEngine.AI;


namespace LastStandingSheep
{
    public sealed class SheepBotModel : MonoBehaviour
    {
        #region Properties

        public GameObject SheepBot { get; private set; }
        public SheepBotData SheepBotData { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }
        public Animator Animator { get; private set; }

        #endregion


        #region ClassLifeCycle

        public SheepBotModel(GameObject prefab, SheepBotData sheepBotData)
        {
            SheepBot = prefab;
            SheepBotData = sheepBotData;
            SheepBotData.SheepBotModel = this;
            NavMeshAgent = prefab.GetComponent<NavMeshAgent>();
            Animator = prefab.GetComponent<Animator>();
            PlatformData.PlatformIsMove += MeshAgentSwitch;
        }

        #endregion


        #region Methods

        public void Execute()
        {
            SheepBotData.Updating();
            SetTarget();
            Walk();
        }

        public void MeshAgentSwitch(bool isActive)
        {
            if (NavMeshAgent != null)
            {
                NavMeshAgent.enabled = !isActive;
            }
        }

        public void Walk()
        {
            if (Animator != null)
            {
                if (IsMoving())
                {
                    Animator.Play("Sheep|Walk");
                }
                else
                {
                    Animator.Play("SheepIdle");
                }
            }
        }

        private bool IsMoving()
        {
            var isMoving = false;
            if (NavMeshAgent != null)
            {
               isMoving =  NavMeshAgent.velocity.magnitude > 0.1f;
            }
            return isMoving;
        }

        public void SetTarget()
        {
            if (NavMeshAgent != null)
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
        }
        #endregion
    }
}