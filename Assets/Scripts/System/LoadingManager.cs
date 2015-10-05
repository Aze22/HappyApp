using UnityEngine;
using System.Collections;
using Soomla.Profile;
using Grow.Highway;
using Grow.Insights;
using Grow.Sync;
using Grow.Gifting;
using Grow.Leaderboards;
using System.Collections.Generic;
using Soomla.Levelup;

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

		LaunchGame();
	}

	private void InitializeLevelUp()
	{
		// Simple constructor that receives only an ID.
		World happyAppInitialWorld = new World("HappyAppWorld");;

		// Create a batch of `Level`s and add them to the `World`. Instead
		// of creating many levels one by one, you can create them all at
		// once, and save time.
		happyAppInitialWorld.BatchAddLevelsWithTemplates (
			365,                                   // Number of levels in this world
			new RecordGate("myHappyAppRecordGate", "myHappyAppRecordGateScore", 1),                             // Gate for each of the levels
			new Score("happyAppScore"),            // Scores for each of the levels
			new RecordMission("myHappyAppMission", "readQuote", "readQuoteScore", 1)           // Missions for each of the levels
		);

		SoomlaLevelUp.Initialize(happyAppInitialWorld);
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
		HighwayEvents.OnModelSyncFinished += onModelSyncFinished;
		HighwayEvents.OnModelSyncFailed += onModelSyncFailed;
		HighwayEvents.OnStateSyncFinished += onStateSyncFinished;

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

	public void onModelSyncFinished(IList<string> modules)
	{
		Debug.Log("Sync Models with Highway Successful!");
		LaunchGame();
	}

	public void onModelSyncFailed(ModelSyncErrorCode errorCode, string failReason)
	{
		Debug.Log("Sync with Highway failed! " + errorCode.ToString() + " - " + failReason);
		LaunchGame();
    }

	public void onStateSyncFinished(IList<string> changedComponents, IList<string> failedComponents)
	{
		Debug.Log("Sync State with Highway Successful!");
		LaunchGame();
	}

	private void InitializeSocialSystem()
	{
		SocialManager.GetInstance().Init();
	}

	public void LaunchGame()
	{
		Application.LoadLevel(1);
	}
}
