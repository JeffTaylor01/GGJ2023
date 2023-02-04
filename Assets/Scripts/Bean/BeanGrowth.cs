using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanGrowth : MonoBehaviour
{
    public GameObject StraightBean;
    public GameObject LeftBean;
    public GameObject RightBean;
    GameObject CurrentBean;
    public GameObject LastBean;
    public float GrowthRate;
    float BeanLean;
    float GrowthTimer;

    void Start()
    {
        GrowthTimer = 0;
    }


    void Update()
    {
        BeanLean = gameObject.GetComponent<BeanRotation>().globalAngle;

        if (BeanLean > 15)
        {
            CurrentBean = RightBean;
        }
        else if (BeanLean < -15)
        {
            CurrentBean = LeftBean;
        }
        else if (BeanLean > -15 && BeanLean < 15)
        {
            CurrentBean = StraightBean;
        }

        Debug.Log(CurrentBean);
    }

    public void FixedUpdate()
    {
        GrowthTimer += Time.deltaTime;

        if (GrowthTimer > GrowthRate)
        {
            GameObject NewBean = null;
            if (CurrentBean == StraightBean)
            {
                NewBean = Instantiate(CurrentBean, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, BeanLean));
            }

            if (CurrentBean == LeftBean)
            {
                NewBean = Instantiate(CurrentBean, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, BeanLean - 15));
            }

            if (CurrentBean == RightBean)
            {
                NewBean = Instantiate(CurrentBean, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, BeanLean + 15));
            }

            GrowthTimer = 0;
            LastBean = NewBean;
        }
    }
}
