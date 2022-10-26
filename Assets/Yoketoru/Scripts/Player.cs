using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Tooltip("‘¬‚³"), SerializeField]
    float speed = 20;

    float cameraDistance = 0;
    Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameManager.ToGameover();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var mpos = Input.mousePosition;
        //Debug.Log(mpos);
        mpos.z = cameraDistance;
        var wp = Camera.main.ScreenToWorldPoint(mpos);
        
        //to.main
        transform.position = wp;
        //
        Vector3 to = wp - transform.position;

        //
        if(to.magnitude<0.01f)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            float step = speed * Time.deltaTime;
            float dist = Mathf.Min(to.magnitude, step);
            float v = dist / Time.deltaTime;
            rb.velocity = v * to.normalized;
        }
    }
}
