using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDGP.Demo
{
/// <summary>
/// Reloads scene if enemy touches player in SampleScene.
/// </summary>
	public class ReloadScene : MonoBehaviour
	{
		void OnCollisionEnter2D (Collision2D other)
		{
			if (other.collider.CompareTag("Enemy")){
				SceneManager.LoadScene ("Game");
			}
		}
	}
}

