using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;
    public TextMeshProUGUI RemainingTime;
    public TextMeshProUGUI PointsText;
    private float points;
    public float Points
    {
        get { return points; }
        set { points = value + points;
            PointsText.text = "" + points;
            Debug.Log(points);
            }
    }
    private float time;
    public float times
    {
        get { return time; }
        set { time = value + time;
            RemainingTime.text = "" + time;
            }
    }
    public float timeMultiplator = 1;

    private float timeBeforeLast;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        times = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeLast += Time.deltaTime;
        if (timeBeforeLast > timeMultiplator)
        {
            timeBeforeLast = 0;
            times = - 1;
        }
    }
}
