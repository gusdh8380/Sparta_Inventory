using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
/// <summary>
/// 플레이어의 인벤토리 아이템을 슬롯으로 표시하는 UI 패널을 관리
/// </summary>
public class UIInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GridLayoutGroup grid;   // 슬롯들이 들어갈 부모
    [SerializeField] public Button btnBack;

    [SerializeField] private Slot slotPrefab;
    [SerializeField] private Transform slotParent;     // Scroll-View Content
    private readonly List<Slot> slots = new();

    private Character Player => GameManager.Instance.Player;
    private void OnEnable()
    {
        if (GameManager.Instance == null || GameManager.Instance.Player == null) return;
        Player.OnInventoryChanged += Refresh;   // 아이템 획득/소비 이벤트 구독
        Player.OnStatChanged += Refresh;   // 장착/해제 이벤트 구독
        Refresh();
    }
    private void OnDisable()
    {
        Player.OnInventoryChanged -= Refresh;
        Player.OnStatChanged -= Refresh;
    }
    private void Refresh() { InitInventoryUI(Player.Inventory); }

    public void Open() { gameObject.SetActive(true); Refresh(); }
    public void Close() { gameObject.SetActive(false); }

    public void InitInventoryUI(List<Item> items)
    {
        // 기존 슬롯 제거
        foreach (var s in slots) Destroy(s.gameObject);
        slots.Clear();
        int i = 0;
        // 새로 생성
        foreach (var it in items)
        {
            var slotGO = Instantiate(slotPrefab, slotParent);
            slotGO.Init(it, Player);           
            slots.Add(slotGO);
            i++;
        }
        itemCount.text = $"{i}/100";
        
    }
}
