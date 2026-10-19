using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public class Leveranstjanst
{

    private List<Leveransbud> _budLista;


    public Leveranstjanst()
    {
        _budLista = new List<Leveransbud>();
    }


    public void LaggTillBud(Leveransbud bud)
    {
        if(bud == null)
        {
            throw new ArgumentException("Ogiltigt bud.");
        }


    }


    public Leveransbud TilldelaBud(Order order)
    {
        
    }
}