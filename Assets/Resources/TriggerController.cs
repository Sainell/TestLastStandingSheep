using UnityEngine;

namespace LastStandingSheep
{
    public class TriggerController : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Sheep") || collision.transform.CompareTag("Player"))
            {
                 _rigidbody.AddForce((collision.transform.forward+Vector3.up ) * 3,ForceMode.Impulse);
               // collision.gameObject.GetComponent<Rigidbody>().AddForce((Vector3.forward) *55, ForceMode.Impulse);
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            
        }
    }
}