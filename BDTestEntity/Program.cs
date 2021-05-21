using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BDTestEntity.Models;

namespace BDTestEntity
{
    class Program
    {
        static void ReadAllDoctor()
        {
            using (HospitalContext db = new HospitalContext())
            {
                var doctors = db.Doctor.Join(db.Specialization, p => p.SpecializationId, c => c.Id, (p, c) => new
                {
                    LastName = p.LastName,
                    FirstName = p.FirstName,
                    Expirience = p.Experience,
                    SpecializationDoctor = c.TitleSpecialization
                });
                foreach (var p in doctors)
                {
                    Console.WriteLine("{0},{1},{2},{3}", p.LastName, p.FirstName, p.Expirience, p.SpecializationDoctor);
                }

                static void ReadAllPatient()
                {
                    using (HospitalContext db = new HospitalContext())
                    {
                        var patients = db.Patient.ToList();
                        foreach (var patient in patients)
                        {
                            Console.WriteLine(string.Join(" ", patient.FirstName, patient.LastName, patient.Age, patient.Adress, patient.Complaints));
                        }
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            //ReadAllPatient();
            ReadAllDoctor();
        }
    }
}

