using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Seaeees.GUGUI.Tween
{
    public static class Tween
    {
        public static IEnumerator AnimateScale(this RectTransform obj, Vector2 to, float interval,EaseType ease)
        {
            if(!obj) yield break;
            Vector2 pos = obj.sizeDelta;
            float timer = 0;
            while (timer <= interval) {
                if (interval == 0) break;
                obj.sizeDelta = new Vector2(Ease.LerpWhithEase (pos.x, to.x, timer / interval,ease),Ease.LerpWhithEase (pos.y, to.y, timer / interval,ease));      
                timer += Time.deltaTime;
                yield return 0;
            }
            obj.sizeDelta = to;
        }
        
        public static IEnumerator AnimateColor(this Image obj, Color to, float interval)
        {
            if(!obj) yield break;
            Color col = obj.color;
            float timer = 0;
            while (timer <= interval)
            {
                if (interval == 0) break;
                //TODO:カラーのイージング
                obj.color = Color.Lerp(col, to, timer / interval);      
                timer += Time.deltaTime;
                yield return 0;
            }
            obj.color = to;
        }
        
        public static IEnumerator AnimateFillAmount(this Image obj, float to, float interval, EaseType ease)
        {
            if(!obj) yield break;
            float fill = obj.fillAmount;
            float timer = 0;
            while (timer <= interval)
            {
                if (interval == 0) break;
                obj.fillAmount = Ease.LerpWhithEase(fill, to, timer / interval,ease);      
                timer += Time.deltaTime;
                yield return 0;
            }
            obj.fillAmount = to;
        }
    }
}