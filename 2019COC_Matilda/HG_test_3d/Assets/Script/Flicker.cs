//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Flicker : MonoBehaviour
//{

//    public GameObject[] button;
//    //public float[] delay = new float[4];
//    public ArrayList delay = new ArrayList();

//    //void Start()
//    //{
//    //    //for (int i = 0; i < 4; i++)
//    //    //{
//    //    //    StartCoroutine(flicking_list(delay));
//    //    //}
//    //}
  
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.A))
//        {
//            if (button[0].CompareTag("Layer1"))
//            {
//                Debug.Log("Layer1 called.");
//            }
//        }
//    }

//    //public IEnumerator flicking(float delay)
//    //{
//    //    for (float timer = 0; timer < 4f; timer += Time.deltaTime)
//    //    {
//    //        for (int i = 0; i < 4; i++)
//    //        {
//    //            Debug.Log(timer);
//    //            button[i].SetActive(false);
//    //            yield return new WaitForSeconds(delay);
//    //            button[i].SetActive(true);
//    //            yield return new WaitForSeconds(delay);
//    //        }
//    //    }

//    //    yield return null;
//    //}

//    //public IEnumerator flicking_list(ArrayList list)
//    //{

//    //    Debug.Log("flicking start");
//    //    //Convert to array
//    //    float[] delay_arr = list.ToArray(typeof(float)) as float[];
//    //    for (int i = 0; i < delay_arr.Length; i++)
//    //    {
//    //        delay_arr[0] = 0.09f;
//    //        delay_arr[1] = 0.13f;
//    //        delay_arr[2] = 0.17f;
//    //        delay_arr[3] = 0.21f;
//    //        delay_arr[4] = 0.25f;
//    //    }

//    //    int num = 0;

//    //    for (int j = 0; j < 5; j++)
//    //    {
//    //        if (gameObject.CompareTag("Layer1"))
//    //        {
//    //            //Debug.Log("Layer1 called.");
//    //        }
//    //    }
//    //    //if(delay_arr.Length > )

//    //    //if (delay_arr.Length == 1) {
//    //    //    delay_arr[0] = 0.09f;
//    //    //}
//    //    //else if (delay_arr.Length == 2)
//    //    //{
//    //    //    delay_arr[0] = 0.09f;
//    //    //    delay_arr[1] = 0.13f;
//    //    //}
//    //    //else if (delay_arr.Length == 3)
//    //    //{
//    //    //    delay_arr[0] = 0.09f;
//    //    //    delay_arr[1] = 0.13f;
//    //    //    delay_arr[2] = 0.17f;
//    //    //}
//    //    //else if (delay_arr.Length == 4)
//    //    //{
//    //    //    delay_arr[0] = 0.09f;
//    //    //    delay_arr[1] = 0.13f;
//    //    //    delay_arr[2] = 0.17f;
//    //    //    delay_arr[3] = 0.21f;
//    //    //}
//    //    //else if (delay_arr.Length == 5)
//    //    //{
//    //    //    delay_arr[0] = 0.09f;
//    //    //    delay_arr[1] = 0.13f;
//    //    //    delay_arr[2] = 0.17f;
//    //    //    delay_arr[3] = 0.21f;
//    //    //    delay_arr[4] = 0.25f;
//    //    //}

//    //    Debug.Log(delay_arr.Length);

//    //    for (float timer = 0; timer < 4f; timer += Time.deltaTime)
//    //    {
//    //        for (int i = 0; i < delay_arr.Length; i++)
//    //        {
//    //            Debug.Log(timer);
//    //            button[i].SetActive(false);
//    //            yield return new WaitForSeconds(delay_arr[i]);
//    //            button[i].SetActive(true);
//    //            yield return new WaitForSeconds(delay_arr[i]);
//    //        }
//    //    }

//    //    yield return null;
//    //}

//}