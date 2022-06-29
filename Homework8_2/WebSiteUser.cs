using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_2
{
    class WebSiteUser
    {
        private string ip;
        private DateTime time;
        private DayOfWeek day;

        public string Ip { get => ip; }
        public DateTime Time { get => time; }
        public DayOfWeek Day { get => day; }

        public WebSiteUser(string ip, DateTime time, DayOfWeek day)
        {
            this.ip = ip;
            this.time = time;
            this.day = day;
        }

        public WebSiteUser() : this(default, default, default)
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"ip: {ip}, time: {time}, day: {day}";
        }
    }
}
