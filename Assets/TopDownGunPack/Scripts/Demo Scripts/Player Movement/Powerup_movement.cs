using UnityEngine;

namespace TDGP.Demo
{
    public class Powerup_movement : MonoBehaviour
    {

        public GameObject soldier;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Collider2D>().CompareTag("Player"))
            {
                soldier.GetComponent<PlayerMovementHandler>().MoveSpeed *= 2;
                Destroy(gameObject);
            }
        }
    }
}
