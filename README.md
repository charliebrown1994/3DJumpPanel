# 개인 과제 :

[Unity 11기] 스파르타 던전 탐험 만들기 

## **과제명  :  3DJumpPanel**

### 필수 기능 :  ( 구현완료 )

- **기본 이동 및 점프 `Input System`, `Rigidbo**dy ForceMode` (난이도 : ★★☆☆☆)   ✅
    - 플레이어의 이동(WASD), 점프(Space) 등을 설정
- **체력바 UI** `UI` (난이도 : ★★☆☆☆)  ✅
    - UI 캔버스에 체력바를 추가하고 플레이어의 체력을 나타내도록 설정. 플레이어의 체력이 변할 때마다 UI 갱신.
- **동적 환경 조사** `Raycast` `UI` (난이도: ★★★☆☆)  ✅
    - Raycast를 통해 플레이어가 조사하는 오브젝트의 정보를 UI에 표시.
    - 예) 플레이어가 바라보는 오브젝트의 이름, 설명 등을 화면에 표시.
- **점프대** `Rigidbody ForceMode` (난이도 : ★★★☆☆)  ✅
    - 캐릭터가 밟을 때 위로 높이 튀어 오르는 점프대 구현
    - **OnCollisionEnter** 트리거를 사용해 캐릭터가 점프대에 닿았을 때 **ForceMode.Impulse**를 사용해 순간적인 힘을 가함.
- **아이템 데이터** `ScriptableObject` (난이도 : ★★★☆☆)  ✅
    - 다양한 아이템 데이터를 `ScriptableObject`로 정의. 각 아이템의 이름, 설명, 속성 등을 `ScriptableObject`로 관리
- **아이템 사용** `Coroutine` (난이도 : ★★★☆☆)  ✅
    - 특정 아이템 사용 후 효과가 일정 시간 동안 지속되는 시스템 구현
    - 예) 아이템 사용 후 일정 시간 동안 스피드 부스트.

### 설명 :

1. 유니티 게임 개발 숙련 강의를 기반으로 제작 했습니다.
2. 기본 기능과 코드, 리소스는 강의와 똑같습니다.
3. 추가로 점프대를 구현했습니다.

<img width="1496" height="451" alt="image" src="https://github.com/user-attachments/assets/e99a294b-574b-4bc3-ae76-890f9c5e415c" />


- 점프대는 2개의 오브젝트를 사용했습니다

       1) 모형 오브젝트에 collider를 붙착하고 점프범위에 들어가야 점프를 실행하게 했습니다.

       2) 자녀 오브젝트에 is tirgger를 체크해 점프적용 범위를 지정했습니다.

       3) 점프대의 기능은 자녀 오브젝트에 스크립트를 부여하고 [SerializeField]로 변수 JumpPower를 통해 

            점프의 힘을 유니티에서 즉각 수정가능하게 했습니다.

<img width="418" height="111" alt="image 1" src="https://github.com/user-attachments/assets/ebc809ee-94ac-4e07-ab23-e0c37871ec18" />


### 점프대 스크립트 :  JumpPanel

```csharp
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    [SerializeField] private float jumpPower = 100;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.tag);

            Rigidbody rigid = other.GetComponent<Rigidbody>();

            if (rigid != null)
            {
                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}
```

1. if (rigid != null) 는 예외 처리로 null 값이 아닐 경우에만 실행되게 했습니다
2. “ Rigidbody rigid = other.GetComponent<Rigidbody>(); “ OnTriggerEnter 에 들어온 

        other의 Rigidbody만 가져오겠 변수 선언  GetComponent<Rigidbody>()로 불러 욌습니다.

### 트러불 슈팅:

점프대의 구현은 어렵지 않았지만 처음 구현 시 코드를 확인 하면 [SerializeField]를 통해 Player에 rigidbody를 드래그 하는 형식으로 가지고 와야 했으며, 점프에 파워도 코드에 들어와 일일이 수정해야하는 구조로 만들었습니다. 그리고 50이라는 파워는 캐릭터가 점프 범위에 들어오면 반복해서 점프를 하는 것 처럼 보였고  만약 Player 뿐만 아닌 다른 캐릭터가 점프대에 올라오는 상황이 생긴다면 유지보수를 하는 것도 힘들었습니다. 

```csharp
public class JumpPanel : MonoBehaviour
{
    [SerializeField] Rigidbody playerRigid;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.tag);

            playerRigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
        }
    }
}
```

그래서 드래그를 해서 가지고 오는게 아닌 범위에 진입한 오브젝트에 rigidbody를 가지고 오게 만들었고

파워는 유니티에서 테스트를 하면서 변경가능하게 [SerializeField]를 사용했습니다 

마지막으로 if (rigid != null) 예외 처리 그리고 Rigidbody rigid = other.GetComponent<Rigidbody>();

를 통해 코드가 너무 길지 않고 바로 알아 볼 수 있게 수정을 했습니다.

## 최종 결과 :

![QQ2025811-193052](https://github.com/user-attachments/assets/d44569c7-295c-4239-8168-4ebbc84dbe67)


감사합니다!
