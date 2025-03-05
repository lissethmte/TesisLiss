using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonAnims
{
    ScaleUp,
    ScaleDown,
    MoveFromLeft,
    MoveFromRight,
    MoveFromUp,
    MoveFromDown,
    CustomScale,
    CustomPos,
    IdleBreathing, // ?? Nuevo estado para la animación de respiración
}

public class ButtonAnimations : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = .5f;
    private Vector3 scale;
    private Vector3 pos;

    public Vector3 customFromScale;
    public Vector3 customFromPos;
    public ButtonAnims anims;
    public float delayTime;

    public float breathingIntensity = 0.1f; // ?? Controla cuánto se expande el texto al "respirar"
    public float breathingSpeed = 1f; // ?? Controla la velocidad de la respiración

    void Start()
    {
        scale = gameObject.transform.localScale;
        pos = gameObject.transform.position;
        SwitcherPrep();
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        SwitcherAnimation();
    }

    public void SwitcherPrep()
    {
        switch (anims)
        {
            case ButtonAnims.ScaleUp:
                gameObject.transform.localScale = Vector3.zero;
                return;
            case ButtonAnims.ScaleDown:
                return;
            case ButtonAnims.MoveFromLeft:
                gameObject.transform.position = new Vector3(pos.x - Screen.width, pos.y, pos.z);
                return;
            case ButtonAnims.MoveFromRight:
                gameObject.transform.position = new Vector3(pos.x + Screen.width, pos.y, pos.z);
                return;
            case ButtonAnims.MoveFromUp:
                gameObject.transform.position = new Vector3(pos.x, pos.y + Screen.height, pos.z);
                return;
            case ButtonAnims.MoveFromDown:
                gameObject.transform.position = new Vector3(pos.x, pos.y - Screen.height, pos.z);
                return;
            case ButtonAnims.CustomPos:
                gameObject.transform.position = customFromPos;
                return;
            case ButtonAnims.CustomScale:
                gameObject.transform.localScale = customFromScale;
                return;
            case ButtonAnims.IdleBreathing:
                gameObject.transform.localScale = scale;
                return;
            default:
                Debug.Log("No Se eligió un ButtonAnims Válido");
                return;
        }
    }

    public void SwitcherAnimation()
    {
        switch (anims)
        {
            case ButtonAnims.ScaleUp:
                ScaleUp();
                return;
            case ButtonAnims.ScaleDown:
                ScaleDown();
                return;
            case ButtonAnims.MoveFromLeft:
                MoveFromLeft();
                return;
            case ButtonAnims.MoveFromRight:
                MoveFromRight();
                return;
            case ButtonAnims.MoveFromUp:
                MoveFromUp();
                return;
            case ButtonAnims.MoveFromDown:
                MoveFromDown();
                return;
            case ButtonAnims.CustomPos:
                MoveFromCustom();
                return;
            case ButtonAnims.CustomScale:
                ScaleFromCustom();
                return;
            case ButtonAnims.IdleBreathing:
                IdleBreathing(); // ?? Activa el loop infinito de respiración
                return;
            default:
                Debug.Log("No Se eligió un ButtonAnims Válido");
                return;
        }
    }

    public void ScaleDown()
    {
        LeanTween.scale(gameObject, Vector3.zero, duration).setEase(curve);
    }

    public void ScaleUp()
    {
        LeanTween.scale(gameObject, scale, duration).setEase(curve);
    }

    public void MoveFromLeft()
    {
        LeanTween.move(gameObject, pos, duration).setEase(curve);
    }

    public void MoveFromRight()
    {
        LeanTween.move(gameObject, pos, duration).setEase(curve);
    }

    public void MoveFromUp()
    {
        LeanTween.move(gameObject, pos, duration).setEase(curve);
    }

    public void MoveFromDown()
    {
        LeanTween.move(gameObject, pos, duration).setEase(curve);
    }

    public void MoveFromCustom()
    {
        LeanTween.move(gameObject, pos, duration).setEase(curve);
    }

    public void ScaleFromCustom()
    {
        LeanTween.scale(gameObject, scale, duration).setEase(curve);
    }

    public void IdleBreathing()
    {
        
        LeanTween.scale(gameObject, scale * (1 + breathingIntensity), breathingSpeed)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();
    }
}
