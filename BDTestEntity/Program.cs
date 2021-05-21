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
        static void ReadAllHospital()
        {
            using(HospitalContext db=new HospitalContext())
            {
                Console.WriteLine("Список больниц:");
                var hospitals = db.Hospital.ToList();
                foreach (var hospital in hospitals)
                {
                    Console.WriteLine(string.Join(" ", hospital.Number, hospital.Address));
                }
            }
        }

        static void ReadAllDoctor()
        {
            using (HospitalContext db = new HospitalContext())
            {
                Console.WriteLine("Список докторов:");
                var doctors = db.Doctor.Join(db.Specialization, d => d.SpecializationId, s => s.Id, (d, s) => new
                {
                    LastName = d.LastName,
                    FirstName = d.FirstName,
                    Expirience = d.Experience,
                    SpecializationDoctor = s.TitleSpecialization
                });
                foreach (var doctor in doctors)
                {
                    Console.WriteLine("{0},{1},{2},{3}", doctor.LastName, doctor.FirstName, doctor.Expirience, doctor.SpecializationDoctor);
                }
            }
        }
        
        static void ReadAllPatient()
        {
            using (HospitalContext db = new HospitalContext())
            {
                Console.WriteLine("Список пациенов:");
                var patients = db.Patient.ToList();
                foreach (var patient in patients)
                {
                    Console.WriteLine(string.Join(" ", patient.FirstName, patient.LastName, patient.Age, patient.Adress, patient.Complaints));
                }
            }
        }

        static void AddHospital()
        {
            Hospital hospital = new Hospital();
            hospital.Number = Console.ReadLine();
            hospital.Address = Console.ReadLine();
            using (HospitalContext db=new HospitalContext())
            {
                Console.WriteLine("Список типов больниц");
                var hospitalTypes = db.HospitalType.ToList();
                foreach(var hospitalType in hospitalTypes)
                {
                    Console.WriteLine(string.Join(" ", hospitalType.Id, hospitalType.Name));
                }
            }
            hospital.HospitalTypeId = Convert.ToInt32(Console.ReadLine());
            using (HospitalContext db = new HospitalContext())
            {
                db.Hospital.Add(hospital);
                db.SaveChanges();
            }
        }

        static void AddDoctor()
        {
            Doctor doctor = new Doctor();
            doctor.FirstName = Console.ReadLine();
            doctor.LastName = Console.ReadLine();
            doctor.Experience = Convert.ToByte(Console.ReadLine());
            using (HospitalContext db = new HospitalContext())
            {
                Console.WriteLine("Список типов специальностей");
                var categorys = db.Category.ToList();
                foreach (var category in categorys)
                {
                    Console.WriteLine(string.Join(" ", category.Id, category.TitleСategory));
                }
            }
            doctor.CategoryId = Convert.ToInt32(Console.ReadLine());

            using (HospitalContext db = new HospitalContext())
            {
                db.Doctor.Add(doctor);
                db.SaveChanges();
            }

        }

        static void AddPatient()
        {
            Patient patient = new Patient();
            patient.FirstName = Console.ReadLine();
            patient.LastName = Console.ReadLine();
            patient.Adress = Console.ReadLine();
            patient.Age = Convert.ToByte(Console.ReadLine());
            patient.Complaints = Console.ReadLine();
        }

        static void AttachingDoctorToHospital()
        {
            string doc = Console.ReadLine();
            using (HospitalContext db=new HospitalContext())
            {
                var doctors = db.Doctor.FirstOrDefault(d => d.FirstName == doc);
                doctors.HospitalId = Convert.ToInt32(Console.ReadLine());
                doctors.Salary = Convert.ToInt32(Console.ReadLine());
                db.SaveChanges();
            }
        }
        
        static void DellitHospital()
        {
            using(HospitalContext db =new HospitalContext())
            {
                string hospitalNumber = Console.ReadLine();
                var hospital = db.Hospital.Where(h => h.Number == hospitalNumber).ToList();
                if(hospital != null)
                {
                    db.Hospital.Remove(hospital[hospital.Count - 1]);
                    db.SaveChanges();
                }
            }
        }

        static void Main(string[] args)
        {
            ReadAllHospital();
            ReadAllPatient();
            ReadAllDoctor();
            AddHospital();
            AddDoctor();
            AddPatient();
            AttachingDoctorToHospital();
            DellitHospital();
        }
    }
}

