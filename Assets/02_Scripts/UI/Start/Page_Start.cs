using UnityEngine;
using UnityEngine.UI;
using Globals;
using DG.Tweening;

public class Page_Start : PageTemplate
{
    [SerializeField] private Button m_startBtn;
    [SerializeField] private Image m_title;

    private void OnDestroy()
    {
        m_startBtn.transform.DOKill();
        m_title.transform.DOKill();
    }

    #region override
    public override void Initialize()
    {
        base.Initialize();

        m_startBtn.onClick.AddListener(OnClickStartBtn);
        ScaleAnim();
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

    private void OnClickStartBtn()
    {
        SoundManager.GetInstance().PlaySFX(SoundType.SFX_SELECTED);
        LoadSceneManager.GetInstance().LoadScene(SceneName.STAGE_01);
    }

    private void ScaleAnim()
    {
        m_startBtn.transform.DOKill();
        m_title.transform.DOKill();

        m_startBtn.transform
            .DOScale(1.1f, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);

        m_title.transform
            .DOScale(1.1f, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
