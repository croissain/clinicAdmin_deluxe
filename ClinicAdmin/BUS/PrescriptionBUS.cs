﻿using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;

namespace ClinicAdmin.BUS
{
    public class PrescriptionBUS
    {
        private static PrescriptionBUS _instance;
        private PatientDAO patient;
        private string symptom;
        private string diagnose;
        private string medicalHistory;
        private string note;
        private string doctorName;
        private string staffName;
        private double totalCost;
        private List<Prescription_MedicineDAO> listMedicines;

        public string Symptom
        {
            get => symptom; set => symptom = value;
        }
        public string Diagnose
        {
            get => diagnose; set => diagnose = value;
        }
        public string MedicalHistory
        {
            get => medicalHistory; set => medicalHistory = value;
        }
        public string Note
        {
            get => note; set => note = value;
        }
        public string DoctorName
        {
            get => doctorName; set => doctorName = value;
        }
        public string StaffName
        {
            get => staffName; set => staffName = value;
        }
        public double TotalCost
        {
            get => totalCost; set => totalCost = value;
        }
        public PatientDAO Patient
        {
            get => patient; set => patient = value;
        }
        public List<Prescription_MedicineDAO> ListMedicines
        {
            get => listMedicines; set => listMedicines = value;
        }

        public static PrescriptionBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new PrescriptionBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {

        }

        public void AddPrescription()
        {
            PrescriptionDAO prescriptionDAO = new PrescriptionDAO()
            {
                Diagnose = Diagnose,
                MedicalHistory = MedicalHistory,
                Symptom = Symptom,
                Note = Note,
                Patient = Patient,
                Doctor = DoctorName,
                Staff = StaffName,
            };
            //Them du lieu vao bang Prescription
            var prescriptMedicine = PrescriptionDAO.getInstance().AddPrescription(prescriptionDAO);
            prescriptionDAO.Id = prescriptMedicine.Id;

            //Them du lieu vao bang Prescription_MedicineDAO
            foreach (var medicine in ListMedicines)
            {
                Prescription_MedicineDAO prescription_MedicineDAO = new Prescription_MedicineDAO()
                {
                    AmountDrug = medicine.AmountDrug,
                    Cost = medicine.Cost,
                    Unit = medicine.Unit,
                    Usage = medicine.Usage,
                    Medicine = medicine.Medicine,
                    Prescription = prescriptionDAO
                };
                Prescription_MedicineDAO.getInstance().AddPrescription(prescription_MedicineDAO);
            }

            //Them du lieu vao bang Invoice
            double examCost = Double.Parse(RegulationDAO.getInstance().GetExamFee().Value);
            InvoiceDAO invoiceDAO = new InvoiceDAO()
            {
                TotalCost = TotalCost + examCost,
                Prescription = prescriptionDAO,
                Created_at = DateTime.Now,
                ExamCost = examCost
            };
            InvoiceDAO.getInstance().AddInvoice(invoiceDAO);
        }
    }
}
