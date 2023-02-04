using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanGrowth : MonoBehaviour
{
    public GameObject StraightBean;
    public GameObject LeftBean;
    public GameObject RightBean;
    public GameObject CurrentBean;
    public GameObject LastBean;
    float GrowthRate;
    float BeanLean;

    void Start()
    {
        
    }


    void Update()
    {
        if (BeanLean > 15)
        {
            CurrentBean = RightBean;
        }
        else if (BeanLean < -15)
        {
            CurrentBean= LeftBean;
        }
        else if (BeanLean > -15 && BeanLean < 15)
        {
            CurrentBean = StraightBean;
        }
    }

    private void FixedUpdate()
    {
        float GrowthTimer =+ Time.deltaTime;

        if (GrowthTimer > GrowthRate)
        {
            if (CurrentBean = StraightBean)
            {
                Instantiate(CurrentBean, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, BeanLean));
            }

            if (CurrentBean = LeftBean)
            {
                Instantiate(CurrentBean, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, BeanLean + 15));
            }

            if (CurrentBean = RightBean)
            {
                Instantiate(CurrentBean, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, BeanLean - 15));
            }

            GrowthTimer = 0;
        }
    }
}
