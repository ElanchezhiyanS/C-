using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApp
{
    public class VaccineDetails
    {
        //The Different types of Vaccine Names are here 
        public enum VaccineName
        {
            Covishield,
            Covaxin,
            Sputnik

        }
        //Creating the properties for Vaccine Details
        public int Dosage { get; set; }
        public DateTime DoseTime { get; set; }
        public VaccineName Vaccine { get; set; }
        public VaccineDetails()
        {

        }
        //Parameterised Constructor for VaccineDetails
        public VaccineDetails(int vaccine, DateTime doseTime, int doseCount)
        {
            this.Vaccine = (VaccineName)vaccine;
            this.DoseTime = doseTime;
            this.Dosage = doseCount;
        }
    }
}

