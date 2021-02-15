using System;

namespace Models
{
    public interface IProcessJoker
    {
        string CatalogName { get; set; }
        string CatagoryName { get; set; }
        bool IsAllJokerDefinitionsPaused { get; set; }
        string ActiveDays { get; set; }
        DateTime Date { get; set; }
    }
}
