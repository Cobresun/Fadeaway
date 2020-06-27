using System.Collections;
using System.Collections.Generic;
using System.Net;
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

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                soldier.GetComponent<PlayerMovementHandler>().MoveSpeed *= 2;
                Destroy(gameObject);
            }
        }
    }
}
