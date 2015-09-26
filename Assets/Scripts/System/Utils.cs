using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Utils : Singleton<Utils>
{
	public static Vector3 zeroUI = new Vector3(0f, 0f, 1f);
	public static Vector3 zeroUI_X = new Vector3(0f, 1f, 1f);
	public static Vector3 zeroUI_Y = new Vector3(1f, 0f, 1f);

	public static List<float> _deactivateIn;

	public static List<GameObject> objToDeactivateIn;

	public static List<bool> destroyAfter;
	public static List<bool> stateForObjIn;
	public static List<bool> ignoreTimeScale;

	void Update()
	{
		List<bool> keepAtIndex;
		keepAtIndex = new List<bool>();

		int i = 0;

		if(objToDeactivateIn != null)
		{
			foreach(GameObject obj in objToDeactivateIn)
			{
				if(_deactivateIn[i] > 0)
				{
					_deactivateIn[i] -= (ignoreTimeScale[i] ? Time.unscaledDeltaTime : Time.deltaTime);
					keepAtIndex.Add(true);
				}
				else 
				{
					_deactivateIn[i] = 0;
					objToDeactivateIn[i].SetActive(stateForObjIn[i]);
					if(destroyAfter[i])
						Destroy(obj);
					keepAtIndex.Add(false);
				}
				i++;
			}
		}

		int u = 0;
		if(keepAtIndex != null)
		{
			foreach(bool keepThisOne in keepAtIndex)
			{
				if(!keepThisOne)
				{
					objToDeactivateIn.RemoveAt(u);
					_deactivateIn.RemoveAt(u);
					stateForObjIn.RemoveAt(u);
					ignoreTimeScale.RemoveAt(u);
					destroyAfter.RemoveAt(u);
					u--;
				}
				u++;	
			}
		}
	}

	public static bool inBuild()
	{
		return !Application.isEditor;
	}

	public IEnumerator setActiveIn(GameObject go, bool state, float delay)
	{
		yield return new WaitForSeconds(delay);
		go.SetActive(state);
	}

	public void MessengerSend(Messenger[] messengersToSend)
	{
		if(messengersToSend != null)
			StartCoroutine(SendNow(messengersToSend));
	
	}

	public IEnumerator SendNow(Messenger[] messengers)
	{
		List<Messenger> messengersUnsorted = new List<Messenger>();
		List<Messenger> sortedMessengers = new List<Messenger>();

		foreach(Messenger currentMessenger in messengers)
		{
			messengersUnsorted.Add(currentMessenger);
		}

		sortedMessengers = messengersUnsorted.OrderBy(messenger => messenger.delay).ToList();

		float waited = 0;
		float currentWait = 0;
		foreach(Messenger currentMessenger in sortedMessengers)
		{
			if(currentMessenger.ignoreTimeScale)
			{
				currentWait = currentMessenger.delay - waited;
				while(currentWait > 0)
				{
					currentWait -= Time.unscaledDeltaTime;
					yield return null;
				}
			}
			else
			{
				yield return new WaitForSeconds(currentMessenger.delay - waited);
			}

			waited += currentMessenger.delay;
			currentMessenger.Send();
		}
	}


	public static object TryParseEnum(System.Type enumType, string value, out bool success)
	{
		success = Enum.IsDefined(enumType, value);
		if (success)
		{
			return Enum.Parse(enumType, value);
		}
		return null;
	}

	void Awake()
	{
		_deactivateIn = new List<float>();
		objToDeactivateIn = new List<GameObject>();
		destroyAfter = new List<bool>();
		stateForObjIn = new List<bool>();
		ignoreTimeScale = new List<bool>();

	}

	[System.Serializable]
	public class AxisConstraints
	{
		public bool x, y, z = false;
	}

	public static float addToAbs(float number, float valueToAdd){
		float _abs = Mathf.Abs(number);
		int _sign =(int)(number / _abs);
		return (_abs + valueToAdd) * _sign;
	}
	
	public static float subToAbs(float number, float valueToAdd){
		float _abs = Mathf.Abs(number);
		int _sign = (int)(number / _abs);
		return (_abs - valueToAdd) * _sign;
	}
	
	public static int addToAbs(int number, int valueToAdd){
		int _abs = Mathf.Abs(number);
		int _sign = number / _abs;
		return (_abs + valueToAdd) * _sign;
	}
	
	public static int subToAbs(int number, int valueToAdd){
		int _abs = Mathf.Abs(number);
		int _sign = number / _abs;
		return (_abs - valueToAdd) * _sign;
	}
	
	public static float proportionate(float value, float currentMin, float currentMax, float newMin, float newMax){
		if(value <= currentMax && value >= currentMin){
			float _coef = (value - currentMin) / (currentMax - currentMin);
			return newMin + _coef * (newMax - newMin);
		}
		return 0f;
	}
	
	public static void EmptyChilden (Transform transform){
		for(int i = transform.childCount-1; i >=0; i--){
			GameObject.Destroy(transform.GetChild(i).gameObject);
		}
	}
	
	public static Dictionary<T,T2>CreateDictionnary<T,T2>(T[] keys, T2[]values){
		Dictionary<T,T2> dic = new Dictionary<T,T2>();
		for(int i = 0; i < keys.Length; i++){
			dic.Add(keys[i],values[i]);
		}
		return dic;	
	}
}

