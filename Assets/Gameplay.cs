using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public GameObject areaBombTriggerObj;
	public GameObject areaBomb;

	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Debug.LogError(ray.origin.x +" - "+ ray.origin.y);

			//if user clicked on planet (use for hold)
			if(((ray.origin.x * ray.origin.x) + (ray.origin.y * ray.origin.y)) < 0.25)
			{
				
			}
			//he clicked somewhere else
			else
			{
				SendAreaBomb(ray.origin.x, ray.origin.y);
			}
		}
	}

	void SendAreaBomb(float x, float y)
	{
		Instantiate(areaBombTriggerObj, new Vector3(x, y, 0), new Quaternion(0,0,0,1));
		GameObject areaB = Instantiate(areaBomb, Vector3.zero, new Quaternion(0,0,0,1)) as GameObject;
		AreaBomb areaBScript = areaB.GetComponent<AreaBomb>();
		areaBScript.SetTarget(x,y);
	}



}
