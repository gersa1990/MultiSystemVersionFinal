using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace MultiSystem
{
    public class Connection
    {
        public string MyConnectionString;

        public Connection(String database)
        {
            MyConnectionString = "Server=localhost;Database=" + database + ";Uid=root;Pwd=''";
        }
    }
}