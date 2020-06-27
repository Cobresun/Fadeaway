using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal; //2019 VERSIONS

namespace TDGP
{
/// <summary>
/// Provides signle bullet firing on trigger press.
/// </summary>
	public class GunTriggerSingle : GunTrigger
	{
		private float currentShootSpeed;
		//public Light2D light2d;

		public override void Awake ()
		{
			base.Awake ();
		}
	
		void Update ()
		{
			if (!inUse)
				return;
			
			currentShootSpeed += Time.deltaTime;

			if (ShootType == SHOOT_TYPE.CLICK) {
				HandleClickInput ();
			} else {
				HandleHoldInput ();
			}
		}

		private bool OkToShoot ()
		{
			if (currentShootSpeed >= DelayBetweenProjectiles) {
				currentShootSpeed = 0f;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Tells each barrel attached to the gun to fire.
		/// </summary>
		public override void HandleClickInput ()
		{
			if (Input.GetButtonDown (buttonMapping) && OkToShoot ()) {
				foreach (var barrel in barrels) {
					//light2d.intensity = 1.3f;
					barrel.OnFire ();
				}
			}
		}

		/// <summary>
		/// Tells each barrel attached to the gun to fire.
		/// </summary>
		public override void HandleHoldInput ()
		{
			if (Input.GetButton (buttonMapping) && OkToShoot ()) {
				foreach (var barrel in barrels) {
					//light2d.intensity = 1.3f;
					barrel.OnFire ();
				}
			}
		}

		/// <summary>
		/// Called by gun component on parent. Resets current shoot speed.
		/// </summary>
		public override void OnPickup ()
		{
			currentShootSpeed = DelayBetweenProjectiles;
			base.OnPickup ();
		}

	}
}
