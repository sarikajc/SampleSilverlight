using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FinalAssignment.Helpers;
using System.Collections.Generic;

namespace FinalAssignment.ViewModels
{
    public class MedicationListViewModel : BaseViewModel
    {
        public MedicationListViewModel()
        {
            this.Medications.Add(new MedicationDetailsViewModel(this) { ID=Guid.NewGuid(), MedicineName = "Novolin Insulin", StartDate = new DateTime(2016, 2, 4), EndDate = new DateTime(2017, 3, 5), Dosage = "dose1", Frequency = "Daily", Note = "this is a test", Route = "Oral" });
            this.Medications.Add(new MedicationDetailsViewModel(this) { ID = Guid.NewGuid(), MedicineName = "Penicillin Potassium 250mg", StartDate = new DateTime(2017, 2, 4), EndDate = new DateTime(2019, 3, 5), Dosage = "dose2", Frequency = "TwiceDaily", Note = "this is a test", Route = "Oral" });
            this.Medications.Add(new MedicationDetailsViewModel(this) { ID = Guid.NewGuid(), MedicineName = "Disprin 1mg", StartDate = new DateTime(2017, 2, 4), EndDate = new DateTime(2019, 3, 5), Dosage = "dose3", Frequency = "TwiceDaily", Note = "this is a test", Route = "Oral" });
        }

        private DelegateCommand<MedicationDetailsViewModel>  addMedication;
        private ObservableCollection<MedicationDetailsViewModel> medications;
        private MedicationDetailsViewModel medicationUnderConsideration;
        
        public ObservableCollection<MedicationDetailsViewModel> Medications
        {
            get
            {
                return this.medications ?? (this.medications = new ObservableCollection<MedicationDetailsViewModel>());
            }

            set
            {
                if (value != null)
                {
                    this.medications = value;
                    NotifyPropertyChanged("Medications");
                }
            }
        }

        public MedicationDetailsViewModel MedicationUnderConsideration
        {
            get
            {
                return this.medicationUnderConsideration ?? (this.medicationUnderConsideration = GetDefaultDetailsModel() );
            }

            set
            {
                if (value != null)
                {
                    this.medicationUnderConsideration = value;
                    NotifyPropertyChanged("MedicationUnderConsideration");
                }
            }
        }

        public DelegateCommand<MedicationDetailsViewModel> AddMedication
        {
            get
            {
                return this.addMedication ?? (this.addMedication = new DelegateCommand<MedicationDetailsViewModel>(
                                                             (arg) => true,
                                                             this.ExecuteAddMedication));
            }
        }       
        
        private void ExecuteAddMedication(MedicationDetailsViewModel obj)
        {
            if (this.MedicationUnderConsideration.ID == Guid.Empty)
            {
                this.Medications.Add(this.MedicationUnderConsideration);                
            }
            else
            {
                if (this.Medications.Contains(this.MedicationUnderConsideration))
                {
                    for(int i=0; i< this.Medications.Count; i++)
                    {
                        if( this.Medications[i].ID == this.MedicationUnderConsideration.ID )
                        {
                            this.Medications[i].CopyFrom(this.MedicationUnderConsideration);
                        }
                    }
                    GetDefaultDetailsModel();
                }
            }
            this.MedicationUnderConsideration = GetDefaultDetailsModel();
        }        

        private MedicationDetailsViewModel GetDefaultDetailsModel()
        {
            return new MedicationDetailsViewModel(this)
            { ID=Guid.Empty, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), MedicineName = "Novolin Insulin", Frequency = "Daily" };
        }
    }
}
