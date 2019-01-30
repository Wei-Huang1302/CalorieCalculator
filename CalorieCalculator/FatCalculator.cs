using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalorieCalculator
{
    class FatCaculator : INotifyPropertyChanged
    {
        //create several constants that will be used in calculation
        const double FAT_Convert_Unit = 9.0;
        const double PERCENTAGE = 100.0;
        const double HIGH_FAT_POINT = 30.0;
        const string ZERO = "0";
        private bool highOrLowFat = false;
        public bool HighOrLowFat
        {
            get { return highOrLowFat; }
            set { highOrLowFat = value; ShowCategoryResult(); NotifyChanged(); }
        }
        private string fatContentInput = ZERO;
        public string FatContentInput
        {
            get { return fatContentInput; }
            set
            {
                //Credited: Jaime Borges, StackOverflow
                Regex regex = new Regex(@"^\d+(?:\.\d{0,3})?$");
                if (regex.IsMatch(value))
                {
                    fatContentInput = value; CaloriesFromFat(); FatPercentageInFood(); ShowCategoryResult(); NotifyChanged();
                }
            }
        }
        private string totalCaloriesInput = ZERO;
        public string TotalCaloriesInput
        {
            get { return totalCaloriesInput; }
            set
            {
                //Credited: Jaime Borges, StackOverflow
                Regex regex = new Regex(@"^\d+(?:\.\d{0,3})?$");
                if (regex.IsMatch(value))
                {
                    totalCaloriesInput = value; FatPercentageInFood(); CaloriesFromFat(); ShowCategoryResult(); NotifyChanged();
                }
            }
        }
        private string fatPercentage = "";
        public string FatPercentage
        {
            get { return fatPercentage; }
            set { fatPercentage = value; NotifyChanged(); }
        }
        private string fatCalories = "";
        public string FatCalories
        {
            get { return fatCalories; }
            set { fatCalories = value; NotifyChanged(); }
        }
        private string categoryResult = "";
        public string CategoryResult
        {
            get { return categoryResult; }
            set { categoryResult = value; NotifyChanged(); }
        }
        public void CaloriesFromFat()
        {
            FatCalories = (double.Parse(FatContentInput) * FAT_Convert_Unit).ToString("0.00");
        }
        public void FatPercentageInFood()
        {
            FatPercentage = ((double.Parse(FatContentInput)) * FAT_Convert_Unit * PERCENTAGE / (double.Parse(TotalCaloriesInput))).ToString("0.00");
        }
        public void ShowCategoryResult()
        {
            if (HighOrLowFat == true)
            {
                if (((double.Parse(FatContentInput)) * FAT_Convert_Unit * PERCENTAGE / (double.Parse(TotalCaloriesInput))) >= HIGH_FAT_POINT)
                {
                    CategoryResult = "High Fat Food";
                }
                else
                {
                    CategoryResult = "Low Fat Food";
                }
            }
            else
            {
                CategoryResult = "";
            }
        }
        public void ResetButton()
        {
            CategoryResult = "";
            FatContentInput = ZERO;
            TotalCaloriesInput = ZERO;
            HighOrLowFat = false;
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion                                    
    }

}
