using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApp
{
    class Program
    {
        private static BeneficiaryDetails beneficiaryDetails = new BeneficiaryDetails();
        private static List<BeneficiaryDetails> beneficiaries = new List<BeneficiaryDetails>();
        static void Main(string[] args)
        {
            BeneficiaryDetails bd = new BeneficiaryDetails();
            BeneficiaryDetails beneficiary1 = new BeneficiaryDetails("Elanchezhiyan",9488224598,"Annamalai Nagar",22,1);
            BeneficiaryDetails beneficiary2 = new BeneficiaryDetails("Divagar", 8248214298, "Thiruvanmalai", 22, 1);
            beneficiary1.VaccineDetails(1, DateTime.Now);
            beneficiary2.VaccineDetails(2, DateTime.Now);
            beneficiaries.Add(beneficiary1);
            beneficiaries.Add(beneficiary2);
            int age, choice;
            string Name, City;
            long PhoneNumber;
        main:
            Console.WriteLine("***************************************");
            Console.WriteLine("Welcome to Vaccination Process");
            Console.WriteLine("***************************************");
            Console.WriteLine("Enter Your Option :");
            Console.WriteLine("1.Beneficiary Registration \n2.Vaccination \n3.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            do
            {
                if (choice == 1 || choice == 2 || choice == 3)
                {
                    if (choice == 1)
                    {
                        Console.WriteLine("Enter Your Name : ");
                        Name = Console.ReadLine();
                        Console.WriteLine("Enter Your PhoneNumber : ");
                        PhoneNumber = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter your Address : ");
                        City = Console.ReadLine();
                        Console.WriteLine("Enter your Age : ");
                        age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your Gender  \n1.Male\n2.Female\n3.Other: ");
                        int Gender = Convert.ToInt32(Console.ReadLine());
                         bd = new BeneficiaryDetails(Name, PhoneNumber, City, age, Gender);
                        Console.WriteLine("On Completion of Beneficiary Registration Number is \n" + bd.RegistrationID);
                        beneficiaries.Add(bd);
                       
                        goto main;
                    }
                    else if (choice == 2)
                    {
                        foreach(BeneficiaryDetails details in beneficiaries)
                        {
                            Console.WriteLine("Registration ID : " + details.RegistrationID + " Beneficiary Name : " + details.Name);
                        }
                        Console.WriteLine("Enter your Registration ID ");
                        int registerNumber = Convert.ToInt32(Console.ReadLine());
                        foreach (BeneficiaryDetails ben in beneficiaries)
                        {
                            if ( registerNumber== ben.RegistrationID)
                            {
                                beneficiaryDetails=ben;

                            }
                        }

                    aa:
                        
                        Console.WriteLine("Select Your Options");
                        Console.WriteLine("a.Take vaccination \nb.Vaccination History \nc.NextDueDate \nd.Exit");
                        string choice1 = Console.ReadLine();
                        switch (choice1)
                        {
                            case "a":
                                TakeVaccination();
                                goto aa;

                            case "b":
                                VaccinationHistory();
                                goto aa;
                            case "c":
                                Console.WriteLine(beneficiaryDetails.NextDueDate());
                                goto aa;
                            case "d":
                                goto main;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;

                        }
                        if (beneficiaryDetails.RegistrationID == 0)
                        {
                            Console.WriteLine("Invalid Registration Number \nPlease Enter valid one");
                        }

                    }
                    else if (choice == 3)
                    {
                        System.Environment.Exit(0);
                    }

                }

                
            } while (choice != 3);
            Console.ReadLine();
        }
        private static void TakeVaccination()
        {
            
            Console.WriteLine("Choose your Vaccine:\n1.Covaxin\n2.Covishield\n3.Sputnik");
            int vaccineType = Convert.ToInt32(Console.ReadLine());
            if (beneficiaryDetails.Vaccines.Count == 0)
            {
                Console.WriteLine("Enter your Date in the format of dd/mm/yyyy ");
                DateTime dateTime =DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.WriteLine("You are Vaccinated "+beneficiaryDetails.VaccineDetails(vaccineType, dateTime));
            }
            else if (beneficiaryDetails.Vaccines.Count == 1)
            {
               
                    Console.WriteLine("Enter your Date in the format of dd/mm/yyyy ");
                    DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    Console.WriteLine(beneficiaryDetails.VaccineDetails(vaccineType, dateTime));
            
            }
        }
        private static void VaccinationHistory()
        {
            foreach(VaccineDetails vaccine in beneficiaryDetails.Vaccines) 
            {
                Console.WriteLine("Vaccine : {0} \nDosage : {1} dose \nDate : {2}",vaccine.Vaccine,vaccine.Dosage,vaccine.DoseTime.ToString("dd/MM/yyyy"));
            }

        }
    }
}
