# 🧙‍♂️ Unity RPG UI System

> Unity UGUI를 기반으로 한 RPG 게임용 **UI 관리 시스템**입니다.  
> 메인 메뉴, 상태창, 인벤토리, 장비 시스템, 저장 가능한 캐릭터 데이터 구조를 포함하고 있으며, 이벤트 기반 UI 갱신 구조와 간단한 저장 시스템의 확장성을 고려하여 설계되었습니다.

>개발 과정 [링크](https://velog.io/@gusdh8380/0609-Unity%EB%B6%80%ED%8A%B8%EC%BA%A0%ED%94%84-41%EC%9D%BC%EC%B0%A8)
---

## 📌 Features

### ✅ UI 구조 (UGUI 기반)
- `UIMainMenu`: 메인 진입 메뉴
- `UIStatus`: 플레이어 능력치 및 장비 상태
- `UIInventory`: 인벤토리(장착/해제 기능 포함)
- 각 UI는 Canvas 단위로 관리되며, `UIManager`를 통해 열기/닫기 전환 가능

### ✅ Character 시스템
- `Character` 클래스에 레벨, 경험치, 능력치, 인벤토리 정보 구성
- 장비 장착 시 능력치 반영
- 경험치 누적 → 레벨업 구조 구현

### ✅ 아이템 시스템
- `Item` 클래스: 이름, 타입(무기/방어구), 능력치 상승치 포함
- 슬롯 시스템으로 UI에 동적으로 생성 및 장착/해제 처리
- `Slot` 컴포넌트에서 버튼 클릭 시 장착/해제 토글

### ✅ GameManager
- 전체 시스템을 관리하는 Singleton
- 초기 데이터 세팅 및 각 UI 초기화 연결

### ✅ 이벤트 기반 UI 갱신
- 아이템 장착/해제 시 `Action` 델리게이트로 `UIStatus` 갱신 자동화
- 스탯 변경 → UI 반영 구조 확립

---

## 🧪 구현된 시나리오

```plaintext
1. 게임 시작
2. 메인 메뉴 → 상태창, 인벤토리 진입 가능
3. 인벤토리에서 아이템 장착 시 상태창 스탯 변경
4. 경험치 12 이상 시 자동으로 레벨업 및 경험치 초기화
```


## 🧠 기술 스택
Unity 2021.3+
C# (.NET 4.x Equivalent)
UGUI (Canvas, GridLayoutGroup, Button 등)


