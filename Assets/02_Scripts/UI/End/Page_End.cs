using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Globals;
using DG.Tweening;

public class Page_End : PageTemplate
{
    [SerializeField] private Button m_restartBtn;
    [SerializeField] private TMP_Text m_score;

    #region override
    public override void Initialize()
    {
        base.Initialize();

        m_restartBtn.onClick.AddListener(OnClickRestartBtn);
        AnimRestartBtn();
    }

    public override void ActivePage()
    {
        base.ActivePage();
        PrintScore();
    }

    public override void InActivePage()
    {
        base.InActivePage();
    }
    #endregion

    private void OnClickRestartBtn()
    {
        GameManager.GetInstance().SetGameState(GameState.GAME_START);
        GameManager.GetInstance().ResetTimer();
        LoadSceneManager.GetInstance().LoadScene(SceneName.STAGE_01);
    }

    private void AnimRestartBtn()
    {
        m_restartBtn.transform.DOKill();

        m_restartBtn.transform
            .DOScale(1.1f, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void PrintScore()
    {
        float score = GameManager.GetInstance().Score;

        int minutes = Mathf.FloorToInt(score / 60f);
        int seconds = Mathf.FloorToInt(score % 60f);

        m_score.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
