using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LifeState
{
    Life = 0,
    Death = 1,
}

public enum NextLifeState
{
    Maintain = 0,
    NextLife = 1,
    NextDeath = 2,
}

public class Cell : MonoBehaviour
{
    [SerializeField] LifeState m_lifeState = LifeState.Death;
    [SerializeField] NextLifeState m_nextLifeState = NextLifeState.Maintain;
    [SerializeField] Image m_imaage = null;
    public int m_row;
    public int m_col;

    public LifeState LifeState
    {
        get => m_lifeState;
        set
        {
            m_lifeState = value;
            OnLifeOrDeath();
        }
    }

    public NextLifeState NextLifeState
    {
        get => m_nextLifeState;
        set
        {
            m_nextLifeState = value;

        }
    }

    private void OnValidate()
    {
        OnLifeOrDeath();
    }

    private void OnLifeOrDeath()
    {
        if (m_lifeState == LifeState.Death)
        {
            m_imaage.color = Color.white;
        }
        else
        {
            m_imaage.color = Color.black;
        }
    }

    public void GetCoordinate(int row, int col)
    {
        m_row = row;
        m_col = col;
    }


    public void Next()
    {
        if (this.NextLifeState == NextLifeState.NextLife)
        {
            this.LifeState = LifeState.Life;
        }
        else if (this.NextLifeState == NextLifeState.NextDeath)
        {
            this.LifeState = LifeState.Death;
        }
    }
}
