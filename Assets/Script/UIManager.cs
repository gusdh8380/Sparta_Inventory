using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 메인 메뉴, 스테이터스, 인벤토리 등 UI 패널 간 전환을 관리하는 싱글톤 클래스.
/// </summary>
public class UIManager : MonoBehaviour
{
   public static UIManager Instance {  get; private set; }

    [Header("UI")]
    [SerializeField]private UIMainMenu UIMainMenu;
    [SerializeField]private UIStatus UIStatus;
    [SerializeField]private UIInventory UIInventory;

    public UIMainMenu MainMenu => UIMainMenu;
    public UIStatus StatusUI => UIStatus;
    public UIInventory InventoryUI => UIInventory;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    public void OpenMainMenu() { CloseAll(); UIMainMenu.Open(); }
    public void OpenStatus() { StatusUI.Open(); CloseBtn(); }
    public void OpenInventory() { InventoryUI.Open(); CloseBtn(); }

    public void RefeshMain()
    {
        UIMainMenu.Refresh(GameManager.Instance.Player);
    }
    private void CloseAll()
    {
        UIMainMenu.Close();
        UIStatus.Close();
        UIInventory.Close();
    }
    public void CloseBtn()
    {
        UIMainMenu.InventoryBtn.gameObject.SetActive(false);
        UIMainMenu.StatusBtn.gameObject.SetActive(false);

    }
    public void ExitBtn()
    {
        UIStatus.Close();
        UIInventory.Close();
        UIMainMenu.InventoryBtn.gameObject.SetActive(true);
        UIMainMenu.StatusBtn.gameObject.SetActive(true);
    }

}
