using UnityEngine;
using Globals;

public class Player_02 : PlayerBase
{
    public override void OnCollisionEnter2D(Collision2D _collision)
    {
        base.OnCollisionEnter2D(_collision);

        if (_collision.transform.CompareTag(Tag.ICEGROUND))
        {
            Speed = 5f;
        }
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        if (_collision.transform.CompareTag(Tag.ICEGROUND))
        {
            Speed = 2f;
        }
    }
}
