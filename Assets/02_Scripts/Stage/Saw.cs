using UnityEngine;
using DG.Tweening;

public class Saw : MonoBehaviour
{
    private float m_moveDistance = 11.3f;

    private void Start()
    {
        transform.DOKill();

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(transform.position.x + m_moveDistance, 0, 0);

        transform.DOMove(endPos, 2f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}