using UnityEngine;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    [Header("Referências")]
    public GameObject heartPointPrefab;
    public Transform heartBar;

    [Header("Configuração")]
    public int maxHealth = 5;
    private int currentHealth;
    public Rigidbody2D rg;
    private CharacterController2D characterController;


    private List<GameObject> hearts = new List<GameObject>();

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        characterController = GetComponent<CharacterController2D>();
        
        currentHealth = maxHealth;
        GenerateHearts();
    }

    void GenerateHearts()
    {
        foreach (Transform child in heartBar)
            Destroy(child.gameObject);
        hearts.Clear();

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPointPrefab, heartBar);
            hearts.Add(heart);
        }
    }

    public void TakeDamage(int amount)
    {
        rg.linearVelocity += new Vector2(-50, 10);

        currentHealth = Mathf.Max(currentHealth - amount, 0);
        UpdateHeartsVisual();
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHeartsVisual();
    }

    void UpdateHeartsVisual()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }

    public void SetMaxHealth(int newMax)
    {
        maxHealth = newMax;
        currentHealth = maxHealth;
        GenerateHearts();
    }
}
