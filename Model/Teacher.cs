using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Teacher: Entity
    {
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        //public string TrainerId { get; set; }

        public string Courses { get; set; }

        
        public double TotalCredit { get; set; }  


    }
}
