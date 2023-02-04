using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanGrowth : MonoBehaviour
{
    public GameObject StraightBean;
    public GameObject LeftBean;
    public GameObject RightBean;
    public GameObject RightLeaf;
    public GameObject LeftLeaf;
    GameObject CurrentBean;
    public GameObject LastBean;
    public float GrowthRate;
    public int LeafCounter;
    float BeanLean;
    float GrowthTimer;
    int LeafRate;
    int NonPlatTiles;

    void Start()
    {
        GrowthTimer = 0;
    }

    void Update()
    {
        BeanLean = gameObject.GetComponent<BeanRotation>().globalAngle;

        if (BeanLean > 15)
        {
            CurrentBean = LeftBean;
        }
        else if (BeanLean < -15)
        {
            CurrentBean = RightBean;
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
                NonPlatTiles++;
            }

            if (CurrentBean == LeftBean)
            {
                NewBean = Instantiate(CurrentBean, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, BeanLean - 15));
                NonPlatTiles++;
            }

            if (CurrentBean == RightBean)
            {
                NewBean = Instantiate(CurrentBean, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, BeanLean + 15));
                NonPlatTiles++;
            }

            if (NonPlatTiles >= 2)
            {
                if (Random.Range(0, 2) == 1)
                {
                    Instantiate(RightLeaf, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    Instantiate(LeftLeaf, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, 0));
                }

                LeafCounter++;
                NonPlatTiles = 0;
            }

            GrowthTimer = 0;
            LastBean = NewBean;
        }
    }
}
