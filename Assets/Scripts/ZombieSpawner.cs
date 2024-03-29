﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;

namespace TDGP.Demo
{

	public class ZombieSpawner : MonoBehaviour
	{
		bool spawn = true;
		
		public enum SpawnState { SPAWNING, WAITING, COUNTING };

		public Text waveText;
		public Text killCountText;

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
			waveText.text = "";
			killCountText.text = "";
        }

		void Update()
        {
			if (Input.GetKeyDown("p") ) {
            	spawn = !spawn;
        	}

			UpdateKillCount();

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
					waveText.text = "";
					Debug.Log("Starting Wave");
					StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
			else
			{
				waveCountdown -= Time.deltaTime;
				
				if (waveText.text == "")
                {
					string nextWaveDescription = "Starting Wave " + (nextWave + 1).ToString() + "!";
					waveText.text = nextWaveDescription;
				}
			}

		}

		void UpdateKillCount()
        {
			// Update kill count
			searchCountdown -= Time.deltaTime;

			if (searchCountdown <= 0f)
			{
				searchCountdown = 0.2f;
				int totalZom = waves[nextWave].count;
				killCountText.text = (GameObject.FindGameObjectsWithTag("Enemy").Length) + "/" + totalZom;
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
				Debug.Log("All waves done.");
				waveText.text = "YOU'VE SAVED THE PRIME MINISTER!";
				waveCountdown = 999;
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
				searchCountdown = 0.2f;
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
			if (!spawn)
				return;
			// right now just a random spot on the map, hardcoded width and height, how do we find this programmatically?
			Vector2 randomPosition = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5)); 
			Instantiate(_enemy, randomPosition, Quaternion.identity);
        }
	}
}
