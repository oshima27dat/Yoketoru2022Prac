using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChanger : MonoBehaviour
{
    [Tooltip("�炷BGM"), SerializeField]
    TinyAudio.BGM bgm = TinyAudio.BGM.Gameover;

    void Start()
    {
        TinyAudio.PlayBGM(bgm);
    }
}
