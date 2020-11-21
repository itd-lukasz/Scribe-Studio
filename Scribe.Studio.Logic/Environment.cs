using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class Environment
    {
        private string name;
        private Color color;
        private Connection connection;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Connection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public Environment(string name, Color color, string server, string database, bool windowsAuth, string user = null, string password = null)
        {
            this.name = name;
            this.color = color;
            connection = new Connection(server, password, windowsAuth, user, password);
        }
    }
}
