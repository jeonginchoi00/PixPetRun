using TMPro;
using UnityEngine;

public class Page_Stage : PageTemplate
{
    [SerializeField] private TMP_Text m_timer;

    private void Update()
    {
        SetTimer();
    }

    private void SetTimer()
    {
        float score = GameManager.GetInstance().Score;

        int minutes = Mathf.FloorToInt(score / 60f);
        int seconds = Mathf.FloorToInt(score % 60f);

        m_timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    #region override
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void ActivePage()
    {
        base.ActivePage();
    }

    public override void InActivePage()
    {
        base.InActivePage();
    }
    #endregion
}
