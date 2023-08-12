using System.Collections;
using UnityEngine;
//converting to UColor to avoid confusion with namespace Color
using UColor = UnityEngine.Color;

namespace Game.Ground.Color
{
    public class GroundColor : MonoBehaviour
    {
        public SpriteRenderer[] spriteRenderers;
        private UColor[] colors;

        private void Start()
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

            colors = new UColor[]{
                UColor.magenta,
                UColor.red,
                UColor.green,
                UColor.blue,
                UColor.yellow,
                UColor.cyan,
            };

            StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            int index = 0;
            while (true)
            {
                if(GetColorDifference(spriteRenderers[0].color, colors[index]) < 0.1f)
                {
                    index++;
                    if (index >= colors.Length)
                    {
                        index = 0;
                    }
                }

                foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                {
                    spriteRenderer.color = UColor.LerpUnclamped(spriteRenderer.color, colors[index], Time.deltaTime);
                }
                yield return new WaitForEndOfFrame();
            }
        }

        private float GetColorDifference(UColor color1, UColor color2)
        {
            return Mathf.Abs(color1.r - color2.r) + Mathf.Abs(color1.g - color2.g) + Mathf.Abs(color1.b - color2.b);
        }
    }
}
