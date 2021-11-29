using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApp
{
    public class BeneficiaryDetails
    {
        //Creating the Properties for BeneficiaryDetails 
        public string Name { get; set; }
        public int RegistrationID { get; set; }
        private static int _regNo = 1001;
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Gender Genders { get; set; }
        public List<VaccineDetails> Vaccines = new List<VaccineDetails>();
        // The Different types of Gender
        public enum Gender
        {
            Male,
            Female,
            Other
        }
        //Method for VaccineDetails
        public string VaccineDetails(int vaccine,DateTime time)
        {
            
            if (Vaccines.Count == 0)
            {
                VaccineDetails vaccineDetails = new VaccineDetails(vaccine, time, 1);
                Vaccines.Add(vaccineDetails);
               return String.Format("Your Next Dose Due time is "+vaccineDetails.DoseTime.AddDays(30).ToString("dd/MM/yyyy"));
            }
            else if (Vaccines.Count == 1)
            {
                if (Vaccines[0].DoseTime > Vaccines[0].DoseTime.AddDays(30))
                {
                    VaccineDetails vaccine1 = new VaccineDetails(vaccine,time,2);
                    Vaccines.Add(vaccine1);
                    return String.Format("You have completed the vaccination course. Thanks for your participation in the vaccination drive.");
                }
                else
                {
                    return String.Format("You are not allowed because there is your Second dose due date is " +Vaccines[0].DoseTime.AddDays(30).ToString("dd/MM/yyyy"));
                }

            }
            else
            {
                return String.Format("You had 2 doses already .");
            }
            
        }
      //Method for Next Due Date
        public string NextDueDate()
        {
            if (Vaccines.Count == 1)
            {
                return String.Format("Your Next dose due time is "+Vaccines[0].DoseTime.AddDays(30).ToString("dd/MM/yyyy"));
            }
            else
            {
                return String.Format("You have completed the vaccination course. Thanks for your participation in the vaccination drive.");
            }

        }
        //Default Constructor for BeneficiaryDetails
        public BeneficiaryDetails()
        {

        }
        //Parameterised Constructor for Beneficiary Details
        public BeneficiaryDetails(string Name, long PhoneNo, string Address, int age, int gender)
        {
            this.Name = Name;
            this.RegistrationID = _regNo++;
            this.PhoneNumber = PhoneNo;
            this.Age = age;
            this.Address = Address;
            this.Genders = (Gender)gender;


        }
    }
}
