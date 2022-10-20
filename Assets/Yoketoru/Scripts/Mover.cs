using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float speedMin = 1;
    [SerializeField]
    float speedMax = 5;

    float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        // speedに、speedMin～speedMaxの速度を乱数で求める
        speed = Random.Range(speedMin, speedMax);

        // ローカル変数thに、0～359の角度を乱数で求める
        var th = Random.Range(0, 360);

        // ローカル変数dirに、角度thで長さ1の方向ベクトルを求める
        var dir = new Vector3(Mathf.Cos(th * Mathf.Deg2Rad), Mathf.Sin(th * Mathf.Deg2Rad), 0);

        // 変数rbに、Rigidbodyのインスタンスを取得する
        rb = GetComponent<Rigidbody>();

        // 以上で求めた値を使って、速度を設定する
        rb.velocity = dir * speed;

        SetRandomVelocity();
    }

    void SetRandomVelocity()
    {
        var th = Random.Range(0, 360);
        var dir = new Vector3(Mathf.Cos(th * Mathf.Deg2Rad), Mathf.Sin(th * Mathf.Deg2Rad), 0);
        rb.velocity = dir * speed;
    }

    void FixedUpdate()
    {
        // if (rb.velocity.magnitude == 0f) 浮動小数点ではこれはNG
        if (Mathf.Approximately(rb.velocity.magnitude, 0f))
        {
            SetRandomVelocity();
        }
        rb.velocity = rb.velocity.normalized * speed;
    }

}
