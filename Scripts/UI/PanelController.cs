using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    // ���� Ȱ��ȭ�� �г��� �����ϴ� ����
    private int currentPanel = 0; // �ʱⰪ�� 0���� �����Ͽ� �г��� ��Ȱ��ȭ�� ���¸� ��Ÿ��

    // ������ ���۵� �� ȣ��Ǵ� �޼���
    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        // 1�� �Ŀ� ù ��° �г��� Ȱ��ȭ
        Invoke("ShowFirstPanel", 1.0f);
    }

    // ù ��° �г��� Ȱ��ȭ�ϴ� �޼���
    void ShowFirstPanel()
    {
        panel1.SetActive(true);
        currentPanel = 1;
    }

    // �� �����Ӹ��� ȣ��Ǵ� �޼���
    void Update()
    {
        // E Ű�� ������ �� TogglePanels �޼��带 ȣ���մϴ�.
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePanels();
        }
    }

    private void TogglePanels()
    {
        // ��� �г��� ��Ȱ��ȭ�մϴ�.
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        // ���� �г��� Ȱ��ȭ�մϴ�.
        if (currentPanel == 1)
        {
            panel2.SetActive(true);
            currentPanel = 2;
        }
        else if (currentPanel == 2)
        {
            panel3.SetActive(true);
            currentPanel = 3;
        }
        else if (currentPanel == 3)
        {
            // ��� �г��� ��Ȱ��ȭ�� ���¸� ��Ÿ���� ���� 0���� ����
            currentPanel = 0;
        }
    }
}
