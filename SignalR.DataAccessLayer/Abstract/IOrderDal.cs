﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IOrderDal:IGenericDal<Order>
	{
		int TotalOrderCount();
		int ActiviteOrderCount();
		decimal LastOrderPrice();

		decimal TodayTotalPrice();
	}
}
