using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace TweenMgr
{


    [DefaultExecutionOrder(-1)]
    public class TweenMgr : MonoBehaviour
    {
        private static TweenMgr inst = null;

        public static TweenMgr Inst
        {
            get
            {

                return inst;
            }
        }

        private void Awake()
        {
            if (inst == null)
            {
                inst = this;
            }
        }

        public void test()
        {
            print("i am tweenmgr test");
        }

        public IEnumerator ToFloat(float startValue, float targetValue, float duration, Action<float> func, Action endAction = null)
        {
            float timer = 0f;
            while (timer < duration)
            {
                float t = timer / duration;
                float interpolatedValue = Mathf.Lerp(startValue, targetValue, t);
                func.Invoke(interpolatedValue);

                timer += Time.deltaTime;
                yield return null;
            }

            func.Invoke(targetValue);
            endAction?.Invoke();
        }


        public IEnumerator ByFloat(float startValue, float offsetValue, float duration, Action<float> func, Action endAction = null)
        {
            float timer = 0f;

            float targetValue = startValue + offsetValue;

            while (timer < duration)
            {
                float t = timer / duration;
                float interpolatedValue = Mathf.Lerp(startValue, targetValue, t);
                func.Invoke(interpolatedValue);

                timer += Time.deltaTime;
                yield return null;
            }

            func.Invoke(targetValue);
            endAction?.Invoke();
        }

        /*
        void Start()
        {
            StartCoroutine(ByFloat(-1f, 2f, 3.2f,(float f)=> {
                transform.position = new Vector3(0, f, 0);    
            },()=> {
                Debug.Log("is over");
            }));
        }
        */

    }

}