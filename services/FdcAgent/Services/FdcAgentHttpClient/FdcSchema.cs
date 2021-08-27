using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FdcAgent.Models.FdcShemas
{
    public class FdcAgentHttpStatus
    {
        public int count { get; set; }
        public string message { get; set; }
    }

    public class SRLegacyFoodItem
    {
        public string id { get; set; }
        public int fdcId { get; set; }
        public string dataType { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string publicationDate { get; set; }
        public FdcFoodCategory foodCategory { get; set; }
        public IList<FdcFoodNutrient> foodNutrients { get; set; }
        public IList<FdcNutrientConversionFactors> nutrientConversionFactors { get; set; }
        public IList<FdcFoodPortion> foodPortions { get; set; }
    }

    public class FdcFoodPortion
    {
        public int id { get; set; }
        public double gramWeight { get; set; }
        public double amount { get; set; }
        public string modifier { get; set; }

    }

    public class FdcNutrientConversionFactors
    {
        public string type { get; set; }
        public double value { get; set; }
        public string name { get; set; }
        public double proteinValue { get; set; }
        public double fatValue { get; set; }
        public double carbohydrateValue { get; set; }
    }

    public class FdcFoodCategory 
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class FdcFoodNutrient
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string type { get; set; }
        public FdcNutrient nutrient { get; set; }

    }

    public class FdcNutrient
    {
        public int id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public string unitName { get; set; }
    }

}