using UnityEngine;
using System.Collections;
using Soomla.Profile;

[Prefab("SocialManager", true)]
public class SocialManager : Singleton<SocialManager>
{
	public void Init() { SubscribeEvents(); }

	public void SubscribeEvents()
	{
		ProfileEvents.OnLoginFinished += onLoginFinished;
		ProfileEvents.OnLoginCancelled += onLoginCancelled;
		ProfileEvents.OnLoginFailed += onLoginFailed;
	}

	public void onLoginFinished(UserProfile userProfileJson, bool autoLogin, string payload)
	{
		Debug.Log("Login to Facebook successful!");
	}

	public void onLoginCancelled(Provider provider, bool autoLogin, string payload)
	{
		Debug.Log("Login to Facebook has been cancelled!");
	}

	public void onLoginFailed(Provider provider, string message, bool autoLogin, string payload)
	{
		Debug.LogWarning("Login to Facebook has failed!");
	}
}
