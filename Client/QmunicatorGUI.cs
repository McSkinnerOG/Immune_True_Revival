using System;
using UnityEngine;
using UnityEngine.UI;

public class QmunicatorGUI : MonoBehaviour
{
	public Transform m_guiRoot;

	public GameObject m_guiComBtn;

	public GameObject m_guiCloseBtn;

	public GameObject m_guiQuitBtn;

	public GameObject[] m_guis;

	public Renderer[] m_btnActiveRenderer;

	public TextMesh m_txtClock;

	public TextMesh m_txtPlayerCount;

	public TextMesh m_txtHealth;

	public TextMesh m_txtEnergy;

	public TextMesh m_txtRank;

	public TextMesh m_txtKarma;

	public Transform m_barHealth;

	public Transform m_barEnergy;

	public Transform m_barRank;

	public Transform m_barKarma;

	public TextMesh m_helpText;

	public Toggle m_hintsToggle;

	public Slider m_volumeSlider;

	public float m_animSpeed = 2f;

	private eActiveApp m_activeApp = eActiveApp.home;

	private GUI3dMaster m_guimaster;

	private LidClient m_client;

	private DayNightCycle m_dayNightCycle;

	private float m_sinOffset;

	private float m_curSin = -1f;

	private float m_zOffset;

	private void Start()
	{
		m_guimaster = (GUI3dMaster)UnityEngine.Object.FindObjectOfType(typeof(GUI3dMaster));
		m_client = (LidClient)UnityEngine.Object.FindObjectOfType(typeof(LidClient));
		m_dayNightCycle = (DayNightCycle)UnityEngine.Object.FindObjectOfType(typeof(DayNightCycle));
		m_zOffset = m_guiRoot.localPosition.z;
		if (null != m_volumeSlider)
		{
			m_volumeSlider.value = PlayerPrefs.GetFloat("prefVolume", 1f);
		}
		if (null != m_hintsToggle)
		{
			m_hintsToggle.isOn = PlayerPrefs.GetInt("prefHints", 1) == 1;
		}
		ActivateGui(m_activeApp);
	}

	private void SetVisible(bool a_visible)
	{
		if ((a_visible ^ IsActive()) && m_curSin == -1f)
		{
			m_sinOffset = ((!a_visible) ? 0.5f : 1.5f);
			m_curSin = m_sinOffset;
		}
	}

	private void ActivateGui(eActiveApp a_app)
	{
		m_activeApp = a_app;
		int num = (int)(a_app - 1);
		for (int i = 0; i < m_guis.Length; i++)
		{
			m_guis[i].SetActive(num == i);
			if (i < m_btnActiveRenderer.Length && null != m_btnActiveRenderer[i])
			{
				m_btnActiveRenderer[i].enabled = num == i;
			}
		}
	}

	private void Update()
	{
		float deltaTime = Time.deltaTime;
		if (m_curSin > -1f)
		{
			Vector3 vector = Vector3.forward * m_zOffset;
			m_guiRoot.localPosition = Vector3.up * ((FastSin.Get(m_curSin * (float)Math.PI) - 1f) * 0.5f) + vector;
			m_curSin += deltaTime * m_animSpeed;
			if (m_curSin > m_sinOffset + 1f)
			{
				m_curSin = -1f;
				m_guiRoot.localPosition = Vector3.up * ((!(m_guiRoot.localPosition.y < -0.5f)) ? 0f : (-1f)) + vector;
			}
		}
		eActiveApp eActiveApp2 = eActiveApp.none;
		if (Input.GetButtonDown("Communicator"))
		{
			SetVisible(!IsActive());
		}
		else if (Input.GetButtonDown("Inventory") || Input.GetButtonDown("Exit"))
		{
			SetVisible(a_visible: false);
		}
		else if (Input.GetButtonDown("Help"))
		{
			eActiveApp2 = eActiveApp.help;
		}
		else if (Input.GetButtonDown("Crafting"))
		{
			eActiveApp2 = eActiveApp.crafting;
		}
		else if (Input.GetButtonDown("Global Chat"))
		{
			eActiveApp2 = eActiveApp.chat;
		}
		else if (Input.GetButtonDown("Map"))
		{
			eActiveApp2 = eActiveApp.maps;
		}
		if (eActiveApp2 != 0)
		{
			if (m_activeApp == eActiveApp2 || !IsActive())
			{
				SetVisible(!IsActive());
			}
			ActivateGui(eActiveApp2);
		}
		if (IsActive())
		{
			eActiveApp activeApp = m_activeApp;
			if (activeApp == eActiveApp.home)
			{
				UpdateHomeApp();
			}
			m_txtClock.text = m_dayNightCycle.GetTime();
			if (null != m_client)
			{
				m_txtPlayerCount.text = LNG.Get("PLAYERCOUNT") + ": " + m_client.GetPlayerCount();
			}
		}
	}

