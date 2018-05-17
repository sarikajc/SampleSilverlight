using System;
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
    public class MedicationDetailsViewModel : BaseViewModel
    {
        private Guid id;
        private string medicineName;
        private DateTime startDate;
        private DateTime endDate;
        private string dosage;
        private string route;
        private string frequency;
        private string note;
        private bool toggleDisplay;
        private DelegateCommand<MedicationDetailsViewModel> editMedication;
        private DelegateCommand<MedicationDetailsViewModel> stopMedication;
        private DelegateCommand<MedicationDetailsViewModel> restartMedication;
        private DelegateCommand<MedicationDetailsViewModel> showMoreInfo;

        private List<string> medicineNames = new List<string>();
        private List<string> frequencyList = new List<string>();
        private MedicationListViewModel parent;


        public MedicationDetailsViewModel(MedicationListViewModel parent)
        {
            this.parent = parent;
            PopulateMedicines();
            PopulateFrequency();
        }
        public Guid ID
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value != Guid.Empty)
                {
                    this.id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        
        public string MedicineName
        {
            get
            {
                return this.medicineName;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.medicineName = value;
                    NotifyPropertyChanged("MedicineName");
                } 
            }
        }

        public MedicationListViewModel Parent
        {
            get
            {
                return this.parent;
            }            
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                if ( value != null)
                {
                    this.startDate = value;
                    NotifyPropertyChanged("StartDate");
                    NotifyPropertyChanged("IsComplete");
                    NotifyPropertyChanged("IsInProgress");
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }

            set
            {
                if (value != null)
                {
                    this.endDate = value;
                    NotifyPropertyChanged("EndDate");
                    NotifyPropertyChanged("IsComplete");
                    NotifyPropertyChanged("IsInProgress");
                }
            }
        }

        public string Dosage
        {
            get
            {
                return this.dosage;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.dosage = value;
                    NotifyPropertyChanged("Dosage");
                }
            }
        }

        public string Route
        {
            get
            {
                return this.route;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.route = value;
                    NotifyPropertyChanged("Route");
                }
            }
        }

        public string Frequency
        {
            get
            {
                return this.frequency;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.frequency = value;
                    NotifyPropertyChanged("Frequency");
                }
            }
        }

        public string Note
        {
            get
            {
                return this.note;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.note = value;
                    NotifyPropertyChanged("Note");
                }
            }
        }

        public bool IsComplete
        {
            get
            {
                return DateTime.Now >= EndDate; 
            }
        }

        public bool IsInProgress
        {
            get
            {
                var currentTime = DateTime.Now;
                return currentTime >= StartDate && currentTime <= EndDate;
            }
        }

        public bool IsYetToStart
        {
            get
            {
                var currentTime = DateTime.Now;
                return currentTime < StartDate;
            }
        }

        public List<string> MedicineNames
        {
            get
            {
                return this.medicineNames ?? (this.medicineNames = new List<string>());
            }
        }
        

        public List<string> FrequencyList
        {
            get
            {
                return this.frequencyList ?? (this.frequencyList = new List<string>());
            }
        }

        public bool ToggleDisplay
        {
            get
            {
                return this.toggleDisplay;
            }
            set
            {
                toggleDisplay = value;
                NotifyPropertyChanged("ToggleDisplay");
            }
        }

        public DelegateCommand<MedicationDetailsViewModel> EditMedication
        {
            get
            {
                return this.editMedication ?? (this.editMedication = new DelegateCommand<MedicationDetailsViewModel>(
                                                             (arg) => true,
                                                             this.ExecuteEditMedication));
            }
        }

        private void ExecuteEditMedication(MedicationDetailsViewModel obj)
        {
            
            if (obj != null)
            {
                this.Parent.MedicationUnderConsideration = obj;
            }             
        }

        public DelegateCommand<MedicationDetailsViewModel> StopMedication
        {
            get
            {
                return this.stopMedication ?? (this.stopMedication = new DelegateCommand<MedicationDetailsViewModel>(
                                                             (arg) => true,
                                                             this.ExecuteStopMedication));
            }
        }

        private void ExecuteStopMedication(MedicationDetailsViewModel obj)
        {
            this.EndDate = DateTime.Now;
        }

        public DelegateCommand<MedicationDetailsViewModel> RestartMedication
        {
            get
            {
                return this.restartMedication ?? (this.restartMedication = new DelegateCommand<MedicationDetailsViewModel>(
                                                             (arg) => true,
                                                             this.ExecuteRestartMedication));
            }
        }
        public DelegateCommand<MedicationDetailsViewModel> ShowMoreInfo
        {
            get
            {
                return this.showMoreInfo ?? (this.showMoreInfo = new DelegateCommand<MedicationDetailsViewModel>(
                                                             (arg) => true,
                                                             this.ExecuteShowMoreInfo));
            }
        }

        private void ExecuteShowMoreInfo(MedicationDetailsViewModel obj)
        {
            ToggleDisplay = !ToggleDisplay;             
        }

        public void CopyFrom( MedicationDetailsViewModel model)
        {
            this.Dosage = model.Dosage;
            this.EndDate = model.EndDate;
            this.StartDate = model.StartDate;
            this.Note = model.Note;
            this.MedicineName = model.MedicineName;
            this.Frequency = model.Frequency; 
        }

        private void ExecuteRestartMedication(MedicationDetailsViewModel obj)
        {
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now.AddMonths(1);
        }

         
        private void PopulateMedicines()
        {
            this.medicineNames.Add("Novolin Insulin");
            this.medicineNames.Add("Penicillin Potassium 250mg");
            this.medicineNames.Add("Disprin 1mg");
            this.medicineNames.Add("Crocin");
            this.medicineNames.Add("Saradon");
            this.medicineNames.Add("Digene");
            this.medicineNames.Add("Gelusil");
        }
        private void PopulateFrequency()
        {
            this.frequencyList.Add("Daily");
            this.frequencyList.Add("Twice a day");
            this.frequencyList.Add("Alternate day");
            this.frequencyList.Add("Once a week"); 
        }
    }
}
