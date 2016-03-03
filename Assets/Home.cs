using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

	public float RPF;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,0,RPF);
	}
}
