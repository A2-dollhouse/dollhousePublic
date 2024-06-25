using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    // 현재 활성화된 패널을 추적하는 변수
    private int currentPanel = 0; // 초기값을 0으로 설정하여 패널이 비활성화된 상태를 나타냄

    // 게임이 시작될 때 호출되는 메서드
    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        // 1초 후에 첫 번째 패널을 활성화
        Invoke("ShowFirstPanel", 1.0f);
    }

    // 첫 번째 패널을 활성화하는 메서드
    void ShowFirstPanel()
    {
        panel1.SetActive(true);
        currentPanel = 1;
    }

    // 매 프레임마다 호출되는 메서드
    void Update()
    {
        // E 키가 눌렸을 때 TogglePanels 메서드를 호출합니다.
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePanels();
        }
    }

    private void TogglePanels()
    {
        // 모든 패널을 비활성화합니다.
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        // 다음 패널을 활성화합니다.
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
            // 모든 패널을 비활성화한 상태를 나타내기 위해 0으로 설정
            currentPanel = 0;
        }
    }
}
