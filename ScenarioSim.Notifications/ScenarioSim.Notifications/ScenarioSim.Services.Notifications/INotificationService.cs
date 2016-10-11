using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Services.Notifications
{
    public interface INotificationService
    {
        /// <summary>
        /// Pushes the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        void Push(Notification notification);
    }
}
