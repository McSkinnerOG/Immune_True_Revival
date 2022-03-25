using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ItemContainer
{
	public List<DatabaseItem> m_items = new List<DatabaseItem>();

	public Vector3 m_position = Vector3.zero;

	private int m_cid;

	private int m_maxX = 1;

	private int m_maxY = 1;

	private int m_xOffset;

	private SQLThreadManager m_sql;

	private ServerPlayer m_player;

	public ItemContainer(int a_maxX, int a_maxY, int a_xOffset, int a_cid = 0, SQLThreadManager a_sql = null, ServerPlayer a_player = null)
	{
		m_maxX = a_maxX;
		m_maxY = a_maxY;
		m_xOffset = a_xOffset;
		m_cid = a_cid;
		m_sql = a_sql;
		m_player = a_player;
	}

	public bool IsValidPos(Vector3 a_pos)
	{
		if (a_pos.x < (float)m_xOffset || a_pos.x >= (float)(m_maxX + m_xOffset) || a_pos.z < 0f || a_pos.z >= (float)m_maxY)
		{
			return false;
		}
		return true;
	}

	public bool CollectItem(DatabaseItem a_item, bool a_stackIfPossible = true, Vector3 a_pos = default)
	{
		bool flag = false;
		int itemIndexFromPos = GetItemIndexFromPos(a_pos.x, a_pos.z);
		if (IsPlayerMoney(a_item.type) && m_player != null)
		{
			flag = true;
			m_player.m_gold += a_item.amount;
		}
		else
		{
			if (a_stackIfPossible && Items.IsStackable(a_item.type))
			{
				if (Vector3.zero == a_pos)
				{
					for (int i = 0; i < m_items.Count; i++)
					{
						if (CollectAndStackItem(a_item, i))
						{
							flag = true;
							break;
						}
					}
				}
				else if (CollectAndStackItem(a_item, itemIndexFromPos))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				if (IsValidPos(a_pos) && itemIndexFromPos == -1)
				{
					a_item.x = a_pos.x;
					a_item.y = a_pos.z;
					flag = true;
				}
				else
				{
					flag = FindFreeInventorySlot(ref a_item.x, ref a_item.y);
				}
				if (flag)
				{
					a_item.cid = m_cid;
					m_items.Add(a_item);
					if (null != m_sql)
					{
						SQLChange(a_item, eDbAction.insert);
					}
				}
			}
		}
		return flag;
	}

	public void UpdateOrCreateItem(DatabaseItem a_item)
	{
		int itemIndexFromPos = GetItemIndexFromPos(a_item.x, a_item.y);
		if (itemIndexFromPos == -1)
		{
			m_items.Add(a_item);
		}
		else
		{
			m_items[itemIndexFromPos] = a_item;
		}
	}

	public void SplitItem(Vector3 a_itemPos)
	{
		int itemIndexFromPos = GetItemIndexFromPos(a_itemPos.x, a_itemPos.z);
		if (itemIndexFromPos > -1 && Items.IsStackable(m_items[itemIndexFromPos].type) && 1 < m_items[itemIndexFromPos].amount && HasFreeSlots())
		{
			DatabaseItem databaseItem = m_items[itemIndexFromPos];
			DatabaseItem a_item = m_items[itemIndexFromPos];
			databaseItem.amount = m_items[itemIndexFromPos].amount / 2;
			m_items[itemIndexFromPos] = databaseItem;
			SQLChange(databaseItem, eDbAction.update);
			a_item.amount = a_item.amount / 2 + a_item.amount % 2;
			CollectItem(a_item, a_stackIfPossible: false);
		}
	}

	public bool EatItem(Vector3 a_itemPos, ServerPlayer a_player)
	{
		bool result = true;
		int itemIndexFromPos = GetItemIndexFromPos(a_itemPos.x, a_itemPos.z);
		if (itemIndexFromPos > -1 && (Items.IsEatable(m_items[itemIndexFromPos].type) || Items.IsMedicine(m_items[itemIndexFromPos].type)))
		{
			a_player.ConsumeItem(m_items[itemIndexFromPos].type);
			result = 0 == DeclineItemAmount(itemIndexFromPos, 1);
		}
		return result;
	}

	public DatabaseItem DragDrop(Vector3 a_dragPos, Vector3 a_dropPos, ItemContainer a_otherContainer, Vector3 a_freeWorldDropPos)
	{
		DatabaseItem result = new DatabaseItem(0);
		int itemIndexFromPos = GetItemIndexFromPos(a_dragPos.x, a_dragPos.z);
		if (itemIndexFromPos > -1 && itemIndexFromPos < m_items.Count)
		{
			if (!IsValidPos(a_dropPos))
			{
				bool flag = true;
				if (a_otherContainer != null && a_otherContainer.IsValidPos(a_dropPos))
				{
					flag = a_otherContainer.CollectItem(m_items[itemIndexFromPos], a_stackIfPossible: true, a_dropPos);
				}
				else
				{
					result = m_items[itemIndexFromPos];
					result.cid = 0;
					result.x = a_freeWorldDropPos.x;
					result.y = a_freeWorldDropPos.z;
					result.dropTime = Time.time;
					int num = ((!(null == m_sql)) ? m_sql.CidToPid(m_cid) : 0);
					result.dropPlayerId = ((m_cid != num) ? num : 0);
				}
				if (flag)
				{
					SQLChange(m_items[itemIndexFromPos], eDbAction.delete);
					m_items.RemoveAt(itemIndexFromPos);
				}
			}
			else
			{
				int itemIndexFromPos2 = GetItemIndexFromPos(a_dropPos.x, a_dropPos.z);
				if (itemIndexFromPos2 == -1)
				{
					DatabaseItem databaseItem = m_items[itemIndexFromPos];
					databaseItem.x = a_dropPos.x;
					databaseItem.y = a_dropPos.z;
					m_items[itemIndexFromPos] = databaseItem;
					SQLChange(databaseItem, eDbAction.update);
				}
				else if (Items.IsStackable(m_items[itemIndexFromPos].type) && m_items[itemIndexFromPos].type == m_items[itemIndexFromPos2].type)
				{
					int num2 = m_items[itemIndexFromPos].amount + m_items[itemIndexFromPos2].amount;
					if (num2 <= 254)
					{
						DatabaseItem a_item = m_items[itemIndexFromPos];
						SQLChange(a_item, eDbAction.delete);
						DatabaseItem databaseItem2 = m_items[itemIndexFromPos2];
						databaseItem2.amount = num2;
						m_items[itemIndexFromPos2] = databaseItem2;
						SQLChange(databaseItem2, eDbAction.update);
						m_items.RemoveAt(itemIndexFromPos);
					}
					else
					{
						DatabaseItem databaseItem3 = m_items[itemIndexFromPos];
						databaseItem3.amount = num2 - 254;
						m_items[itemIndexFromPos] = databaseItem3;
						SQLChange(databaseItem3, eDbAction.update);
						DatabaseItem databaseItem4 = m_items[itemIndexFromPos2];
						databaseItem4.amount = 254;
						m_items[itemIndexFromPos2] = databaseItem4;
						SQLChange(databaseItem4, eDbAction.update);
					}
				}
				else
				{
					DatabaseItem databaseItem5 = m_items[itemIndexFromPos];
					DatabaseItem databaseItem6 = m_items[itemIndexFromPos];
					databaseItem6.x = m_items[itemIndexFromPos2].x;
					databaseItem6.y = m_items[itemIndexFromPos2].y;
					m_items[itemIndexFromPos] = databaseItem6;
					SQLChange(databaseItem6, eDbAction.update);
					DatabaseItem databaseItem7 = m_items[itemIndexFromPos2];
					databaseItem7.x = databaseItem5.x;
					databaseItem7.y = databaseItem5.y;
					m_items[itemIndexFromPos2] = databaseItem7;
					SQLChange(databaseItem7, eDbAction.update);
				}
			}
		}
		return result;
	}

	public bool DeleteItem(float a_x, float a_y)
	{
		return DeleteItem(GetItemIndexFromPos(a_x, a_y));
	}

	public bool DeleteItem(int a_index)
	{
		if (a_index > -1 && a_index < m_items.Count)
		{
			SQLChange(m_items[a_index], eDbAction.delete);
			m_items.RemoveAt(a_index);
			return true;
		}
		return false;
	}

	public bool DeleteItems()
	{
		bool result = false;
		for (int i = 0; i < m_items.Count; i++)
		{
			SQLChange(m_items[i], eDbAction.delete);
			m_items.RemoveAt(i);
			result = true;
		}
		return result;
	}

	public bool HasFreeSlots()
	{
		return m_items == null || m_items.Count < m_maxX * m_maxY;
	}

	public int Count()
	{
		return (m_items != null) ? m_items.Count : 0;
	}

	public int GetCid()
	{
		return m_cid;
	}

	public DatabaseItem GetItemFromPos(float a_x, float a_y)
	{
		int itemIndexFromPos = GetItemIndexFromPos(a_x, a_y);
		if (itemIndexFromPos != -1)
		{
			return m_items[itemIndexFromPos];
		}
		return new DatabaseItem(0);
	}

	public int CraftItem(int a_type, int a_amount)
	{
		if (!Items.IsCraftable(a_type))
		{
			return 0;
		}
		int result = 0;
		ItemDef itemDef = Items.GetItemDef(a_type);
		bool flag = itemDef.durability > 0f && itemDef.durability < 1f;
		if ((itemDef.wood == 0 || GetItemAmountByType(130) >= itemDef.wood * a_amount) && (itemDef.metal == 0 || GetItemAmountByType(131) >= itemDef.metal * a_amount) && (itemDef.stone == 0 || GetItemAmountByType(132) >= itemDef.stone * a_amount) && (itemDef.cloth == 0 || GetItemAmountByType(133) >= itemDef.cloth * a_amount))
		{
			result = (itemDef.wood + itemDef.metal + itemDef.stone + itemDef.cloth) * a_amount;
			DeclineItemAmountByType(130, itemDef.wood * a_amount);
			DeclineItemAmountByType(131, itemDef.metal * a_amount);
			DeclineItemAmountByType(132, itemDef.stone * a_amount);
			DeclineItemAmountByType(133, itemDef.cloth * a_amount);
			DatabaseItem a_item = new DatabaseItem(a_type);
			if (a_amount == 1 || Items.IsStackable(a_type))
			{
				a_item.amount = ((!flag) ? a_amount : 100);
				if (CollectItem(a_item))
				{
				}
			}
			else
			{
				a_item.amount = ((!flag) ? 1 : 100);
				for (int i = 0; i < a_amount; i++)
				{
					CollectItem(a_item);
				}
			}
		}
		return result;
	}

	public int GetItemAmountByType(int a_type)
	{
		int num = 0;
		if (IsPlayerMoney(a_type))
		{
			num = m_player.m_gold;
		}
		else
		{
			for (int i = 0; i < m_items.Count; i++)
			{
				if (a_type == m_items[i].type)
				{
					num += m_items[i].amount;
				}
			}
		}
		return num;
	}

	public bool DeclineHandItem()
	{
		return DeclineItem(0f, 0f);
	}

	public bool DeclineVestItem()
	{
		return DeclineItem(0f, 2f);
	}

	public bool DeclineItem(float a_x, float a_y)
	{
		int itemIndexFromPos = GetItemIndexFromPos(a_x, a_y);
		if (itemIndexFromPos > -1)
		{
			DeclineItemAmount(itemIndexFromPos, 1);
			return true;
		}
		return false;
	}

	public bool RepairHandItem()
	{
		return RepairItem(0f, 0f);
	}

	public bool RepairItem(float a_x, float a_y)
	{
		int itemIndexFromPos = GetItemIndexFromPos(a_x, a_y);
		if (itemIndexFromPos > -1)
		{
			return RepairItem(itemIndexFromPos);
		}
		return false;
	}

	public int DeclineItemAmountByType(int a_type, int a_amount)
	{
		if (1 > a_amount)
		{
			return 0;
		}
		int num = a_amount;
		if (IsPlayerMoney(a_type))
		{
			num = Mathf.Max(a_amount - m_player.m_gold, 0);
			m_player.m_gold = Mathf.Max(m_player.m_gold - a_amount, 0);
		}
		else
		{
			for (int i = 0; i < m_items.Count; i++)
			{
				if (a_type == m_items[i].type)
				{
					num = DeclineItemAmount(i, num);
					if (0 >= num)
					{
						break;
					}
					i--;
				}
			}
		}
		return num;
	}

	private bool IsPlayerMoney(int a_type)
	{
		return m_player != null && 254 == a_type;
	}

	private bool CollectAndStackItem(DatabaseItem a_itemToCollect, int a_invIndex)
	{
		if (a_invIndex >= 0 && a_invIndex < m_items.Count && a_itemToCollect.type == m_items[a_invIndex].type && a_itemToCollect.amount + m_items[a_invIndex].amount <= 254)
		{
			DatabaseItem value = m_items[a_invIndex];
			value.amount += a_itemToCollect.amount;
			m_items[a_invIndex] = value;
			if (null != m_sql)
			{
				SQLChange(m_items[a_invIndex], eDbAction.update);
			}
			return true;
		}
		return false;
	}

	private int DeclineItemAmount(int a_index, int a_amount)
	{
		int result = 0;
		DatabaseItem databaseItem = m_items[a_index];
		if (a_amount < databaseItem.amount)
		{
			databaseItem.amount -= a_amount;
			m_items[a_index] = databaseItem;
			SQLChange(databaseItem, eDbAction.update);
		}
		else
		{
			result = a_amount - databaseItem.amount;
			SQLChange(databaseItem, eDbAction.delete);
			m_items.RemoveAt(a_index);
		}
		return result;
	}

	private bool RepairItem(int a_index)
	{
		DatabaseItem databaseItem = m_items[a_index];
		if (Items.HasCondition(databaseItem.type))
		{
			databaseItem.amount = 100;
			m_items[a_index] = databaseItem;
			SQLChange(databaseItem, eDbAction.update);
			return true;
		}
		return false;
	}

	private int GetItemIndexFromPos(float a_x, float a_y)
	{
		a_x = Mathf.Round(a_x);
		a_y = Mathf.Round(a_y);
		for (int i = 0; i < m_items.Count; i++)
		{
			if (a_x == Mathf.Round(m_items[i].x) && a_y == Mathf.Round(m_items[i].y))
			{
				return i;
			}
		}
		return -1;
	}

	private void SQLChange(DatabaseItem a_item, eDbAction a_action)
	{
		if (null != m_sql && 0 < m_cid)
		{
			a_item.flag = a_action;
			m_sql.SaveItem(a_item);
		}
	}

	private bool FindFreeInventorySlot(ref float a_x, ref float a_y)
	{
		if (HasFreeSlots())
		{
			for (int i = 0; i < m_maxY; i++)
			{
				for (int j = m_xOffset; j < m_maxX + m_xOffset; j++)
				{
					bool flag = false;
					for (int k = 0; k < m_items.Count; k++)
					{
						if (j == (int)(m_items[k].x + 0.5f) && i == (int)(m_items[k].y + 0.5f))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						a_x = j;
						a_y = i;
						return true;
					}
				}
			}
		}
		return false;
	}
}
