using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 캐릭터의 기본 상태와 인벤토리, 장비를 관리하는 클래스.
/// </summary>
[System.Serializable]
public class Character
{
    public string Name { get; private set; }
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public float CritChance { get; private set; }
    public int Level { get; private set; }
    public int CurrentExp { get; private set; }
    public int Gold { get; private set; }

    public List<Item> Inventory { get; private set; } = new List<Item>();
    public Item EquippedWeapon { get; private set; }
    public Item EquippedArmor { get; private set; }

    public event System.Action OnStatChanged;
    public event System.Action OnInventoryChanged;

    private readonly int baseAtk;
    private readonly int baseDef;

    /// <summary>
    /// 캐릭터를 초기화합니다.
    /// </summary>
    public Character(string name, int maxHp, int atk, int def, float crit, int level = 1, int gold = 1000)
    {
        Name = name;
        MaxHP = maxHp;
        CurrentHP = maxHp;
        Attack = atk;
        Defense = def;
        CritChance = crit;
        Level = level;
        CurrentExp = 0;
        baseAtk = atk;
        baseDef = def;
        Gold = gold;
    }

    /// <summary>
    /// 캐릭터를 지정된 HP만큼 회복합니다 (최대 HP 이하로).
    /// </summary>
    public void Heal(int amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP + amount, 0, MaxHP);
        OnStatChanged?.Invoke();
    }

    /// <summary>
    /// 경험치를 지정된 양만큼 증가시킵니다.
    /// </summary>
    public void GainExp(int amount)
    {
        CurrentExp += amount;
        
        //임시 레벨 업 경험치
        if (CurrentExp >= 12)
        {
            CurrentExp = 0;
            Level++;
        }
        OnStatChanged?.Invoke();
        UIManager.Instance.RefeshMain();
    }

    /// <summary>
    /// 인벤토리에 아이템을 추가하고 인벤토리 변경 이벤트를 발생시킵니다.
    /// </summary>
    public void AddItem(Item item)
    {
        Inventory.Add(item);
        OnInventoryChanged?.Invoke();
    }

    /// <summary>
    /// 무기 또는 방어구 아이템을 장착하고 스탯을 재계산합니다.
    /// </summary>
    public void Equip(Item item)
    {
        if (item.Type == ItemType.Weapon) EquippedWeapon = item;
        else if (item.Type == ItemType.Armor) EquippedArmor = item;
        RecalculateStats();
        OnStatChanged?.Invoke();
    }

    /// <summary>
    /// 지정한 종류의 아이템 장착을 해제하고 스탯을 재계산합니다.
    /// </summary>
    public void UnEquip(ItemType type)
    {
        if (type == ItemType.Weapon) EquippedWeapon = null;
        else if (type == ItemType.Armor) EquippedArmor = null;
        RecalculateStats();
        OnStatChanged?.Invoke();
    }

    /// <summary>
    /// 장착된 아이템 보너스를 반영하여 공격력과 방어력을 재계산합니다.
    /// </summary>
    private void RecalculateStats()
    {
        Attack = baseAtk + (EquippedWeapon?.AttackBonus ?? 0);
        Defense = baseDef + (EquippedArmor?.DefenseBonus ?? 0);
    }
}
