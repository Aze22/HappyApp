using UnityEngine;
using System.Collections;

public class InGameUIController : MonoBehaviour {

    public JoystickController currentJoystick = null;
    public GameObject joystickPrefab;

	// Use this for initialization
	void Start () {
        joystickPrefab = Resources.Load<GameObject>("UI/Controls/Joystick");
	}
	
	public void ControlRectangleClicked()
    {
        if(currentJoystick == null)
        {
            CreateVirtualJoystick();
        }
    }

    public void CreateVirtualJoystick()
    {
        GameObject newJoystick = Instantiate<GameObject>(joystickPrefab);
        newJoystick.name = "Joystick";
        newJoystick.transform.parent = this.transform;
        newJoystick.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        currentJoystick = newJoystick.GetComponent<JoystickController>();
    }
}
