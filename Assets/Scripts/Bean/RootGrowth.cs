using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrowth : MonoBehaviour
{
    public GameObject BeanBase;
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
        BeanLean = BeanBase.GetComponent<BeanRotation>().globalAngle;

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
            Vector3 newRootPos = LastRoot.transform.GetChild(1).transform.position;
            newRootPos.z = 0;

            GameObject NewRoot = null;
            if (CurrentRoot == StraightRoot)
            {
                NewRoot = Instantiate(CurrentRoot, LastRoot.transform.GetChild(1).transform.position, Quaternion.identity);
            }

            if (CurrentRoot == LeftRoot)
            {
                NewRoot = Instantiate(CurrentRoot, newRootPos, Quaternion.identity);
            }

            if (CurrentRoot == RightRoot)
            {
                NewRoot = Instantiate(CurrentRoot, newRootPos, Quaternion.identity);
            }

            NewRoot.transform.localScale = LastRoot.transform.localScale;

            GrowthTimer = 0;
            LastRoot = NewRoot;
        }
    }
}