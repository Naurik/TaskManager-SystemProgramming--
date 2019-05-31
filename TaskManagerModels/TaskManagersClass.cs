using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerModels
{
    public class TaskManagersClass
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Status { get; set; }
        public string UsersName { get; set; }
        public string Processor { get; set; }
        public int Memory { get; set; }
        public string Description { get; set; }
    }
}
