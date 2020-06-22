using UnityEngine;
using System.Collections;

namespace TDGP.Demo
{

	public class ZombieSpawner : MonoBehaviour
	{
		
		public enum SpawnState { SPAWNING, WAITING, COUNTING };

		[System.Serializable]
		public class Wave
        {
			public string name;
			public GameObject enemy;
			public int count;
			public float rate;

        }

		private int nextWave = 0;

		public Wave[] waves;
		public float timeBetweenWaves = 5f;
		public float waveCountdown;

		private float searchCountdown = 1f;

		private SpawnState state = SpawnState.COUNTING;

		void Start()
        {
			waveCountdown = timeBetweenWaves;
        }

		void Update()
        {

			if (state == SpawnState.WAITING)
            {
				if (!EnemyIsAlive())
                {
					// Start next round
					WaveCompleted();
					return;
                }
                else
                {
					return;
                }
            }

			if (waveCountdown <= 0)
            {
				if (state != SpawnState.SPAWNING)
                {
					// Start spawning here
					Debug.Log("Starting Wave");
					StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
			else
			{
				waveCountdown -= Time.deltaTime;
			}
		}

		void WaveCompleted()
        {
			Debug.Log("Wave compelte");

			state = SpawnState.COUNTING;

			waveCountdown = timeBetweenWaves;

			if (nextWave + 1 > waves.Length - 1)
            {
				nextWave = 0;
				Debug.Log("All waves done, looping now.");
            }
            else
            {
				nextWave += 1;
            }
		}

		bool EnemyIsAlive()
        {
			searchCountdown -= Time.deltaTime;

			if (searchCountdown <= 0f)
            {
				searchCountdown = 1f;
				if (GameObject.FindGameObjectWithTag("Enemy") == null)
				{
					return false;
				}
			}

			return true;
        }


		IEnumerator SpawnWave(Wave _wave)
        {
			state = SpawnState.SPAWNING;
			
			for (int i =0; i < _wave.count; i++)
            {
				SpawnEnemy(_wave.enemy);
				yield return new WaitForSeconds(_wave.rate);
            }

			state = SpawnState.WAITING;

			yield break;
        }

		void SpawnEnemy(GameObject _enemy)
        {
			// right now just a spot on the map, hardcoded width and height, how do we find this programmatically?
			Vector2 randomPosition = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5)); 
			Instantiate(_enemy, randomPosition, Quaternion.identity);
			//Debug.Log("Spawning Zombie");
        }
	}
}
