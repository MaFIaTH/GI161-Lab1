using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent(out Ball b)) return;
        if (b.BallColor == BallColor.White)
        {
            GameManager.Instance.StopBall();
            b.transform.position = new Vector3(0f, 0.5f, 25f);
            return;
        }
        GameManager.Instance.PlayerScore += b.Point;
        Destroy(b.gameObject);
    }
}