	private void UpdateHomeApp()
	{
		if (null != m_client)
		{
			m_txtHealth.text = ((int)m_client.GetHealth()).ToString();
			m_barHealth.localScale = new Vector3(m_client.GetHealth() * 0.01f, 1f, 1f);
			m_txtEnergy.text = ((int)m_client.GetEnergy()).ToString();
			m_barEnergy.localScale = new Vector3(m_client.GetEnergy() * 0.01f, 1f, 1f);
			m_txtRank.text = ((int)(m_client.GetRankProgress() * 100f)).ToString();
			m_barRank.localScale = new Vector3(m_client.GetRankProgress(), 1f, 1f);
			m_txtKarma.text = ((int)(m_client.GetKarma() * 0.50001f)).ToString();
			m_barKarma.localScale = new Vector3(m_client.GetKarma() / 200f, 1f, 1f);
		}
	}

	private void LateUpdate()
	{
		if (Time.timeSinceLevelLoad < 1f || !(null != m_guimaster))
		{
			return;
		}
		string clickedButtonName = m_guimaster.GetClickedButtonName();
		if (!(string.Empty != clickedButtonName))
		{
			return;
		}
		if (IsActive())
		{
			if (clickedButtonName.Length == 1)
			{
				try
				{
					ActivateGui((eActiveApp)int.Parse(clickedButtonName));
					return;
				}
				catch (Exception message)
				{
					Debug.Log(message);
					return;
				}
			}
			if (clickedButtonName.StartsWith("HELP_"))
			{
				m_helpText.text = LNG.Get(clickedButtonName + "_TEXT");
			}
			else if (null != m_guiCloseBtn && m_guiCloseBtn.name == clickedButtonName)
			{
				SetVisible(a_visible: false);
			}
			else if (null != m_guiQuitBtn && m_guiQuitBtn.name == clickedButtonName)
			{
				QuitGameGUI quitGameGUI = (QuitGameGUI)UnityEngine.Object.FindObjectOfType(typeof(QuitGameGUI));
				if (null != quitGameGUI)
				{
					quitGameGUI.ShowGui(a_show: true);
				}
			}
		}
		else if (null != m_guiComBtn && m_guiComBtn.name == clickedButtonName)
		{
			SetVisible(a_visible: true);
		}
	}

	public bool IsActive(bool a_ignoreAnimation = true)
	{
		return (a_ignoreAnimation && m_guiRoot.localPosition.y != -1f) || (!a_ignoreAnimation && 0f == m_guiRoot.localPosition.y);
	}

	public void OpenCrafting()
	{
		SetVisible(a_visible: true);
		ActivateGui(eActiveApp.crafting);
	}

	public void ToggleHints()
	{
		PlayerPrefs.SetInt("prefHints", m_hintsToggle.isOn ? 1 : 0);
	}

	public void SetVolume()
	{
		AudioListener.volume = m_volumeSlider.value;
		PlayerPrefs.SetFloat("prefVolume", m_volumeSlider.value);
	}

	public void SetAppearance(int a_id)
	{
		PlayerPrefs.SetInt("prefAppearance", a_id);
		m_client.SendChatMsg("/char " + a_id, a_local: true);
	}
}
