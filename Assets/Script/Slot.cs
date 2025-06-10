using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

/// <summary>
/// 인벤토리 Ui의 슬롯으로, 아이템을 표시하고 장착 상태를 관리
/// </summary>
public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image equipMark;


    private Item item;
    private Character owner;

    public void Init(Item newItem, Character player)
    {
        item = newItem;
        owner = player;

        icon.sprite = item.Icon;

        //버튼에 클릭 이벤트 연결
        GetComponent<Button>().onClick.AddListener(OnClick);
        RefreshUI();
    }

    /// <summary>
    /// 슬롯의 UI를 갱신하여 아이템이 장착되었는지 표시
    /// </summary>
    public void RefreshUI()
    {
        bool equipped = (item == owner.EquippedWeapon) || (item == owner.EquippedArmor);
        equipMark.gameObject.SetActive(equipped);
    }

    /// <summary>
    /// 슬롯 클릭 시 아이템 장착 또는 해제
    /// </summary>
    private void OnClick()
    {
        // 이미 장착 중이라면 해제
        if ((item.Type == ItemType.Weapon && item == owner.EquippedWeapon) ||
            (item.Type == ItemType.Armor && item == owner.EquippedArmor))
        {
            owner.UnEquip(item.Type);
        }
        else
        {
            owner.Equip(item);          // 새로 장착
        }
        RefreshUI();
    }

    /// <summary>
    /// 슬롯에 새로운 아이템을 설정하고 아이콘을 갱신
    /// </summary>
    public void SetItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.Icon;
    }

}
