using System.Collections;
using System.Collections.Generic;
using FutureGames.TurnBasedRPG;
using UnityEngine;

public class Projectile : MonoBehaviour
{



    public void Init(Vector3 startPoint , Vector3 hitPoint, float duration, float rangedArcHeight)
    {
        StartCoroutine(FireProjectile(startPoint, hitPoint, duration, rangedArcHeight));
    }
    
    private IEnumerator FireProjectile(Vector3 startPoint , Vector3 hitPoint, float duration, float rangedArcHeight)
    {
        float t = 0;
        GameObject rangedObject = gameObject;
        
        while (t < duration)
        {
            Vector3 middlePoint = startPoint + hitPoint / 2;
            Vector3 arcTop = new Vector3(middlePoint.x, middlePoint.y + rangedArcHeight, middlePoint.z);
            Vector3 lerpPoint1 = Vector3.Lerp(startPoint, arcTop, t);
            Vector3 lerpPoint2 = Vector3.Lerp(arcTop, hitPoint, t);
            rangedObject.transform.position = Vector3.Lerp(lerpPoint1, lerpPoint2, t);
                
            t += Time.deltaTime;
                
            yield return null;
        }
        Destroy(rangedObject);
    }

}
