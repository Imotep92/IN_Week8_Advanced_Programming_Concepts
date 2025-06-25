using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;

    #region EXAMPLE OF ENCAPULATION
    private float m_ProductionSpeed = 0.5f; /* Private 'backing field' which will use the value produced by 'Get and set' method
    below */ 

    public float ProductionSpeed
    {

        get { return m_ProductionSpeed; }

        set
        {
            if (value < 0)
            {
                Debug.LogError("Productivity cannot be a negative number");
            }
            else
            {
                m_ProductionSpeed = value;
            }
        }
    
    }
    #endregion EXAMPLE OF ENCAPULATION

    private float m_CurrentProduction = 0.0f;

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += m_ProductionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing at the speed of {m_ProductionSpeed}/s";
        
    }
    
    
}
