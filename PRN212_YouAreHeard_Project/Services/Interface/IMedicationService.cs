using BussinessObjects;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IMedicationService
    {
        List<Medication> GetAll();
        Medication? GetById(int id);
    }
}
