using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FortuneWheel : MonoBehaviour
{
    public GameObject casinoUI;
    public GameObject win;
    public GameObject lose;
    public List<bool> prizes;
    public List<AnimationCurve> animationCurves;

    private bool _spinning;
    private float angle_per_item;
    private int random_time;
    private int item_number;

    void Start()
    {
        for (int i = 0; i < 12; ++i)
        {
            prizes[i] = (i % 2) == 0;
        }

        _spinning = false;
        angle_per_item = 360 / prizes.Count;
    }

    public void SpinWheel()
    {
        random_time = Random.Range(1, 4);
        item_number = Random.Range(0, prizes.Count);
        float max_angle = 360 * random_time + (item_number * angle_per_item);
        StartCoroutine(SpinTheWheel(5 * random_time, max_angle));
    }

    IEnumerator SpinTheWheel(float time, float max_angle)
    {
        _spinning = true;

        float timer = 0.0f;		
        float startAngle = transform.eulerAngles.z;		
        max_angle = max_angle - startAngle;

        int animationCurveNumber = Random.Range (0, animationCurves.Count);
        Debug.Log ("Animation Curve No. : " + animationCurveNumber);

        while (timer < time) {
            //to calculate rotation
            float angle = max_angle * animationCurves [animationCurveNumber].Evaluate (timer / time) ;
            transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }

        transform.eulerAngles = new Vector3(0.0f, 0.0f, max_angle + startAngle);

        Debug.Log ("Prize: " + prizes[item_number]);//use prize[itemNumnber] as per requirement

        if (prizes[item_number])
        {
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
        }
        yield return new WaitForSeconds(2.0f);
        casinoUI.SetActive(false);
        _spinning = false;
    }
}
