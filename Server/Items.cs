using UnityEngine;

public static class Items
{
	public const int c_rawFishType = 11;

	public const int c_mutantclaw = 104;

	public const int c_hammerType = 92;

	public const int c_shovelType = 109;

	public const int c_fishingRodType = 110;

	public const int c_currencyType = 254;

	private static ItemDef[] m_itemDefs;

	private static void Init()
	{
		m_itemDefs = new ItemDef[255];
		ref ItemDef reference = ref m_itemDefs[0];
		reference = new ItemDef("FISTS", 0f, 5f, 0.7f, 1.4f);
		ref ItemDef reference2 = ref m_itemDefs[1];
		reference2 = new ItemDef("BERRIES", 20f);
		ref ItemDef reference3 = ref m_itemDefs[2];
		reference3 = new ItemDef("POTATOES_RAW", 15f);
		ref ItemDef reference4 = ref m_itemDefs[3];
		reference4 = new ItemDef("POTATOES_COOKED", 25f);
		ref ItemDef reference5 = ref m_itemDefs[4];
		reference5 = new ItemDef("MEAT_RAW", -20f);
		ref ItemDef reference6 = ref m_itemDefs[5];
		reference6 = new ItemDef("MEAT_COOKED", 30f);
		ref ItemDef reference7 = ref m_itemDefs[6];
		reference7 = new ItemDef("EGGS_RAW", -20f);
		ref ItemDef reference8 = ref m_itemDefs[7];
		reference8 = new ItemDef("EGGS_COOKED", 40f);
		ref ItemDef reference9 = ref m_itemDefs[8];
		reference9 = new ItemDef("ENERGY_BAR", 35f);
		ref ItemDef reference10 = ref m_itemDefs[9];
		reference10 = new ItemDef("MUSHROOMS", 10f);
		ref ItemDef reference11 = ref m_itemDefs[10];
		reference11 = new ItemDef("CANNED_FOOD", 45f);
		ref ItemDef reference12 = ref m_itemDefs[11];
		reference12 = new ItemDef("FISH_RAW", -15f);
		ref ItemDef reference13 = ref m_itemDefs[12];
		reference13 = new ItemDef("FISH_COOKED", 33f);
		ref ItemDef reference14 = ref m_itemDefs[15];
		reference14 = new ItemDef("RUMBOTTLE", 5f);
		ref ItemDef reference15 = ref m_itemDefs[16];
		reference15 = new ItemDef("WINE", 10f);
		ref ItemDef reference16 = ref m_itemDefs[17];
		reference16 = new ItemDef("WATER", 15f);
		ref ItemDef reference17 = ref m_itemDefs[18];
		reference17 = new ItemDef("BEER", 25f);
		ref ItemDef reference18 = ref m_itemDefs[19];
		reference18 = new ItemDef("SODA", 30f);
		ref ItemDef reference19 = ref m_itemDefs[20];
		reference19 = new ItemDef("C_WOODENDOOR", 0f, 0f, 0f, 0f, 0f, 0, 80, 0, 0, 0, 0, 20);
		ref ItemDef reference20 = ref m_itemDefs[21];
		reference20 = new ItemDef("C_METALDOOR", 0f, 0f, 0f, 0f, 0f, 0, 0, 180, 0, 0, 3, 21);
		ref ItemDef reference21 = ref m_itemDefs[22];
		reference21 = new ItemDef("C_WOODWALL", 0f, 0f, 0f, 0f, 0f, 0, 60, 0, 0, 0, 0, 40);
		ref ItemDef reference22 = ref m_itemDefs[23];
		reference22 = new ItemDef("C_STONEWALL", 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 120, 0, 1, 41);
		ref ItemDef reference23 = ref m_itemDefs[24];
		reference23 = new ItemDef("C_CAMPFIRE", 0f, 0f, 0f, 0f, 0f, 0, 10, 0, 0, 0, 0, 100);
		ref ItemDef reference24 = ref m_itemDefs[26];
		reference24 = new ItemDef("C_BED", 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 50, 2, 101);
		ref ItemDef reference25 = ref m_itemDefs[27];
		reference25 = new ItemDef("C_LOOTBOX", 0f, 0f, 0f, 0f, 0f, 0, 80, 0, 0, 0, 3, 103);
		ref ItemDef reference26 = ref m_itemDefs[28];
		reference26 = new ItemDef("C_TESLACOIL", 0f, 0f, 0f, 0f, 0f, 0, 0, 600, 40, 0, 4, 104);
		ref ItemDef reference27 = ref m_itemDefs[30];
		reference27 = new ItemDef("TNT", 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 0, 0, 102);
		ref ItemDef reference28 = ref m_itemDefs[40];
		reference28 = new ItemDef("45");
		ref ItemDef reference29 = ref m_itemDefs[41];
		reference29 = new ItemDef("9");
		ref ItemDef reference30 = ref m_itemDefs[42];
		reference30 = new ItemDef("556");
		ref ItemDef reference31 = ref m_itemDefs[43];
		reference31 = new ItemDef("762");
		ref ItemDef reference32 = ref m_itemDefs[44];
		reference32 = new ItemDef("SHELL");
		ref ItemDef reference33 = ref m_itemDefs[50];
		reference33 = new ItemDef("C_ARROW", 0f, 0f, 0f, 0f, 0f, 0, 1, 0, 1, 0, 1);
		ref ItemDef reference34 = ref m_itemDefs[51];
		reference34 = new ItemDef("C_STONE", 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 1);
		ref ItemDef reference35 = ref m_itemDefs[60];
		reference35 = new ItemDef("PISTOL", 0f, 22f, 0.6f, 11f, 0.8f, 41);
		ref ItemDef reference36 = ref m_itemDefs[61];
		reference36 = new ItemDef("REVOLVER", 0f, 28f, 0.7f, 11f, 0.9f, 40);
		ref ItemDef reference37 = ref m_itemDefs[62];
		reference37 = new ItemDef("SMG", 0f, 24f, 0.4f, 12f, 0.7f, 42);
		ref ItemDef reference38 = ref m_itemDefs[63];
		reference38 = new ItemDef("SHOTGUN", 0f, 45f, 0.9f, 8f, 0.9f, 44);
		ref ItemDef reference39 = ref m_itemDefs[64];
		reference39 = new ItemDef("SNIPERRIFLE", 0f, 40f, 1f, 16f, 0.9f, 43);
		ref ItemDef reference40 = ref m_itemDefs[65];
		reference40 = new ItemDef("AK47", 0f, 30f, 0.5f, 12f, 0.8f, 43);
		ref ItemDef reference41 = ref m_itemDefs[66];
		reference41 = new ItemDef("UZI", 0f, 20f, 0.35f, 11f, 0.9f, 41);
		ref ItemDef reference42 = ref m_itemDefs[67];
		reference42 = new ItemDef("AUTOSHOTGUN", 0f, 36f, 0.6f, 8f, 0.8f, 44);
		ref ItemDef reference43 = ref m_itemDefs[68];
		reference43 = new ItemDef("TOMMYGUN", 0f, 25f, 0.5f, 12f, 0.6f, 40);
		ref ItemDef reference44 = ref m_itemDefs[77];
		reference44 = new ItemDef("C_SHOTGUN", 0f, 32f, 1f, 8f, 0.1f, 44, 0, 50, 0, 0, 2);
		ref ItemDef reference45 = ref m_itemDefs[78];
		reference45 = new ItemDef("C_SLINGSHOT", 0f, 20f, 0.9f, 8f, 0.25f, 51, 10, 0, 0, 5);
		ref ItemDef reference46 = ref m_itemDefs[79];
		reference46 = new ItemDef("C_BOW", 0f, 25f, 1f, 9f, 0.4f, 50, 20, 0, 0, 10, 1);
		ref ItemDef reference47 = ref m_itemDefs[90];
		reference47 = new ItemDef("FIREAXE", 0f, 32f, 1.1f, 1.4f, 0.85f);
		ref ItemDef reference48 = ref m_itemDefs[91];
		reference48 = new ItemDef("MACHETE", 0f, 30f, 1f, 1.4f, 0.7f);
		ref ItemDef reference49 = ref m_itemDefs[92];
		reference49 = new ItemDef("HAMMER", 0f, 24f, 1f, 1.4f, 0.9f);
		ref ItemDef reference50 = ref m_itemDefs[93];
		reference50 = new ItemDef("KNIFE", 0f, 20f, 0.85f, 1.4f, 0.75f);
		ref ItemDef reference51 = ref m_itemDefs[94];
		reference51 = new ItemDef("PLUNGER", 0f, 6f, 0.9f, 1.4f, 0.1f);
		ref ItemDef reference52 = ref m_itemDefs[95];
		reference52 = new ItemDef("KATANA", 0f, 35f, 1f, 1.4f, 0.7f);
		ref ItemDef reference53 = ref m_itemDefs[96];
		reference53 = new ItemDef("CROWBAR", 0f, 26f, 1f, 1.4f, 0.9f);
		ref ItemDef reference54 = ref m_itemDefs[97];
		reference54 = new ItemDef("WRENCH", 0f, 25f, 1.1f, 1.4f, 0.9f);
		ref ItemDef reference55 = ref m_itemDefs[98];
		reference55 = new ItemDef("CLEAVER", 0f, 28f, 1f, 1.4f, 0.8f);
		ref ItemDef reference56 = ref m_itemDefs[99];
		reference56 = new ItemDef("GIANTSWORD", 0f, 50f, 1.5f, 1.4f, 0.7f);
		ref ItemDef reference57 = ref m_itemDefs[104];
		reference57 = new ItemDef("MUTANT_CLAW", 0f, 10f, 1f, 1.4f, 0.2f);
		ref ItemDef reference58 = ref m_itemDefs[105];
		reference58 = new ItemDef("C_STONEHATCHET", 0f, 22f, 0.95f, 1.4f, 0.3f, 0, 10, 0, 5, 0, 2);
		ref ItemDef reference59 = ref m_itemDefs[106];
		reference59 = new ItemDef("C_KNIFE", 0f, 18f, 0.8f, 1.4f, 0.4f, 0, 0, 5, 0, 0, 1);
		ref ItemDef reference60 = ref m_itemDefs[107];
		reference60 = new ItemDef("C_TORCH", 0f, 20f, 1.1f, 1.4f, 0.01f, 0, 10, 0, 0, 3);
		ref ItemDef reference61 = ref m_itemDefs[108];
		reference61 = new ItemDef("C_WOODCLUB", 0f, 14f, 1f, 1.4f, 0.2f, 0, 10);
		ref ItemDef reference62 = ref m_itemDefs[109];
		reference62 = new ItemDef("C_SPADE", 0f, 10f, 1.1f, 1.4f, 0.6f, 0, 10, 5, 0, 0, 1);
		ref ItemDef reference63 = ref m_itemDefs[110];
		reference63 = new ItemDef("C_FISHINGROD", 0f, 10f, 2f, 1.4f, 0.5f, 0, 10, 1, 0, 1, 2);
		ref ItemDef reference64 = ref m_itemDefs[111];
		reference64 = new ItemDef("C_MACHETE", 0f, 28f, 1.05f, 1.4f, 0.5f, 0, 0, 15, 0, 0, 3);
		ref ItemDef reference65 = ref m_itemDefs[120];
		reference65 = new ItemDef("BACKPACK");
		ref ItemDef reference66 = ref m_itemDefs[121];
		reference66 = new ItemDef("CLOTHBOX");
		ref ItemDef reference67 = ref m_itemDefs[130];
		reference67 = new ItemDef("WOOD");
		ref ItemDef reference68 = ref m_itemDefs[131];
		reference68 = new ItemDef("METAL");
		ref ItemDef reference69 = ref m_itemDefs[132];
		reference69 = new ItemDef("STONE");
		ref ItemDef reference70 = ref m_itemDefs[133];
		reference70 = new ItemDef("CLOTH");
		ref ItemDef reference71 = ref m_itemDefs[140];
		reference71 = new ItemDef("C_BANDAGES", 0f, 0f, 0f, 0f, 0f, 0, 0, 0, 0, 3);
		ref ItemDef reference72 = ref m_itemDefs[141];
		reference72 = new ItemDef("ANTIBIOTICS");
		ref ItemDef reference73 = ref m_itemDefs[142];
		reference73 = new ItemDef("PAINKILLERS");
		ref ItemDef reference74 = ref m_itemDefs[143];
		reference74 = new ItemDef("MEDPACK", 30f);
		ref ItemDef reference75 = ref m_itemDefs[150];
		reference75 = new ItemDef("KEVLARVEST", 0.6f, 0f, 0f, 0f, 0.2f);
		ref ItemDef reference76 = ref m_itemDefs[151];
		reference76 = new ItemDef("C_SCRAPVEST", 0.8f, 0f, 0f, 0f, 0.05f, 0, 40, 0, 0, 5, 2);
		ref ItemDef reference77 = ref m_itemDefs[152];
		reference77 = new ItemDef("C_METALVEST", 0.7f, 0f, 0f, 0f, 0.1f, 0, 0, 60, 0, 10, 3);
		ref ItemDef reference78 = ref m_itemDefs[153];
		reference78 = new ItemDef("C_LEATHERVEST", 0.9f, 0f, 0f, 0f, 0.01f, 0, 0, 0, 0, 20, 1);
		ref ItemDef reference79 = ref m_itemDefs[154];
		reference79 = new ItemDef("GUARDIANVEST", 0.5f, 0f, 0f, 0f, 0.2f);
		ref ItemDef reference80 = ref m_itemDefs[170];
		reference80 = new ItemDef("SNEAKERS", 0.1f, 0f, 0f, 0f, 0.997f);
		ref ItemDef reference81 = ref m_itemDefs[171];
		reference81 = new ItemDef("C_SHOES", 0.05f, 0f, 0f, 0f, 0.994f, 0, 0, 0, 0, 40, 4);
		ref ItemDef reference82 = ref m_itemDefs[254];
		reference82 = new ItemDef("GOLD");
	}

