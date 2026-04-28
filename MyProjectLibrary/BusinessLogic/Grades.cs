using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.BusinessLogic
{
    public class Grades
    {
        public string GetGrades(int percentage)
        {
            if (percentage >= 80 && percentage <= 100)
            {
                return "A";
            }
            else if (percentage >= 60 && percentage < 80)
            {
                return "B";
            }
            else if (percentage >= 40 && percentage < 60)
            {
                return "C";
            }
            else
            {
                return "Fail";
            }
        }

        public bool Isvalid(int Age) {
            if (Age > 18)
            {
                return true;
            }
            else
                return false;
        }

        // inserting data --> no of effeted from db 1
        //return 1

    }
}
