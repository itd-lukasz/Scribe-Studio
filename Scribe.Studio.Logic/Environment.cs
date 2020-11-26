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

        public string Server
        {
            get { return connection == null ? "" : connection.Server; }
        }

        public string Database
        {
            get { return connection == null ? "" : connection.Database; }
        }

        public string WindowsAuthentication
        {
            get { return connection == null ? "" : connection.WindowsAuth.ToString(); }
        }

        public string User
        {
            get { return connection == null ? "" : connection.User; }
        }

        public string Password
        {
            get { return connection == null ? "" : connection.Password; }
        }

        public Environment(string name, Color color, string server, string database, bool windowsAuth, string user = null, string password = null)
        {
            this.name = name;
            this.color = color;
            connection = new Connection(server, database, windowsAuth, user, password);
        }
    }
}