public static class PlayerPrefsExtensions
{
	public static void SetBool(string key, bool valueToSet)
	{
		int valToSet = 0;
		if(valueToSet)
			valToSet = 1;
		
		PlayerPrefs.SetInt(key, valToSet);
	}
	
	public static void SetVector3(string key, Vector3 valueToSet)
	{
		PlayerPrefs.SetFloat(key + "_X", valueToSet.x);
		PlayerPrefs.SetFloat(key + "_Y", valueToSet.y);
		PlayerPrefs.SetFloat(key + "_Z", valueToSet.z);
	}
	
	public static Vector3 GetVector3(string key)
	{
		float x = PlayerPrefs.GetFloat(key + "_X");
		float y = PlayerPrefs.GetFloat(key + "_Y");
		float z = PlayerPrefs.GetFloat(key + "_Z");

		if(x == 0 && y == 0 && z == 0)
			return Vector3.zero;
		else
			return new Vector3(PlayerPrefs.GetFloat(key + "_X"), PlayerPrefs.GetFloat(key + "_Y"), PlayerPrefs.GetFloat(key + "_Z"));
	}
	
	public static bool GetBool(string key)
	{
		int valToGet = PlayerPrefs.GetInt(key);
		if(valToGet == 1)
			return true;
		else
			return false;
	}

    public static void SetIntArray(string key, int[] array)
    {
        string finalStringToStore = "";

        for (int i = 0; i < array.Length; i++)
        {
            finalStringToStore += array[i].ToString();
            finalStringToStore += ",";
            
        }

        PlayerPrefs.SetString(key, finalStringToStore);
    }

    public static int[] GetIntArray(string key)
    {
        string initialString = "";
        initialString = PlayerPrefs.GetString(key);
        string coma = ",";
        string stringToTryParse = "";
        int[] finalArray;
        int currentArrayIndex = 0;
        string initialStringCopy = initialString;

        finalArray = new int[initialStringCopy.Split(',').Length-1];

        for(int i = 0; i < initialString.Length; i++)
        {
            if(initialString[i].ToString() != coma)
            {
                stringToTryParse += initialString[i].ToString();
            }
            else
            {
                finalArray[currentArrayIndex] = int.Parse(stringToTryParse);
                currentArrayIndex++;
                stringToTryParse = "";
            }
           
        }

        return finalArray;
    }
}

public static class GameObjectExtensions
{
	public static void SetActive(this GameObject go, bool state, float delay)
	{
		SetActive(go, state, delay, false, false);
	}

	public static void SetActive(this GameObject go, bool state, float delay, bool ignoreTimeScale, bool destroyAfter)
	{
		Utils._deactivateIn.Add(delay);
		Utils.objToDeactivateIn.Add(go);
		Utils.stateForObjIn.Add(state);
		Utils.ignoreTimeScale.Add(ignoreTimeScale);
		Utils.destroyAfter.Add(destroyAfter);
	}
}

public static class UnityEventExtensions
{
    public static void SafeInvoke(this UnityEvent _event)
    {
        if (_event != null)
            _event.Invoke();
    }

    public static void SafeAddListener(this UnityEvent _event, UnityAction _call)
    {
        if (_event != null && _call != null)
            _event.AddListener(_call);
    }
}

    public static class TransformExtensions
{
	public static void Save(this Transform transform)
	{
		PlayerPrefsExtensions.SetVector3(transform.name + "_SavedPosition", transform.position);
		PlayerPrefsExtensions.SetVector3(transform.name + "_SavedRotation", transform.eulerAngles);
	}

	public static void Load(this Transform transform)
	{
		transform.position = PlayerPrefsExtensions.GetVector3(transform.name + "_SavedPosition");
		transform.eulerAngles = PlayerPrefsExtensions.GetVector3(transform.name + "_SavedRotation");
	}

	public static void SetXPosition(this Transform transform, float newX)
	{
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	public static void SetYPosition(this Transform transform, float newY)
	{
		transform.position = new Vector3(transform.position.x, newY, transform.position.z);
	}

	public static void SetZPosition(this Transform transform, float newZ)
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
	}

	public static void SetLocalXPosition(this Transform transform, float newX)
	{
		transform.localPosition = new Vector3(newX, transform.localPosition.y, transform.localPosition.z);
	}
	
	public static void SetLocalYPosition(this Transform transform, float newY)
	{
		transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
	}
	
	public static void SetLocalZPosition(this Transform transform, float newZ)
	{
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZ);
	}


}


