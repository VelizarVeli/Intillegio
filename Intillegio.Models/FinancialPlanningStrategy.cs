namespace Intillegio.Models
{
    public class FinancialPlanningStrategy : BaseId
    {
        public string Name { get; set; }

        public int SolutionId { get; set; }
        public virtual Solution Solution { get; set; }
    }
}
