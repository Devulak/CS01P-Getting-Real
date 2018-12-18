﻿using Domain_Layer;
using Domain_Layer.Compensation;
using Presentation_Layer.MenuItem;
using SmartMenuLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    class CreateDriving : IMenuItem
    {
        private Department Department;

        public CreateDriving(Department department)
        {
            Department = department;
        }

        public bool Activate(SmartMenu smartMenu)
        {
            string title = Request.String("Kørsels godtgørelse titel");
            DrivingCompensation drivingCompensation = new DrivingCompensation(title);

            SmartMenu sm = new SmartMenu(drivingCompensation.Title, "Anullér");

            sm.Attach(new AddDrivingExpense(drivingCompensation));

            sm.Attach(new AddCompensationToDepartment(Department, drivingCompensation));
            
            sm.Activate();
            
            return false;
        }

        public override string ToString()
        {
            return "Opret kørsels godtgørelse";
        }
    }
}