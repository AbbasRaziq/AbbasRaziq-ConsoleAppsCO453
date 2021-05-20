using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App02
{
    public enum WeightCategories
    {
        None,
        [Display(Name = "Underweight")]
        UnderWeight,
        [Display(Name = "Normal weight")]
        NormalWeight,
        [Display(Name = "Overweight")]
        OverWeight,
        [Display(Name = "Obese Class I")]
        ObeseI,
        [Display(Name = "Obese Class II")]
        ObeseII,
        [Display(Name = "Obese Class III")]
        ObeseIII
    }
}
