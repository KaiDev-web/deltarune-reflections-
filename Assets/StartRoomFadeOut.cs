using System.Collections;
using UnityEngine;

namespace Assets
{
    public class StartRoomFdeOut : MonoBehaviour
    {
        public SpriteRenderer transition;

        public void Start()
        {
            StartCoroutine(FadeOut());
        }

        IEnumerator FadeOut()
        {
            Debug.Log("Loading ciclo: Fade Out");
            float alphaVal = transition.color.a;
            Color tmp = transition.color;

            while (transition.color.a > 0)
            {
                alphaVal -= 0.02f;
                tmp.a = alphaVal;

                transition.color = tmp;

                yield return new WaitForSeconds(0.02f);

            }

        }
    }
}