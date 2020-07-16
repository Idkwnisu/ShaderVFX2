using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceblockAnimationController : MonoBehaviour
{
  public float startAmount = 10.0f;
  private float Amount;

  public float target;
  public Material mat;

  public float totalTime = 2.0f;

  private float time;

  public float speed;

  private bool stop = false;

  public float freeze = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
      Amount = startAmount;
      mat.SetFloat("_Seed", Random.Range(0.0f,100.0f));
      time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
      if(!stop)
      {
        mat.SetFloat("_StepValue",Amount);
          mat.SetFloat("_Freeze",freeze);

        float timeRatio = time/totalTime;
        Amount = ((1-(Mathf.Pow((timeRatio - 1),3)+1)) * 0.8f) + 0.2f;

        Debug.Log(timeRatio);

        freeze = 1-timeRatio;

        time += Time.deltaTime;

        if(time >= totalTime)
        {
          Invoke("Restart",2.5f);
          stop = true;
          mat.SetFloat("_Freeze",0.0f);
        }

      }
    }

    void Restart()
    {
      Amount = startAmount;
      stop = false;
      mat.SetFloat("_Seed", Random.Range(0.0f,100.0f));
      mat.SetFloat("_Freeze",1.0f);
      time = 0.0f;
      freeze = 1.0f;
    }
}
