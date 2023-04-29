using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMan : MonoBehaviour
{
    public float Speed;
    public Vector3 direction;
    public string BrandName;
    public bool isNotKind;
    public bool giveABuff;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayBeforeStop());
        Debug.Log(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RelayPoint" )
        {
            if (isNotKind)
            {

            }
            if(BrandName == other.GetComponent<RelayPoint>().BrandName)
            {
                if (giveABuff)
                {

                }
                GameManager.Instance.Points = 1;
            }
            else
            {
                GameManager.Instance.Points = -1;
            }
           
        }
        else if(other.gameObject.tag == "Barrier")
        {
            Destroy(other.gameObject);
            Explosion();
        }
        else if (other.gameObject.tag == "Bonus")
        {
            other.gameObject.GetComponent<Bonus>().GetBonus();
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            
        }
        else if (other.gameObject.tag == "Malus")
        {
            other.gameObject.GetComponent<Malus>().GetMalus();
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        }
    }

    private void Explosion()
    {
        Destroy(gameObject);
    }
    IEnumerator DelayBeforeStop()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
