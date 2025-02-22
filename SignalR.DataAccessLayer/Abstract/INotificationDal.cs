﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface INotificationDal:IGenericDal<Notification>
	{
		int NotificationCountBySatatusFalse();
		List<Notification> GetAllNotificationsByFalse();

		void NotificationStatusChangeToTrue(int id);
        void NotificationStatusChangeToFalse(int id);

    }
}
