using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FdcAgent.Models.FdcShemas.Nutriko
{
    public class NuFoodItem
    {
        private string _id;
        public string id {
            get { return _id; }
            set {
                _id = value;
            }
        }

        private string _dataType;
        public string dataType {
            get { return _dataType; }
            set {
                _dataType = value.ToLower().Replace(' ', '-');
            }
        }

        private string _category;
        public string category {
            get { return _category; }
            set {
                _category = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        private string _name;
        public string name {
            get { return _name; }
            set {
                _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        private string _publicationDate;
        public string publicationDate {
            get { return _publicationDate; }
            set {
                _publicationDate = Convert.ToDateTime(value).ToString("MM-dd-yyyy");
            }
        }

        public IList<NuFoodNutrient> foodNutrients { get; set; }
        public IList<NuFoodPortion> foodPortions { get; set; }
        public NuNutrientConversionFactors nutrientConversionFactors { get; set; }
    }

    public class NuFoodNutrient
    {
        private int _id;
        public int id {
            get { return _id; }
            set {
                _id = value;
            }
        }

        private string _name;
        public string name {
            get { return _name; }
            set {
                _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        private string _number;
        public string number {
            get { return _number; }
            set {
                _number = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        public string unitName { get; set; }
        public double amount { get; set; }
    }

    public class NuNutrientConversionFactors
    {
        public NuProteinConversionFactor proteinConversionFactor { get; set; }
        public NuCalorieConversionFactor calorieConversionFactor { get; set; }
    }

    public class NuProteinConversionFactor
    {
        public string type { get; set; }
        public double value { get; set; }
        public string name { get; set; }
    }

    public class NuCalorieConversionFactor
    {
        public string type { get; set; }
        public string name { get; set; }
        public double proteinValue { get; set; }
        public double fatValue { get; set; }
        public double carbohydrateValue { get; set; }
    }

    public class NuFoodPortion
    {
        public double gramWeight { get; set; }
        public double amount { get; set; }

        private string _name;
        public string name {
            get { return _name; }
            set {
                _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }
    }
}