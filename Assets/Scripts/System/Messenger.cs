using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Messenger {
	[HideInInspector]
	public string name = "Notify";
	
	public GameObject target;
	public string methodName;
	public float delay = 0;
	public bool ignoreTimeScale = false;
	public bool forceActive;


	public void Send()
	{
		if(target != null) {
			if(!target.activeSelf)
			{
				if(forceActive)
					target.SetActive(true);
			}
			target.SendMessage(methodName);
		}
	}


}
