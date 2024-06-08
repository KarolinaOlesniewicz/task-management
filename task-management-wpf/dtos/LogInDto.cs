using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_management_wpf.dtos
{
    public class LogInDto
    {
        public string username { get; set; }
        public string password { get; set; }
        public LogInDto(string _username,string _password)
        {
            username = _username;
            password = _password;
        }
    }
}
