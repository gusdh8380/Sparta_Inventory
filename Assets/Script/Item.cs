using UnityEngine;

public enum ItemType { Consumable, Weapon, Armor }

/// <summary>
/// 아이템의 유형, 아이콘 및 능력치 보너스를 저장하는 클래스.
/// </summary>
[System.Serializable]
public class Item
{
    public string Name { get; private set; }
    public Sprite Icon { get; private set; }
    public ItemType Type { get; private set; }
    public int AttackBonus { get; private set; }
    public int DefenseBonus { get; private set; }
    public int Quantity { get; private set; }


    /// <summary>
    /// 아이템을 초기화
    /// </summary>
    public Item(string name, Sprite icon, ItemType type, int atkB, int defB, int qty)
    {
        Name = name;
        Icon = icon;
        Type = type;
        AttackBonus = atkB;
        DefenseBonus = defB;
        Quantity = qty;
    }
}
