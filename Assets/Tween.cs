using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Look at https://easings.net for reference
public enum Mode{
    EaseInSine,
    EaseOutSine,
    EaseInOutSine,
    EaseInQuad,
    EaseOutQuad,
    EaseInOutQuad,
    EaseInCubic,
    EaseOutCubic,
    EaseInOutCubic,
    EaseInQuart,
    EaseOutQuart,
    EaseInOutQuart,
    EaseInQuint,
    EaseOutQuint,
    EaseInOutQuint,
    EaseInExpo,
    EaseOutExpo,
    EaseInOutExpo,
    EaseInCirc,
    EaseOutCirc,
    EaseInOutCirc,
    EaseInBack,
    EaseOutBack,
    EaseInOutBack,
    EaseInElastic,
    EaseOutElastic,
    EaseInBounce,
    EaseOutBounce,
    EaseInOutBounce,
    EaseInOutElastic
}

public enum Value
{
    Position,
    Rotation,
    Scale
}

public class Tween : MonoBehaviour
{
    public Vector3 amount;
    public float time;
    public float delay;
    public Mode mode;
    public Value value;

    private bool Tweening = false;
    private Pose backupPose;
    private Vector3 backupScale;

    private float acc = 0.0f;

   
    const float c1 = 1.70158f;
    const float c2 = c1 * 1.525f;
    const float c3 = c1 + 1;
    const float c4 = (2 * Mathf.PI) / 3f;
    const float c5 = (2 * Mathf.PI) / 4.5f;
    const float n1 = 7.5625f;
    const float d1 = 2.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Tweening)
        {
            float entity = 0;

            float x = acc / time;
            if (x >= 1)
            {
                entity = 1;
                Tweening = false;
            }
            else if (x == 0)
            {
                entity = 0;
            }
            else
            {
                switch (mode)//Can be optimized using something else instead of pow and sqrt(they are pretty slow)
                {
                    case (Mode.EaseInSine):
                        entity = 1 - Mathf.Cos((x * Mathf.PI) / 2);
                        break;
                    case (Mode.EaseOutSine):
                        entity = Mathf.Sin((x * Mathf.PI) / 2);
                        break;
                    case (Mode.EaseInOutSine):
                        entity = -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
                        break;
                    case (Mode.EaseInQuad):
                        entity = x * x;
                        break;
                    case (Mode.EaseOutQuad):
                        entity = 1 - (1 - x) * (1 - x);
                        break;
                    case (Mode.EaseInOutQuad):
                        entity = x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
                        break;
                    case (Mode.EaseInCubic):
                        entity = x* x *x;
                        break;
                    case (Mode.EaseOutCubic):
                        entity = 1 - Mathf.Pow(1 - x, 3); 
                        break;
                    case (Mode.EaseInOutCubic):
                        entity = x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
                        break;
                    case (Mode.EaseInQuart):
                        entity = x * x * x * x;
                        break;
                    case (Mode.EaseOutQuart):
                        entity = 1 - Mathf.Pow(1 - x, 4);
                        break;
                    case (Mode.EaseInOutQuart):
                        entity = x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
                        break;
                    case (Mode.EaseInQuint):
                        entity = x * x * x * x * x;
                        break;
                    case (Mode.EaseOutQuint):
                        entity = 1 - Mathf.Pow(1 - x, 5);
                        break;
                    case (Mode.EaseInOutQuint):
                        entity = x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
                        break;
                    case (Mode.EaseInExpo):
                        entity = Mathf.Pow(2, 10 * x - 10);
                        break;
                    case (Mode.EaseOutExpo):
                        entity = 1 - Mathf.Pow(2, -10 * x);
                        break;
                    case (Mode.EaseInOutExpo):
                        if (x < 0.5f) entity = Mathf.Pow(2, 20 * x - 10) / 2;
                        else  entity = (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
                        break;
                    case (Mode.EaseInCirc):
                        entity = 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
                        break;
                    case (Mode.EaseOutCirc):
                        entity = Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
                        break;
                    case (Mode.EaseInOutCirc):
                        if (x < 0.5f) entity = (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2;
                        else entity = (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
                        break;
                    case (Mode.EaseInBack):
                        entity = c3 * x * x * x - c1 * x * x;
                        break;
                    case (Mode.EaseOutBack):
                        entity =  1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
                        break;
                    case (Mode.EaseInOutBack):
                        if (x < 0.5f) entity = (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2;
                        else entity = (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
                        break;
                    case (Mode.EaseInElastic):
                        entity = -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10f - 10.75f) * c4);
                        break;
                    case (Mode.EaseOutElastic):
                        entity = Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10f - 0.75f) * c4) + 1;
                        break;
                    case (Mode.EaseInOutElastic):
                        if (x < 0.5f) entity = -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2;
                        else entity = (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
                        break;
                    case (Mode.EaseInBounce):
                        entity = 1 - easeOutBounce(1 - x);
                        break;
                    case (Mode.EaseOutBounce):
                        entity = easeOutBounce(x);
                        break;
                    case (Mode.EaseInOutBounce):
                        if (x < 0.5f) entity = (1 - easeOutBounce(1 - 2 * x)) / 2;
                        else entity = (1 + easeOutBounce(2 * x - 1)) / 2;
                        break;
                }


            }
            switch (value)
            {
                case (Value.Position):
                    transform.position = backupPose.position + amount * entity;
                    break;
                case (Value.Rotation):
                    transform.rotation = backupPose.rotation;
                    transform.Rotate(amount * entity);
                    break;
                case (Value.Scale):
                    transform.localScale = backupScale + amount * entity;
                    break;
            }
            acc += Time.deltaTime;
        }
    }

    public void StartTween()
    {
        Tweening = true;
    }

    public float easeOutBounce(float x)
    {
        if (x < 1 / d1)
        {
            return n1 * x * x;
        }
        else if (x < 2 / d1)
        {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        }
        else if (x < 2.5 / d1)
        {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        }
        else
        {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }

    public void OnEnable()
    {
        backupPose.position = transform.position;
        backupPose.rotation = transform.rotation;
        backupScale = transform.localScale;
        acc = 0.0f;

        Invoke("StartTween", delay);
    }

    public void OnDisable()
    {
        transform.position = backupPose.position;
        transform.rotation = backupPose.rotation;
        transform.localScale = backupScale;
    }
}
