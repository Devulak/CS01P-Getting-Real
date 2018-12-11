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
    class EditDrivingExpense : IMenuItem
    {
        private Compensation Compensation;
        private DrivingExpense DrivingExpense;
        
        public EditDrivingExpense(Compensation compensation, DrivingExpense drivingExpense)
        {
            Compensation = compensation;
            DrivingExpense = drivingExpense;
        }

        public bool Activate(SmartMenu smartMenu)
        {
            string description = string.Format(
                "{0}\n{1}\n{2}\n{3}\n{4}\n{5}",
                DrivingExpense.Description,
                DrivingExpense.DepartureDestination,
                DrivingExpense.DepartureDate,
                DrivingExpense.ArrivalDestination,
                DrivingExpense.ArrivalDate,
                DrivingExpense.Distance
            );

            SmartMenu sm = new SmartMenu(DrivingExpense.Title, "Tilbage", description);

            sm.Add(new RemoveExpense(Compensation, DrivingExpense));


            int countExpenses = Compensation.CountExpenses();

            sm.Activate();

            if (countExpenses > Compensation.CountExpenses())
            {
                smartMenu.Remove(this);
            }

            return false;
        }

        public override string ToString() => string.Format("Se {0}", DrivingExpense.Title);
    }
}
