using System;
using System.Collections.Generic;
using POCPicking.Models;

namespace POCPicking.Repositories
{
    public interface IPickerRepository
    {
        bool StartShift(Picker picker);

        bool ResumeShift(Picker picker, string connectionId);
        
        bool StopShift(Picker picker, bool informClient = false);

        Picker AssignTask(Picker picker, PickerTask task);
        
        PickerTask RemoveTask(Picker picker);

        Picker FindByName(string name);

        List<Picker> FindAll();
        
    }
}