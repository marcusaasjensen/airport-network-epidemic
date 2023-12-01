using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [Range(0,100)]
    public float contaminationRate;
    [Range(1, 60)]
    public float dt;
}
