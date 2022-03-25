using Steamworks;
using UnityEngine;

public class SteamAuth : MonoBehaviour
{
	private void Start()
	{
		if (SteamManager.Initialized)
		{
			ulong steamID = SteamUser.GetSteamID().m_SteamID;
			string personaName = SteamFriends.GetPersonaName();
			Debug.Log(personaName + " id " + steamID);
		}
	}
}
