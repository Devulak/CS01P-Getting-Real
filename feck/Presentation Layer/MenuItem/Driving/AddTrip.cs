﻿using Domain_Layer.Compensation;
using Domain_Layer.Expense;
using SmartMenuLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer.MenuItem
{
    class AddDrivingExpense : IMenuItem
    {
        private Driving DrivingCompensation;

        public AddDrivingExpense(Driving drivingCompensation)
        {
            DrivingCompensation = drivingCompensation;
        }

        public bool Activate(SmartMenu smartMenu)
        {
            string title =  Request.String("Titel på bekostningen");
            string description = Request.String("Beskrivelse på bekostningen");
            string departureDestination = Request.String("Hvor kørte du fra?");
            DateTime departureDate = Request.DateTime(string.Format("Hvornår kørte du fra {0}?", departureDestination));
            string arrivalDestination = Request.String("Hvor kørte du til?");
            DateTime arrivalDate = Request.DateTime(string.Format("Hvornår kom du til {0}?", arrivalDestination));
            int distance = Request.Int("Hvor mange kilometer (i hele tal)?");

            Trip drivingExpense = new Trip(title, description, departureDestination, departureDate, arrivalDestination, arrivalDate, distance);
            DrivingCompensation.AddExpense(drivingExpense);

            smartMenu.Attach(new EditTrip(DrivingCompensation, drivingExpense));

            return false;
        }

        public override string ToString() => "Tilføj ny bekostning";
    }
}
