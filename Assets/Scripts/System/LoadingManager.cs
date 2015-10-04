using UnityEngine;
using System.Collections;
using Soomla.Profile;
using Grow.Highway;
using Grow.Insights;
using Grow.Sync;
using Grow.Gifting;
using Grow.Leaderboards;
using System;

[Prefab("LoadingManager", true)]
public class LoadingManager : Singleton<LoadingManager>
{

	// Use this for initialization
	void Start ()
	{
		if (!Application.isEditor)
		{
			InitializeGrow();
			InitializeStore();
			InitializeProfile();
			InitializeLevelUp();
			InitializeSocialSystem();
		}
		
		Application.LoadLevel(1);
	}

	private void InitializeLevelUp()
	{
		//SoomlaLevelUp.Initialize(initialWorld);
	}

	private void InitializeStore()
	{
		//SoomlaStore.Initialize(new YourStoreAssetsImplementation());
	}

	private void InitializeProfile()
	{
		SoomlaProfile.Initialize();
	}

	private void InitializeGrow()
	{
		
		// Make sure to make this call in your earliest loading scene,
		// and before initializing any other SOOMLA/GROW components
		// i.e. before SoomlaStore.Initialize(...)
		GrowHighway.Initialize();

		// Make sure to make this call AFTER initializing HIGHWAY
		GrowInsights.Initialize();

		// Make sure to make this call AFTER initializing HIGHWAY,
		// and BEFORE initializing STORE/PROFILE/LEVELUP
		bool modelSync = true;     // Remote Economy Management - Synchronizes your game's
								   // economy model between the client and server - enables
								   // you to remotely manage your economy.

		bool stateSync = true; // Synchronizes the users' balances data with the server
							   // and across his other devices.
							   // Must be TRUE in order to use LEADERBOARDS.

		// State sync and Model sync can be enabled/disabled separately.
		GrowSync.Initialize(modelSync, stateSync);

		// LEADERBOARDS requires no initialization,
		// but it depends on SYNC initialization with stateSync=true

		// Make sure to make this call AFTER initializing SYNC,
		// and BEFORE initializing STORE/PROFILE/LEVELUP
		GrowGifting.Initialize();
	}

	private void InitializeSocialSystem()
	{
		SocialManager.GetInstance().Init();
	}
}
