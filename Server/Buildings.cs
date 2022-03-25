public static class Buildings
{
	private const double c_hourInSec = 3600.0;

	private static BuildingDef[] m_buildingDefs;

	private static void Init()
	{
		m_buildingDefs = new BuildingDef[255];
		ref BuildingDef reference = ref m_buildingDefs[0];
		reference = new BuildingDef("INVALID");
		ref BuildingDef reference2 = ref m_buildingDefs[1];
		reference2 = new BuildingDef("RES_WOOD");
		ref BuildingDef reference3 = ref m_buildingDefs[2];
		reference3 = new BuildingDef("RES_METAL");
		ref BuildingDef reference4 = ref m_buildingDefs[3];
		reference4 = new BuildingDef("RES_STONE");
		ref BuildingDef reference5 = ref m_buildingDefs[10];
		reference5 = new BuildingDef("RESDES_TREE");
		ref BuildingDef reference6 = ref m_buildingDefs[11];
		reference6 = new BuildingDef("RESDES_TREE2");
		ref BuildingDef reference7 = ref m_buildingDefs[20];
		reference7 = new BuildingDef("DOOR_WOODEN", a_persistent: true, 345600.0);
		ref BuildingDef reference8 = ref m_buildingDefs[21];
		reference8 = new BuildingDef("DOOR_METAL", a_persistent: true, 1036800.0);
		ref BuildingDef reference9 = ref m_buildingDefs[40];
		reference9 = new BuildingDef("WOODWALL", a_persistent: true, 345600.0);
		ref BuildingDef reference10 = ref m_buildingDefs[41];
		reference10 = new BuildingDef("STONEWALL", a_persistent: true, 1036800.0);
		ref BuildingDef reference11 = ref m_buildingDefs[60];
		reference11 = new BuildingDef("PLANT_POTATO", a_persistent: false, 1800.0);
		ref BuildingDef reference12 = ref m_buildingDefs[61];
		reference12 = new BuildingDef("PLANT_BERRY", a_persistent: false, 1800.0);
		ref BuildingDef reference13 = ref m_buildingDefs[62];
		reference13 = new BuildingDef("PLANT_MUSHROOM");
		ref BuildingDef reference14 = ref m_buildingDefs[100];
		reference14 = new BuildingDef("FIREPLACE", a_persistent: false, 28800.0);
		ref BuildingDef reference15 = ref m_buildingDefs[101];
		reference15 = new BuildingDef("BED", a_persistent: true, 1036800.0);
		ref BuildingDef reference16 = ref m_buildingDefs[102];
		reference16 = new BuildingDef("TNT", a_persistent: false, 5.0);
		ref BuildingDef reference17 = ref m_buildingDefs[103];
		reference17 = new BuildingDef("LOOTBOX", a_persistent: true, 1036800.0);
		ref BuildingDef reference18 = ref m_buildingDefs[104];
		reference18 = new BuildingDef("TESLACOIL", a_persistent: true, 1036800.0);
	}

	public static BuildingDef GetBuildingDef(int a_type)
	{
		if (m_buildingDefs == null)
		{
			Init();
		}
		if (a_type < 0 || a_type >= m_buildingDefs.Length)
		{
			return default(BuildingDef);
		}
		return m_buildingDefs[a_type];
	}

	public static bool IsResource(int a_type)
	{
		return a_type >= 0 && a_type < 20;
	}

	public static bool IsDoor(int a_type)
	{
		return a_type >= 20 && a_type < 40;
	}

	public static bool IsCollider(int a_type)
	{
		return (a_type >= 0 && a_type < 60) || a_type == 101 || a_type == 103 || 104 == a_type;
	}

	public static bool IsHarmless(int a_type)
	{
		return a_type > 59 && a_type < 101;
	}
}