	public static ItemDef GetItemDef(int a_type)
	{
		if (m_itemDefs == null)
		{
			Init();
		}
		if (a_type < 0 || a_type >= m_itemDefs.Length)
		{
			return default(ItemDef);
		}
		return m_itemDefs[a_type];
	}

	public static string GetStatsText(int a_type, int a_amount, bool a_displayValue = false)
	{
		string text = string.Empty;
		ItemDef itemDef = GetItemDef(a_type);
		if (itemDef.ident != null && itemDef.ident.Length > 0)
		{
			if (a_amount > -1 && HasAmountOrCondition(a_type))
			{
				text = ((!IsStackable(a_type)) ? LNG.Get("CONDITION") : LNG.Get("AMOUNT")) + ": " + a_amount + ((!IsStackable(a_type)) ? "%" : string.Empty) + "\n";
			}
			if (a_displayValue)
			{
				string text2 = text;
				text = text2 + LNG.Get("VALUE") + ": " + (int)(GetValue(a_type, a_amount) + 0.5f) + " " + LNG.Get("CURRENCY") + "\n";
			}
			if (itemDef.damage > 5f)
			{
				string text2 = text;
				text = text2 + LNG.Get("DAMAGE") + ": " + itemDef.damage + "\n";
				if (itemDef.ammoItemType > 0)
				{
					text = text + LNG.Get(GetItemDef(itemDef.ammoItemType).ident) + "\n";
				}
			}
			else if (itemDef.healing > 0f)
			{
				if (IsShoes(a_type))
				{
					string text2 = text;
					text = text2 + LNG.Get("SPEED") + ": +" + (int)(itemDef.healing * 100.0001f) + "%\n";
				}
				else if (IsBody(a_type))
				{
					string text2 = text;
					text = text2 + LNG.Get("ARMOR") + ": " + (int)((1f - itemDef.healing) * 100.0001f) + "%\n";
				}
				else
				{
					string text2 = text;
					text = text2 + LNG.Get("ENERGY") + ": " + itemDef.healing + "\n";
				}
			}
		}
		return text;
	}

