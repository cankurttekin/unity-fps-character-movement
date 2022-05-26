using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public float moveForce;
    public GameObject bullet;
    public GameObject magic;
    public Transform leftFirePoint;
    public Transform gun;
    public float shootRate;
    public float shootForce;
    private float m_shootRateTimeStamp;
    Animator m_Animator;
    public Camera cam;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                GameObject go = (GameObject)Instantiate(
                bullet, gun.position, gun.rotation);

                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
                m_shootRateTimeStamp = Time.time + shootRate;
            }

        }
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                
                GameObject go = (GameObject)Instantiate(
                magic, gun.position, gun.rotation);

                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce * 1.5f);
                m_shootRateTimeStamp = Time.time + shootRate;
            }

        }
        */
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                destination = hit.point;
            }
            else
            {
                destination = ray.GetPoint(1000);
            }
            GameObject go = Instantiate(magic, leftFirePoint.position, Quaternion.identity);

            go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce * 1.2f);
        }
    }
}
