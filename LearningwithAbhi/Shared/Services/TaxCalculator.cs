using System;
using LearningwithAbhi.Shared.Models;


namespace LearningwithAbhi.Shared.Services
{
    

    public class TaxCalculationService
    {
        public TaxResult CalculateOldRegime(decimal income, decimal investments)
        {
            return TaxCalculator.CalculateOldRegime(income, investments);
        }

        public TaxResult CalculateNewRegime(decimal income, decimal standardDeduction, decimal investments)
        {
            return TaxCalculator.CalculateNewRegime(income, standardDeduction, investments);
        }
    }


    public static class TaxCalculator
    {
        public static TaxResult CalculateOldRegime(decimal income, decimal investments)
        {
            decimal taxableIncome = income - 50000 - investments;
            var result = new TaxResult { TaxableIncome = taxableIncome };

            result.Slab5 = CalculateSlabTax(taxableIncome, 250001, 500000, 0.05m);
            result.Slab20 = CalculateSlabTax(taxableIncome, 500001, 1000000, 0.20m);
            result.Slab30 = CalculateSlabTax(taxableIncome, 1000001, decimal.MaxValue, 0.30m);
            result.TotalTax = result.Slab5 + result.Slab20 + result.Slab30;
            result.Rebate = taxableIncome <= 500000 ? Math.Min(result.TotalTax, 12500) : 0;
            result.Cess = (result.TotalTax - result.Rebate) * 0.04m;
            result.FinalTax = Math.Round(result.TotalTax - result.Rebate + result.Cess, 2);

            return result;
        }

        public static TaxResult CalculateNewRegime(decimal income, decimal standardDeduction, decimal investments)
        {
            decimal taxableIncome = income - standardDeduction - investments;
            var result = new TaxResult { TaxableIncome = taxableIncome };

            result.Slab5 = CalculateSlabTax(taxableIncome, 300001, 600000, 0.05m);
            result.Slab10 = CalculateSlabTax(taxableIncome, 600001, 900000, 0.10m);
            result.Slab15 = CalculateSlabTax(taxableIncome, 900001, 1200000, 0.15m);
            result.Slab20 = CalculateSlabTax(taxableIncome, 1200001, 1500000, 0.20m);
            result.Slab25 = CalculateSlabTax(taxableIncome, 1500001, 1800000, 0.25m);
            result.Slab30 = CalculateSlabTax(taxableIncome, 1800001, decimal.MaxValue, 0.30m);
            result.TotalTax = result.Slab5 + result.Slab10 + result.Slab15 + result.Slab20 + result.Slab25 + result.Slab30;
            result.Rebate = taxableIncome <= 700000 ? Math.Min(result.TotalTax, 60000) : 0;
            result.Cess = (result.TotalTax - result.Rebate) * 0.04m;
            result.FinalTax = Math.Round(result.TotalTax - result.Rebate + result.Cess, 2);

            return result;
        }

        private static decimal CalculateSlabTax(decimal income, decimal min, decimal max, decimal rate)
        {
            if (income <= min) return 0;
            var taxable = Math.Min(income, max) - min;
            return taxable * rate;
        }
    }
}
