using DG.Tweening;
using UnityEngine;

public class Enemy_02 : EnemyBase
{
    public override void Move()
    {
        base.Move();

        transform
            .DOMoveX(transform.position.x + 5f, 15f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine)
            .OnStepComplete(() => transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y));
    }
}
