using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrowth : MonoBehaviour
{
    public GameObject StraightRoot;
    public GameObject LeftRoot;
    public GameObject RightRoot;
    GameObject CurrentRoot;
    public GameObject LastRoot;
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
            CurrentRoot = RightRoot;
        }
        else if (BeanLean < -15)
        {
            CurrentRoot = LeftRoot;
        }
        else if (BeanLean > -15 && BeanLean < 15)
        {
            CurrentRoot = StraightRoot;
        }

        Debug.Log(CurrentRoot);
    }

    public void FixedUpdate()
    {
        GrowthTimer += Time.deltaTime;

        if (GrowthTimer > GrowthRate)
        {
            GameObject NewBean = null;
            if (CurrentRoot == StraightRoot)
            {
                NewBean = Instantiate(CurrentRoot, LastRoot.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, -BeanLean));
            }

            if (CurrentRoot == LeftRoot)
            {
                NewBean = Instantiate(CurrentRoot, LastRoot.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, -BeanLean - 15));
            }

            if (CurrentRoot == RightRoot)
            {
                NewBean = Instantiate(CurrentRoot, LastRoot.transform.GetChild(1).transform.position, Quaternion.Euler(0, 0, -BeanLean + 15));
            }

            GrowthTimer = 0;
            LastRoot = NewBean;
        }
    }
}