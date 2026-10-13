using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public interface IOrderState
{
    void Next(Order order);
    void Cancel(Order order);
    string GetStatusName();
}
