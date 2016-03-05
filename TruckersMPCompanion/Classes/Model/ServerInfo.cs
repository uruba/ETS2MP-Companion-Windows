using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckersMPApp.Classes.Model
{
    public class ServerInfo
    {
        public Boolean online
        {
            get;
            private set;
        }
        public String gameName
        {
            get;
            private set;
        }
        public String serverName
        {
            get;
            private set;
        }
        public double playerCountCurrent
        {
            get;
            private set;
        }
        public double playerCountCapacity
        {
            get;
            private set;
        }

        public ServerInfo(Boolean online, String gameName, String serverName, double playerCountCurrent, double playerCountCapacity)
        {
            this.online = online;
            this.gameName = gameName;
            this.serverName = serverName;
            this.playerCountCurrent = playerCountCurrent;
            this.playerCountCapacity = playerCountCapacity;
        }
    }
}
