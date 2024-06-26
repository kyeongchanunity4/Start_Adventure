using UnityEngine;

public class UpdateMenuBtn : MonoBehaviour
{
    // 게임 메뉴가 켜졌는지에 따른 활성화/ 비활성화 기능입니다. (하영빈)
    [SerializeField] private GameObject setActiveObj;

    private void Update()
    {
        setActiveObj.SetActive(UIManager.Instance.isContinue);
    }
}