	public static bool HasAmountOrCondition(int a_type)
	{
		ItemDef itemDef = GetItemDef(a_type);
		return (itemDef.durability > 0f && itemDef.durability < 1f) || IsStackable(a_type);
	}

	public static bool HasCondition(int a_type)
	{
		ItemDef itemDef = GetItemDef(a_type);
		return itemDef.durability > 0f && itemDef.durability < 1f;
	}

	public static int GetAmmoSoundIndex(int a_type)
	{
		if (IsRareAmmo(a_type))
		{
			return a_type - 39;
		}
		return 0;
	}

	public static float GetWeaponXpMultiplier(int a_type)
	{
		ItemDef itemDef = GetItemDef(a_type);
		return itemDef.damage / itemDef.attackdur + itemDef.range * 2f;
	}

	public static float GetNewValue(int a_type)
	{
		float result = 1f;
		ItemDef itemDef = GetItemDef(a_type);
		if (IsEatable(a_type))
		{
			result = 4f + Mathf.Abs(itemDef.healing) * 0.2f;
		}
		else if (IsResource(a_type))
		{
			result = 0.4f;
		}
		else if (IsCraftable(a_type))
		{
			result = (float)(itemDef.wood + itemDef.metal + itemDef.stone + itemDef.cloth) * 0.4f * (1f + (float)itemDef.rankReq * 0.5f);
		}
		else if (5f < itemDef.damage && 0f < itemDef.attackdur)
		{
			result = (itemDef.damage - 5f) / itemDef.attackdur * 3f + itemDef.range * 5f;
		}
		else if (IsRareAmmo(a_type))
		{
			result = 5f;
		}
		else if (IsMedicine(a_type))
		{
			result = 10f;
			switch (a_type)
			{
			case 143:
				result = 70f;
				break;
			case 140:
				result = 5f;
				break;
			}
		}
		else if (IsBody(a_type))
		{
			result = (1f - itemDef.healing) * 500f;
		}
		else if (IsShoes(a_type))
		{
			result = itemDef.healing * 2000f;
		}
		else if (a_type == 30)
		{
			result = 200f;
		}
		return result;
	}

