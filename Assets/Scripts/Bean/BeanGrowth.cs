using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    bool leftleaf;

    void Start()
    {
        GrowthTimer = 0;
        leftleaf = false;
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
            GameObject NewLeaf = null;
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

            NewBean.transform.localScale = LastBean.transform.localScale;

            if (NonPlatTiles >= 1)
            {
                
                if (leftleaf == false)
                {
                    NewLeaf = Instantiate(RightLeaf, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, 0));
                    leftleaf = true;
                }
                else
                {
                    NewLeaf = Instantiate(LeftLeaf, LastBean.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, 0));
                    leftleaf = false;
                }

                NewLeaf.transform.localScale = LastBean.transform.localScale;

                LeafCounter++;
                NonPlatTiles = 0;
            }

            GrowthTimer = 0;
            LastBean = NewBean;
        }
    }
}
