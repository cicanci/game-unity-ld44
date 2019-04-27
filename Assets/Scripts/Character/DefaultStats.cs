using UnityEngine;

[CreateAssetMenu(fileName = "NewDefaultStats", menuName = "New Default Stats", order = 51)]
public class DefaultStats : ScriptableObject
{
    [Header("Base Attributes")]

    [Range(0, 100)]
    public float Life;

    [Range(0, 10)]
    public float Attack;

    [Range(0, 10)]
    public float Defense;

    [Range(0, 10)]
    public float Experience;

    [Range(0, 10)]
    public float Speed;

    [Header("Increment Rate")]

    [Range(0, 10)]
    public float LifeRate;

    [Range(0, 10)]
    public float AttackRate;

    [Range(0, 10)]
    public float DefenseRate;

    [Range(0, 10)]
    public float ExperienceRate;

    [Range(0, 10)]
    public float SpeedRate;

    [Header("Upgrade Cost")]

    [Range(0, 10)]
    public float LifeCost;

    [Range(0, 10)]
    public float AttackCost;

    [Range(0, 10)]
    public float DefenseCost;

    [Range(0, 10)]
    public float ExperienceCost;

    [Range(0, 10)]
    public float SpeedCost;
}
