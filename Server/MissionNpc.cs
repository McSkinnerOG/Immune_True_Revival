using System;
using UnityEngine;

public class MissionNpc : MonoBehaviour
{
	public bool m_easyMode;

	public Mission m_mission = new Mission();

	private float m_nextMissionChangeTime;

	private MissionManager m_manager;

	private void Start()
	{
		if (Global.isServer)
		{
			m_manager = (MissionManager)UnityEngine.Object.FindObjectOfType(typeof(MissionManager));
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	private void Update()
	{
		if (Time.time > m_nextMissionChangeTime && m_nextMissionChangeTime != -1f)
		{
			int num = DateTime.Now.Second + DateTime.Now.Minute * 60;
			m_mission = m_manager.GetRandomMission((int)(10f * base.transform.position.x + 1000f * base.transform.position.z) + num, m_easyMode);
			m_nextMissionChangeTime = -1f;
		}
	}

	public void AcceptMission()
	{
		m_nextMissionChangeTime = Time.time + 30f;
	}
}
