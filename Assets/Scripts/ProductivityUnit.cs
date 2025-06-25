using UnityEngine;

public class ProductivityUnit : Unit
{

    ResourcePile currentPile = null;

    public float productivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        if (currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                currentPile = pile;
                currentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    void Resetproductivity()
    {
        if (currentPile != null)
        {
            currentPile.ProductionSpeed /= productivityMultiplier;
            currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        base.GoTo(target);
        Resetproductivity();
        
    }

    public override void GoTo(Vector3 position)
    {
        base.GoTo(position);
        Resetproductivity();
    }

}
