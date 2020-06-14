using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace TDGP.Demo
{
	public class LookAtMouse : MonoBehaviour
	{

		void Update ()
		{
			var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 heading = mousePos - transform.position;
			float angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;
			GetComponent<Rigidbody2D>().MoveRotation(angle);
			
		}
	}
}
