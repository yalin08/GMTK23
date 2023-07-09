using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using DG.Tweening;
public class BoneManager : Singleton<BoneManager>
{
    public int Bones;
    public TMPro.TextMeshProUGUI textMesh;

    private void Start()
    {
        GainBones(0);
    }

    public void SpendBones(int bone)
    {
        Bones -= bone;
        if (Bones < 0)
            Bones = 0;
        textMesh.transform.DOKill();
        textMesh.transform.localScale = Vector3.one;
        textMesh.transform.DOScale(1.3f, 0.2f).OnComplete(firstTween);
        textMesh.text = ""+Bones;
    }

    void firstTween()
    {
        textMesh.transform.DOScale(1f, 0.2f);
    }

    public void GainBones(int bone)
    {

       

        Bones += bone;

        textMesh.transform.DOKill();
        textMesh.transform.localScale = Vector3.one;
        textMesh.transform.DOScale(1.3f, 0.2f).OnComplete(firstTween);

        textMesh.text = "" + Bones;
    }
}
