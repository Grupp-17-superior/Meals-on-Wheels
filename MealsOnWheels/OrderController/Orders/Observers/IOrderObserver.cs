using System;
using System.Collections.Generic;
using System.Text;
namespace MealsOnWheels;

public interface IOrderObserver
{
	void Update(Order order);
}