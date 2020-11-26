using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class Connection
    {
        private string server;
        private string database;
        private bool windowsAuth;
        private string user;
        private string password;

        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        public string Database
        {
            get { return database; }
            set { database = value; }
        }

        public bool WindowsAuth
        {
            get { return windowsAuth; }
            set { windowsAuth = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Connection(string server, string database, bool windowsAuth, string user = null, string password = null)
        {
            this.server = server;
            this.database = database;
            this.windowsAuth = windowsAuth;
            this.user = user;
            this.password = password;
        }
    }
}
