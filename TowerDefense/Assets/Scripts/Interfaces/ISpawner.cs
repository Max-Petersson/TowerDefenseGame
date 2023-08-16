using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    void SpawnNextWave(int waveCount); // maybe add enemy types!
}
