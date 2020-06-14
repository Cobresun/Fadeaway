using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDGP.Demo
{
/// <summary>
/// Reloads scene if enemy touches player in SampleScene.
/// </summary>
	public class ReloadScene : MonoBehaviour
	{
		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.CompareTag ("Enemy"))
				SceneManager.LoadScene ("Game");
		}
	}
}

