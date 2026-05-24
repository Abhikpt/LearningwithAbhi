namespace LearningwithAbhi.Shared.Models
{
    public class TaxResult
    {
        public decimal TaxableIncome { get; set; }
        public decimal Slab5 { get; set; }
        public decimal Slab10 { get; set; }
        public decimal Slab15 { get; set; }
        public decimal Slab20 { get; set; }
        public decimal Slab25 { get; set; }
        public decimal Slab30 { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Rebate { get; set; }
        public decimal Cess { get; set; }
        public decimal FinalTax { get; set; }
    }
}
