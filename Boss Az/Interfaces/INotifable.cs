using Boss.ModelsNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Interfaces {
    public interface INotifable {
        public void addNotification(Notification notification);
    }
}
