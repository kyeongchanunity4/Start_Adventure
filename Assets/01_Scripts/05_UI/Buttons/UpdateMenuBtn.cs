using UnityEngine;

public class UpdateMenuBtn : MonoBehaviour
{
    // ���� �޴��� ���������� ���� Ȱ��ȭ/ ��Ȱ��ȭ ����Դϴ�. (�Ͽ���)
    [SerializeField] private GameObject setActiveObj;

    private void Update()
    {
        setActiveObj.SetActive(UIManager.Instance.isContinue);
    }
}
