using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckersMPApp.Classes.Model.Entities
{
    public class ServerInfo
    {
        public Boolean online
        {
            get;
            private set;
        }
        public String onlineText
        {
            get
            {
                return this.online ? "Online" : "Offline";
            }
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

        public string playerCountString
        {
            get
            {
                return String.Format("{0} / {1} players", this.playerCountCurrent, this.playerCountCapacity);
            }
        }

        public double playerCountRatio
        {
            get
            {
                return playerCountCapacity == 0 ? playerCountCapacity : playerCountCurrent / playerCountCapacity;
            }
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