	public static float GetValue(int a_type, int a_amountOrCondition = 1)
	{
		float newValue = GetNewValue(a_type);
		float num = ((!HasCondition(a_type)) ? ((float)a_amountOrCondition) : (0.3f + (float)a_amountOrCondition * 0.007f));
		return newValue * num;
	}

	public static int GetRandomType(float a_maxNewValue = 9999999f)
	{
		int num = -1;
		do
		{
			num = Random.Range(1, 254);
		}
		while (!IsValid(num) || IsContainer(num) || (a_maxNewValue != 9999999f && a_maxNewValue <= GetNewValue(num)));
		return num;
	}

	public static bool IsValid(int a_type)
	{
		return null != GetItemDef(a_type).ident;
	}

	public static int GetRandomFood()
	{
		int num = -1;
		do
		{
			num = Random.Range(1, 20);
		}
		while (!IsValid(num));
		return num;
	}

	public static bool IsStackable(int a_type)
	{
		return (a_type > 0 && a_type < 20) || (a_type > 39 && a_type < 60) || (a_type > 129 && a_type < 150) || 254 == a_type;
	}

	public static bool IsBeverage(int a_type)
	{
		return a_type > 14 && a_type < 20;
	}

	public static bool IsEatable(int a_type)
	{
		return a_type > 0 && a_type < 20;
	}

	public static bool IsRareAmmo(int a_type)
	{
		return a_type > 39 && a_type < 45;
	}

	public static bool IsMedicine(int a_type)
	{
		return a_type > 139 && a_type < 150;
	}

	public static bool IsEatableForPet(int a_type)
	{
		return a_type == 4 || 5 == a_type;
	}

	public static bool IsCookable(int a_type)
	{
		return a_type == 2 || a_type == 4 || a_type == 6 || 11 == a_type;
	}

	public static bool IsBody(int a_type)
	{
		return a_type > 149 && a_type < 160;
	}

	public static bool IsShoes(int a_type)
	{
		return a_type > 169 && a_type < 180;
	}

	public static bool IsContainer(int a_type)
	{
		return a_type > 119 && a_type < 130;
	}

	public static bool IsResource(int a_type)
	{
		return a_type > 129 && a_type < 140;
	}

	public static bool IsCraftable(int a_type)
	{
		return (a_type > 19 && a_type < 30) || (a_type > 49 && a_type < 60) || (a_type > 74 && a_type < 90) || (a_type > 104 && a_type < 120) || (a_type > 150 && a_type < 154) || a_type == 140 || 171 == a_type;
	}
}
